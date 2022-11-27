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
    private readonly string _key = "E86RUP469F0R411xAC902514C082388";
    private readonly string _conFileName = "DBWorkshop";
    private readonly AppKey _appKey;
    private readonly DBConnectionService _dbConnectionService;
    public MainForm() {
      InitializeComponent();
      _appKey = new AppKey(_key);
      _dbConnectionService = new DBConnectionService(_appKey, _conFileName);
      if (_dbConnectionService.GetConnectionCountOnFile() == 0) {
        tabBuildIt.Hide();        
      } else { 
        listBox1.Items.Clear();
        var cons = _dbConnectionService.GetConnectionNames();
        foreach (var consName in cons) {
          listBox1.Items.Add(consName);
        }
      }
      //DbConnectionInfo? ConnInfo = _dbConnectionService.GetConnectionInfo("PD");
      //if (ConnInfo == null) {
      //  DbConnectionInfo dbInfo = new DbConnectionInfo("PD", "data source=DESKTOP-DELICI0;initial catalog=ARC01;user id=website;password=qQ#Qw5S!25byAuY3;Connection Timeout=15");
      //  _dbConnectionService.AddUpdate("PD", dbInfo);
      //}
      //ConnInfo = _dbConnectionService.GetConnectionInfo("PD");
    }

    private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e) {
      if (tabControlMain.SelectedIndex == 0) {

      }
      if (tabControlMain.SelectedIndex == 1) {
        ReloadTvMain();
      }
    }

    public DbConnectionInfo? EditCon { get; set;}

    private void MainForm_Shown(object sender, EventArgs e) {
      
    }

    private bool _conModified = false;
    public bool ConnectionsModified { 
      get { return _conModified; }
      set { 
         _conModified = value;
         if (!btnSaveCon.Visible) btnSaveCon.Visible = _conModified;         
      } 
    } 
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        var val = listBox1.SelectedItem.AsString();
        EditCon = _dbConnectionService.GetConnectionInfo(val);
        if (EditCon != null) {
           tbConName.Text = EditCon.ConnectionName;
           tbServer.Text = EditCon.ServerName;
           tbDatabase.Text = EditCon.InitialCatalog;
           tbUserName.Text = EditCon.UserName;
           tbPassword.Text = EditCon.Password;
           ConnectionsModified = false;
        }
      } catch { }
    }

    private void tbConName_ModifiedChanged(object sender, EventArgs e) {
      ConnectionsModified = true;
    }

    private void ReloadTvMain() {
      tvMain.Nodes.Clear();
      foreach (ConnectionStringSettings sx in ConfigurationManager.ConnectionStrings) {
        DbConnectionInfo aCI = new DbConnectionInfo(sx.Name, sx.ConnectionString);
        tvMain.Nodes.Add(new DBConNode(aCI));        
      }
    }

    private bool isExpanding = false; 
    private async void tvMain_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
      if (!isExpanding) { 
        TreeNode? thisNode = e.Node;
        if (thisNode != null) {
          tvMain.BeginUpdate();
          switch (thisNode.Level) {
            case 0:   // server Level      
              e.Node.Nodes.Clear();
              DbConnectionInfo aDBI1 = ((DBConNode)thisNode)._dBConnection; 
              try {
                IEnumerable<DatabaseResultModel> databases;
                using (SqlConnection connection = new SqlConnection(aDBI1.ConnectionString)) {
                  databases = await connection.QueryAsync<DatabaseResultModel>(
                    "select name db from master.dbo.sysdatabases " +
                    "where (dbid > 2) and (not (name in ('model','msdb')))  order by name");
                }
                foreach (DatabaseResultModel dr in databases) {                                
                  TreeNode atn = new TreeNode(dr.Db, 1, 1);
                  atn.Nodes.Add("PlaceHolder");
                  e.Node.Nodes.Add(atn);
                }    
                if (!e.Node.IsExpanded) { 
                  isExpanding = true;
                  e.Node.Expand();
                  isExpanding = false;
                 }
              } catch (Exception ex) {
    
              }
              break;
            case 1:  // database Level
              var dbName = e.Node.Parent.Text.ParseString(":", 0);
              string sdb = e.Node.Text; 
              e.Node.Nodes.Clear();
              DbConnectionInfo aDBCI = ((DBConNode)thisNode.Parent)._dBConnection;              
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
                TreeNode ObjTypeNode = null, ObjItemNode = null;
                string sLastObjType = "";
                string sLastItem = "";
                foreach (DBObjectsResultModel dr in dBObjects) {                  
                  string sItemName = Convert.ToString(dr.ObjectName);
                  if ((dr.ObjectType == "Procedure") || (dr.ObjectType == "Table") || (dr.ObjectType == "View") || (dr.ObjectType == "Function")) {
                    if (sLastObjType != dr.ObjectType) {
                      ObjTypeNode = new TreeNode(dr.ObjectType+"s", 2, 2);
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
                      if ((sColType.ToLower() == "varchar") && (sVarLen == "-1")) {
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
                MessageBox.Show(this.Owner, ee.Message, "dbWorkshop Error");
              }
              break;
          }
          tvMain.EndUpdate();
        }        
      }
    }

    private void tvMain_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
      
    }

    
  }
}