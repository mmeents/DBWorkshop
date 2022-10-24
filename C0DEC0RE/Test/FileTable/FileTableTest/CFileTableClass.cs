using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Data.Common;
using C0DEC0RE;

namespace FileTableTest {

  #region CFileTable Enums

  public enum FTState {
    fsInactive = 0,
    fsBrowse = 1,
    fsEdit = 2,
    fsInsert = 3,
    fsSetKey = 4
  }

  public enum CColType { ctColKey = 0, ctString = 1, ctInt32 = 2, ctDateTime = 3 }

  #endregion

  #region CColumns

  class CColumn : CObject {
    public CColumns Owner { get { return (CColumns)base["owner"]; } set { base["owner"] = value; } }
    public Int16 Key { get { return Convert.ToInt16(base["Key"]); } set { base["Key"] = value; } }
    public string Caption { get { return base["Caption"].toString(); } set { base["Caption"] = value; } }
    public string Name { get { return base["Name"].toString(); } set { base["Name"] = value; } }
    public CColType ColType { get { return (CColType)base["ColType"]; } set { base["ColType"] = value; } }
    public CColumn(CColumns aOwner, string aCaption, string aName, CColType aType) {
      Owner = aOwner; Caption = aCaption; Name = aName; ColType = aType;
    }
  }

  class CColumns : CCache16 {
    public IOrderedEnumerable<short> ColKeys;
    public new CColumn this[short aKey] {
      get { return (CColumn)(Contains(aKey) ? base[aKey] : null); }
      set { base[aKey] = value; }
    }
    public CColumn Add(CColumn column) {
      column.Owner = this;
      Nonce--;
      base[Nonce] = column;
      column.Key = Nonce;
      ColKeys = Keys.OrderByDescending(x => x);
      return (CColumn)column;
    }
    public CColumn First() {
      CColumn c = null;
      if (Keys.Count > 0) {
        short k = base.Keys.OrderBy(x => x).First();
        c = (CColumn)this[k];
      }
      return c;
    }

  }

  #endregion

  #region CRows

  // Cell level Value
  class CField : CObject {
    public CRow Owner { get { return (CRow)base["Owner"]; } set { base["Owner"] = value; } }
    public CColumn Column { get { return (CColumn)base["Column"]; } set { base["Column"] = value; } }
    public string Value { get { return base["Value"].toString(); } set { base["Value"] = value; } }
    public CField(CRow aRow, CColumn aCol, string aValue) : base() {
      Owner = aRow;
      Column = aCol;
      Value = aValue;
    }
  }

  // Row is a list of Fields governed via columns.
  class CRow : CObject {
    public CRows Owner;
    public Int32 Key;
    public CRow(CRows aOwner) : base() {
      Owner = aOwner;
      foreach (short key in Owner.Cols.ColKeys) {
        CColumn aCol = Owner.Cols[key];
        CField aField = Add(new CField(this, aCol, ""));
      }
    }
    public CField Add(CField field) {
      base[field.Column.Name] = field;
      return (CField)field;
    }
    public new CField this[string FieldName] {
      get { return (CField)base[FieldName]; }
      set { base[FieldName] = value; }
    }
  }

  // Cache of Row objects is the Rows, add references to lets not forget who where doing this for...
  class CRows : CCache32 {
    public CFileTable Owner;
    public CColumns Cols;
    public new CRow this[Int32 aRK] {
      get { return (Contains(aRK) ? (CRow)base[aRK] : null); }
      set { base[aRK] = value; }
    }
    public CRows(CFileTable aOwner, CColumns columns) : base() {
      Owner = aOwner;
      Cols = columns;
    }
    public CRow Add(CRow row) {
      row.Owner = this;
      Nonce--;
      base[Nonce] = row;
      row.Key = Nonce;
      return (CRow)row;
    }
    public CRow Load(IniFile af, Int32 iRowKey) {
      CRow r = Add(new CRow(this));
      foreach (short ColKey in Owner.Columns.ColKeys) {  // for each column
        CColumn c = Owner.Columns[ColKey];
        Owner.Rows[r.Key][c.Name].Value = af["R" + iRowKey.toString()][c.Name].toString();  // lookup value from file        
      }
      return r;
    }
    public void Save(IniFile af, Int32 iRowKey) {
      foreach (short ColKey in Owner.Columns.ColKeys) {  // for each column
        CColumn c = Owner.Columns[ColKey];
        af["R" + iRowKey.toString()][c.Name] = Owner.Rows[iRowKey][c.Name].Value;   // lookup value from file        
      }
    }
  }

  #endregion

  #region CFileTable

  class CFileTable {

    private FTState ObjectState = FTState.fsInactive;
    public void SetFTState(FTState aFTState) { ObjectState = aFTState; }
    public FTState GetFTState() { return ObjectState; }
    public FTState State { get { return GetFTState(); } set { SetFTState(value); } }

    public string FileName;
    public CColumns Columns;
    public CRows Rows;

    public CFileTable(string sFileName) {
      SetFTState(FTState.fsInactive);
      FileName = sFileName;
      Columns = new CColumns();
      Rows = new CRows(this, Columns);
      if (File.Exists(FileName)) {
        Load();
      }
    }

    public void Load() {

      IniFile f = IniFile.FromFile(FileName);

      string sColIndex = f["A"]["ColumnIndex"].toBase64DecryptStr();
      short iColumnCount = Convert.ToInt16(sColIndex.ParseCount(";"));
      if (iColumnCount > 0) {
        if (Columns.Count > 0) { Columns.Clear(); }
        for (short i = 0; i <= iColumnCount - 1; i++) {
          string sI = sColIndex.ParseString(";", i).toString();
          string sCaption = f["C" + sI]["Ca"];
          string sName = f["C" + sI]["Na"];
          string sType = f["C" + sI]["Ty"];
          CColType aType;
          if (!DbType.TryParse(sType, out aType)) {
            throw new Exception("Parse type Failed for " + sType);
          }
          Columns.Add(new CColumn(Columns, sCaption, sName, aType));
        }

        string sRowIndexEnc = f["A"]["RowIndex"];
        string sRowIndex = sRowIndexEnc.toBase64DecryptStr();

        Int32 iRowCount = Convert.ToInt32(sRowIndex.ParseCount(";"));
        if (iRowCount > 0) {
          if (Rows.Count > 0) { Rows.Clear(); }
          for (Int32 i = 0; i <= iRowCount - 1; i++) {
            string sI = sRowIndex.ParseString(";", i).toString();
            Rows.Load(f, sI.toInt32());
          }
        }

      }
    }

    public void SaveTable() {

      IniFile f = IniFile.FromFile(FileName);

      // Column Index, list of keys by delimited by semicolon
      IOrderedEnumerable<short> k = Columns.Keys.OrderByDescending(x => x);
      string sColIndex = "";
      foreach (short key in k) {
        sColIndex = sColIndex + key.toString() + ";";
      }
      sColIndex = sColIndex.toBase64EncryptStr();
      f["A"]["ColumnIndex"] = sColIndex;

      CColumn c;
      foreach (short key in k) {
        c = (CColumn)Columns[key];
        string sI = c.Key.toString();
        f["C" + sI]["Ca"] = c.Caption;
        f["C" + sI]["Na"] = c.Name; ;
        f["C" + sI]["Ty"] = c.ColType.ToString();
      }

      if (Rows.Count > 0) {

        IOrderedEnumerable<Int32> r = Rows.Keys.OrderByDescending(x => x);
        string sRowIndex = "";
        foreach (Int32 RowKey in r) {
          sRowIndex = sRowIndex + RowKey.toString() + ";";
          Rows.Save(f, RowKey);
        }
        sRowIndex = sRowIndex.toBase64EncryptStr();
        f["A"]["RowIndex"] = sRowIndex;
      }

      f.Save(FileName);

    }

    public void LoadRows() {

      IniFile f = IniFile.FromFile(FileName);

      string sRowIndex = f["A"]["RowIndex"].toBase64DecryptStr();
      Int32 iRowCount = Convert.ToInt32(sRowIndex.ParseCount(";"));
      if (iRowCount > 0) {
        if (Rows.Count > 0) { Rows.Clear(); }
        for (Int32 i = 0; i <= iRowCount - 1; i++) {
          string sI = sRowIndex.ParseString(";", i).toString();
          Rows.Load(f, sI.toInt32());
        }
      }

    }

    public void SaveRows() {
      if (Rows.Count > 0) {

        IniFile f = IniFile.FromFile(FileName);

        IOrderedEnumerable<Int32> r = Rows.Keys.OrderByDescending(x => x);
        string sRowIndex = "";
        foreach (Int32 RowKey in r) {
          sRowIndex = sRowIndex + RowKey.toString() + ";";
          Rows.Save(f, RowKey);
        }
        sRowIndex = sRowIndex.toBase64EncryptStr();
        f["A"]["RowIndex"] = sRowIndex;

        f.Save(FileName);

      }
    }

  }




  #endregion

}
