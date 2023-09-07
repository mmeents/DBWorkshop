using StaticExtensions;
using AppCrypto.Models;
using AppCrypto.Services;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using DBWorkshop.Models;

namespace DBWorkshop {
  public partial class MainForm : Form {
    #region Form Vars and startup
    private readonly string _key = "E86RUP469F0R411xAC902514C082388";
    private readonly string _conFileName = "DBWorkshop";
    private readonly AppKey _appKey;
    private readonly DBConnectionService _dbConnectionService;
    public DbConnectionInfo? EditCon { get; set; }
    public MainForm() {
      InitializeComponent();
      _appKey = new AppKey(_key);
      _dbConnectionService = new DBConnectionService(_appKey, _conFileName);
      SetupMainWelcomeTab();
    }
    private void MainForm_Shown(object sender, EventArgs e) {

    }
    private void SetupMainWelcomeTab() {
      if (_dbConnectionService.GetConnectionCountOnFile() == 0) {
        if (tabBuildIt.Visible) { tabBuildIt.Visible = false; }
      } else {
        listBox1.Items.Clear();
        var cons = _dbConnectionService.GetConnectionNames();
        foreach (var consName in cons) {
          listBox1.Items.Add(consName);
        }
      }
    }
    #endregion
    #region Tab Connections
    private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e) {
      if (tabControlMain.SelectedIndex == 0) {
        this.Text = "DBWorkshop  -  Set Connection Strings";
      }
      if (tabControlMain.SelectedIndex == 1) {
        this.Text = "DBWorkshop  -  Generate Code";
        ReloadTvMain();
      }
    }
    private bool _conModified = false;
    public bool ConnectionsModified {
      get { return _conModified; }
      set {
        _conModified = value;
        if (btnSaveCon.Visible != _conModified) {
          btnSaveCon.Visible = _conModified;
        }
        if (listBox1.SelectedItem is not null) {
          btnRemoveConnection.Visible = true;
        } else {
          btnRemoveConnection.Visible = false;
        }
      }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        var val = listBox1.SelectedItem.AsString();
        EditCon = _dbConnectionService.GetConnectionInfo(val);
        if (EditCon != null) {
          edConName.Text = EditCon.ConnectionName;
          edServer.Text = EditCon.ServerName;
          edDatabase.Text = EditCon.InitialCatalog;
          edUserName.Text = EditCon.UserName;
          edPassword.Text = EditCon.Password;
          ConnectionsModified = false;
        }
      } catch { }
    }
    private void tbConName_ModifiedChanged(object sender, EventArgs e) {
      ConnectionsModified = true;
    }
    private void btnSaveCon_Click(object sender, EventArgs e) {
      string connectionName = listBox1.SelectedItem?.ToString() ?? "default";
      DbConnectionInfo ci = new() {
        ConnectionName = edConName.Text,
        ServerName = edServer.Text,
        InitialCatalog = edDatabase.Text,
        UserName = edUserName.Text,
        Password = edPassword.Text
      };

      _dbConnectionService.AddUpdate(connectionName, ci);
      ConnectionsModified = false;

    }
    #endregion
    #region tvMain Tree view
    private void ReloadTvMain() {
      tvMain.Nodes.Clear();
      foreach (ConnectionStringSettings sx in ConfigurationManager.ConnectionStrings) {
        DbConnectionInfo aCI = new DbConnectionInfo(sx.Name, sx.ConnectionString);
        tvMain.Nodes.Add(new DBConNode(aCI));
      }
    }

    private bool isExpanding = false;

    private void WriteError(string message) {
      edError.Text = message + Environment.NewLine + edError.Text;
    }
    private async void TvMain_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
      if (!isExpanding) {
        if (e.Node != null) {
          tvMain.BeginUpdate();
          switch (e.Node.Level) {
            case 0:   // server Level      
              e.Node.Nodes.Clear();
              DbConnectionInfo aDBI1 = ((DBConNode)e.Node)._dBConnection;
              try {
                IEnumerable<DatabaseResultModel> databases;
                using (SqlConnection connection = new SqlConnection(aDBI1.ConnectionString)) {
                  databases = await connection.QueryAsync<DatabaseResultModel>(
                    "select name db from master.dbo.sysdatabases " +
                    "where (dbid > 2) and (not (name in ('model','msdb')))  order by name");
                }
                foreach (DatabaseResultModel dr in databases) {
                  DBNode atn = new DBNode(aDBI1, dr.Db);
                  //TreeNode atn = new TreeNode(dr.Db, 1, 1);
                  atn.Nodes.Add("PlaceHolder");
                  e.Node.Nodes.Add(atn);
                }
                if (!e.Node.IsExpanded) {
                  isExpanding = true;
                  e.Node.Expand();
                  isExpanding = false;
                }
              } catch (Exception ex) {
                WriteError(ex.Message);
              }
              break;
            case 1:  // database Level
              string sdb = e.Node.Text;
              e.Node.Nodes.Clear();
              DbConnectionInfo aDBCI = ((DBNode)e.Node)._dBConnection;
              try {  // ObjType, tbl, col, ColType, ColLen
                IEnumerable<DBObjectsResultModel> dBObjects;
                using (SqlConnection connection = new SqlConnection(aDBCI.ConnectionString)) {
                  dBObjects = await connection.QueryAsync<DBObjectsResultModel>(
                    " select case "
                  + "   when rtrim(so.xtype) = 'P' then 'Procedure' "
                  + "   when rtrim(so.xtype) = 'U' then 'Table' "
                  + "   when rtrim(so.xtype) = 'V' then 'View' "
                  + "   when rtrim(so.xtype) = 'FN' then 'Function' end ObjectType, "
                  + $"  OBJECT_SCHEMA_NAME(so.id, DB_ID ('{sdb}'))+'.'+so.name ObjectName,"
                  + "   sc.name ColumnName,"
                  + "   rtrim(st.name) ColumnType, "
                  + "   sc.length ColumnLen "
                  + $"from [{sdb}].dbo.sysobjects so "
                  + $"  left outer join [{sdb}].dbo.syscolumns sc on so.id=sc.id "
                  + "   left outer join ( "
                  + "     select Name, min(UserType) UserType, xtype "
                  + $"    from [{sdb}].dbo.systypes "
                  + "     Group by Name, xtype ) st on sc.UserType=st.UserType and sc.xtype=st.xtype "
                  + " where so.xtype  in ('U','V','P','FN') and (so.Name not like ('dt_%'))"
                  + "   and (so.Name not like ('sys%')) and (st.Name is not null)  "
                  + " order by so.xtype, so.name, sc.ColOrder  ");
                }
                TreeNode? ObjTypeNode = null, ObjItemNode = null;
                string sLastObjType = "";
                string sLastItem = "";
                foreach (DBObjectsResultModel dr in dBObjects) {
                  string sItemName = dr.ObjectName;
                  if ((dr.ObjectType == "Procedure") || (dr.ObjectType == "Table") || (dr.ObjectType == "View") || (dr.ObjectType == "Function")) {
                    if (sLastObjType != dr.ObjectType) {
                      ObjTypeNode = new TreeNode(dr.ObjectType + "s", 2, 2);
                      e.Node.Nodes.Add(ObjTypeNode);
                      sLastObjType = dr.ObjectType;
                    }
                    if ((sLastItem != sItemName) && (ObjTypeNode != null)) {
                      Int32 iImageIndex = AppStatic.GetImageIndexFromCode(dr.ObjectType);
                      ObjItemNode = new TreeNode(sItemName, iImageIndex, iImageIndex);
                      ObjTypeNode.Nodes.Add(ObjItemNode);
                      sLastItem = sItemName;
                    }
                    if (ObjItemNode != null) {
                      string sVarLen = Convert.ToString(dr.ColumnLen);
                      string sColType = Convert.ToString(dr.ColumnType);
                      if (((sColType.ToLower() == "varchar") || (sColType.ToLower() == "nvarchar")) && (sVarLen == "-1")) {
                        sVarLen = "MAX";
                      }
                      string sCol = Convert.ToString(dr.ColumnName);
                      ObjItemNode.Nodes.Add(new TreeNode((sColType.Contains("char") ? sCol + " " + sColType + "(" + sVarLen + ")" : sCol + " " + sColType), 7, 7));
                    }
                  }
                }
                if (!e.Node.IsExpanded) {
                  isExpanding = true;
                  e.Node.Expand();
                  isExpanding = false;
                }
              } catch (Exception ee) {
                WriteError(ee.Message);
              }
              break;
          }
          tvMain.EndUpdate();
        }
      }
    }


    private void tvMain_AfterSelect(object sender, TreeViewEventArgs e) {
      if ((e != null) && (e.Node != null)) {
        tvMain_OnActiveSelectionChangeAsync(e.Node);
      }
    }
    public void tvMain_OnActiveSelectionChangeAsync(TreeNode focusNode) {
      try {
        Int32 iCurLevel = focusNode.Level;
        switch (focusNode.ImageIndex) {
          case 0: PrepareServer(focusNode); break;
          case 1: PrepareDatabase(focusNode); break;
          case 2: PrepareFolder(focusNode); break;
          case 3: PrepareTable(focusNode); break;
          case 4: PrepareView(focusNode); break;
          case 5: PrepareProcedure(focusNode); break;
          case 6: PrepareFunctionAsync(focusNode); break;
        }
      } catch (Exception ex) {
        WriteError(ex.Message);
      }
    }
    #endregion
    #region Fill Text Boxes with code
    public void PrepareServer(TreeNode tnServer) {
      tbSQL.Text = "SQL Not Implemented Yet";
      //edC.Text = "C# Not Implemented yet ";
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public void PrepareDatabase(TreeNode tnDatabase) {
      tbSQL.Text = "SQL Not Implemented Yet";
      //edC.Text = "C# Not Implemented yet ";
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public void PrepareFolder(TreeNode tnFolder) {
      DbConnectionInfo? ci = GetDbConnectionInfo(tnFolder);
      string c = "" + CodeStatic.GetNamespaceText(ci?.InitialCatalog ?? "NeedsNamespace");
      int ii = 0;
      int i = 0;
      foreach (TreeNode tnNode in tnFolder.Nodes) {
        ii = tnNode.ImageIndex;
        switch (ii) {
          case 3: c += tnNode.GenerateCSharpRepoLikeClassFromTable(false); break;
          case 4: c += tnNode.GenerateCSharpRepoLikeClassFromTable(false); break;
          case 5: c += tnNode.GenerateCSharpExecStoredProc(); break;
          case 6: break;
        }
        if (i == 0 && c.Length > 2) {
          c = c.Substring(0, c.Length - 2);
        }
        i++;

      }

      tbSQL.Text = "SQL Not Implemented Yet";
      if (ii == 3 || ii == 4 || ii == 5) {
        tbCSharp.Text = c + CodeStatic.nl + "  }";
      } else
        tbCSharp.Text = "C# Not Implemented yet ";
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public async void PrepareFunctionAsync(TreeNode tnFunction) {
      tbSQL.Text = await GetHelpTextAsync(tnFunction);
      tbCSharp.Text = "C# Not Implemented yet ";
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public async void PrepareTable(TreeNode tnTable) {
      tbSQL.Text = tnTable.GenerateSQLAddUpdateStoredProc() + CodeStatic.nl + CodeStatic.nl + await GetCreateTableSQL(tnTable);
      tbCSharp.Text = tnTable.GenerateCSharpRepoLikeClassFromTable();
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public async void PrepareProcedure(TreeNode tnProcedure) {
      tbSQL.Text = await GetHelpTextAsync(tnProcedure) + CodeStatic.nl + CodeStatic.nl +
        tnProcedure.GetExecSQLStoredProcedure();
      tbCSharp.Text = tnProcedure.GenerateCSharpExecStoredProc();
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    public async void PrepareView(TreeNode tnView) {
      tbSQL.Text = await GetHelpTextAsync(tnView);
      tbCSharp.Text = tnView.GenerateCSharpRepoLikeClassFromTable();
      //edSQLCursor.Text = "Not Implemented see Table or View item on tree.";
      //edWiki.Text = "";
    }
    #endregion
    #region Database Code Gen functions
    public async Task<string> GetHelpTextAsync(TreeNode cn) { // expecting a Function or Procedure as cn. 
      string sResult = "";
      string ObjName = cn.Text.ParseFirst(" ");
      DbConnectionInfo? dbci = GetDbConnectionInfo(cn);
      if (dbci != null) {
        string sDBName = dbci.InitialCatalog;
        if (dbci != null) {
          try {
            IEnumerable<DatabaseTextResultModel> result;
            using (SqlConnection connection = new SqlConnection(dbci.ConnectionString)) {
              result = await connection.QueryAsync<DatabaseTextResultModel>(sDBName + ".sys.sp_helptext", new { ObjName }, commandType: CommandType.StoredProcedure);
            }
            if (result.Any()) {
              foreach (DatabaseTextResultModel dr in result) {
                sResult += dr.Text;
              }
            }
          } catch (Exception e) {
            WriteError($"Error Database:{sDBName}  ObjName:{ObjName} while accessing sp_HelpText, " + e.Message);
          }
        }
      }
      return sResult;

    }

    public async Task<string> GetCreateTableSQL(TreeNode tnTable) {
      string R = $"// Drop Table {tnTable.Text}" + CodeStatic.nl + CodeStatic.nl;
      string sTableName = tnTable.Text;
      DbConnectionInfo? dbci = GetDbConnectionInfo(tnTable);
      if (dbci != null) {
        string SQLToGetCreate = CodeStatic.GenerateCreateTableSQL(tnTable);
        using (SqlConnection connection = new SqlConnection(dbci.ConnectionString)) {
          R += await connection.QueryFirstOrDefaultAsync<string>(SQLToGetCreate);
        }
      }
      return R;
    }

    #endregion

    private void btnRemoveConnection_Click(object sender, EventArgs e) {
      string connName = listBox1.SelectedItem?.ToString() ?? "default";
      if (connName != "default") {
        _dbConnectionService.RemoveConnection(connName);
      }
    }

    private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
      if (tabControlTextEditors.SelectedTab == tabSQL) {
        Clipboard.SetText(tbSQL.SelectedText);
      } else if (tabControlTextEditors.SelectedTab == tabCSharp) {
        Clipboard.SetText(tbCSharp.SelectedText);
      }
    }

    private void tabControlTextEditors_Selected(object sender, TabControlEventArgs e) { }

    private void MenuStripCSharp_Opening(object sender, System.ComponentModel.CancelEventArgs e) { }

    private DbConnectionInfo? GetDbConnectionInfo(TreeNode ThisNode) {
      if (ThisNode == null) {
        throw new Exception("Node is null");
      }
      if (ThisNode is DBNode) {
        DBNode ConNode = (DBNode)ThisNode;
        return ConNode._dBConnection;
      }
      if (!ThisNode.Parent.IsNull()) {
        return GetDbConnectionInfo(ThisNode.Parent);
      } else {
        return null;
      }
    }
    private async void MenuExecuteSql_ClickAsync(object sender, EventArgs e) {
      try {
        string s = tbSQL.SelectedText;
        TreeNode sn = tvMain.SelectedNode;
        DbConnectionInfo? con = GetDbConnectionInfo(sn);
        if ((con != null) && (MessageBox.Show(this, s, $"Execut SQL against {con.InitialCatalog}?", MessageBoxButtons.YesNo) == DialogResult.Yes)) {
          WriteError("executing: " + s);
          using (SqlConnection connection = new SqlConnection(con.ConnectionString)) {
            await connection.ExecuteAsync(s);
          }
        } else {
          WriteError("Failed to find database connection string...");
        }
      } catch (Exception ex) {
        WriteError(ex.AsWalkExcTreePath());
      }
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e) {
      DialogResult DR = SD.ShowDialog();
      SD.InitialDirectory = Environment.CurrentDirectory;
      if (DR == DialogResult.OK) {
        string FilePathAndName = SD.FileName;
        File.WriteAllText(FilePathAndName, tbCSharp.SelectedText);
      }
    }

    private void saveSelectedToFileToolStripMenuItem_Click(object sender, EventArgs e) {
      DialogResult DR = SD.ShowDialog();
      SD.InitialDirectory = Environment.CurrentDirectory;
      if (DR == DialogResult.OK) {
        string FilePathAndName = SD.FileName;
        File.WriteAllText(FilePathAndName, tbCSharp.SelectedText);
      }
    }

    private void MenuStripSql_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

    }

    private void MainForm_Resize(object sender, EventArgs e) {
      int newHeight = tvMain.Parent.Height - panel1.Height;
      if (tvMain.Height != newHeight) {
        tvMain.Height = newHeight;
      }
    }

    private void tabWelcome_Click(object sender, EventArgs e) {

    }
  }
}