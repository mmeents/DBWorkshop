using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Data.Common;
using C0DEC0RE;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileTableTest {
 
  [TestClass]
  public class UnitTest1 {

  //  [TestMethod]
    public void ReCreateDamons() {
      string sFileName = MMExt.MMConLocation() + "\\Damonsx2.ini";
      if (File.Exists(sFileName)) { File.Delete(sFileName); }
      CFileTable Damons = new CFileTable(sFileName);
      Damons.Columns.Add(new CColumn(Damons.Columns, "ConID", "CI", CColType.ctString));
      Damons.Columns.Add(new CColumn(Damons.Columns, "Machine", "MA", CColType.ctString));
      Damons.Columns.Add(new CColumn(Damons.Columns, "Signin", "SI", CColType.ctDateTime));
      Damons.Columns.Add(new CColumn(Damons.Columns, "SignOut", "SO", CColType.ctDateTime));

      CRow r = Damons.Rows.Add(new CRow(Damons.Rows));
      r["CI"].Value = "Connection 1";
      r["MA"].Value = "Machine B";
      r["SI"].Value = DateTime.Now.toString();

      Damons.SaveTable();
    }

 //   [TestMethod]
    public void ViewColumns() {

      string sFileName = MMExt.MMConLocation() + "\\Damonsx2.ini";
      CFileTable Damons = new CFileTable(sFileName);

      //foreach (short x in Damons.Columns.Keys) {
      //  CColumn c = (CColumn)Damons.Columns[x];
      //  Console.WriteLine("Key:"+ c.Key.toString()+ ";Name:"+ c.Name +";Caption:"+c.Caption+";Type:"+c.ColType.ToString()+";");
      // }

      foreach (Int32 x in Damons.Rows.Keys) {
        CRow c = Damons.Rows[x];
        Console.WriteLine("Key:" + x.toString() + ";Con:" + c["CI"].Value + ";Ma:" + c["MA"].Value + ";");
      }

    }


  }
}
