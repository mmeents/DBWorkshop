using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C0DEC0RE;
using Ionic.Zip;
using StaticExtensions;

namespace dbWorkshop
{
  public partial class Form1:Form{

  //  Dictionary<string,DbConnectionInfo> dCon;
    MMConMgr mCon;

    public Form1(){
      InitializeComponent();
      mCon = new MMConMgr();
    }

    private void ReloadTree() {
      tvMain.Nodes.Clear();
      foreach (ConnectionStringSettings sx in ConfigurationManager.ConnectionStrings){
        DbConnectionInfo aCI = new DbConnectionInfo(sx.Name, sx.ConnectionString);
        TreeNode aNode = new TreeNode(sx.Name + ":" + aCI.ServerName, 0, 0);
        TreeNode aTables = new TreeNode("Placeholder", 1, 1);
        aNode.Nodes.Add(aTables);
        tvMain.Nodes.Add(aNode);
      }
    }
    
    private void Form1_Shown(object sender,EventArgs e) {
      ReloadTree();
    }

    private void tvMain_BeforeExpand(object sender,TreeViewCancelEventArgs e) {
      string dbName = "";
      
      switch(e.Node.Level) {
        case 0:   // server Level
          dbName = e.Node.Text.ParseString(":",0);
          e.Node.Nodes.Clear();
          DbConnectionInfo aDBI1 = new DbConnectionInfo(dbName, mCon.GetConnectionStringSetting(dbName).ConnectionString);
          RCData d0 = new RCData(aDBI1);                               
          try {
            DataSet ds1 = d0.GetDataSet("select name db from master.dbo.sysdatabases "+
              "where (dbid > 2) and (not (name in ('model','msdb')))  order by name");

            foreach(DataRow dr in ds1.Tables[0].Rows) {
              string sDB = Convert.ToString(dr["DB"]);
              TreeNode atn = new TreeNode(sDB,1,1);
              atn.Nodes.Add("PlaceHolder");
              e.Node.Nodes.Add(atn);
            }
          } catch(Exception ex) {
            MessageBox.Show("Database failed to connect:"+ex.Message);
            label1.Text = "Edit the App.config in bin folder with connection string.";
          }
        break;
        case 1:  // database Level
          dbName = e.Node.Parent.Text.ParseString(":",0);
          string sdb = e.Node.Text;        ;
          e.Node.Nodes.Clear();
          DbConnectionInfo aDBI2 = new DbConnectionInfo(dbName, mCon.GetConnectionStringSetting(dbName).ConnectionString);
          RCData d1 = new RCData(aDBI2);
          try {

            DataSet ds2 = d1.GetDataSet("select rtrim(so.xtype) ObjType,"
              + $"  OBJECT_SCHEMA_NAME(so.id, DB_ID ('{sdb}'))+'.'+so.name tbl, sc.name col,"
              + "  rtrim(st.name) ColType, sc.length ColLen "
              + "from [" + sdb + "].dbo.sysobjects so "
              + "  left outer join [" + sdb + "].dbo.syscolumns sc on so.id=sc.id "
              + "  left outer join ("
              + "    select Name, min(UserType) UserType, xtype "
              + "    from [" + sdb + "].dbo.systypes "
              + "    Group by Name, xtype ) st on sc.UserType=st.UserType and sc.xtype=st.xtype "
              + "where so.xtype  in ('U','V','P','FN') and (so.Name not like ('dt_%'))"
              + "  and (so.Name not like ('sys%')) and (st.Name is not null)  "
              + "order by so.xtype, so.name, sc.ColOrder  ");

            TreeNode ObjTypeNode = null, ObjItemNode = null;
            string sLastObjType = "";
            string sLastItem = "";
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
              string sObjtype = Convert.ToString(dr["ObjType"]);
              string sItemName = Convert.ToString(dr["tbl"]);
              if ((sObjtype == "P") || (sObjtype == "U") || (sObjtype == "V") || (sObjtype == "FN"))
              {
                if (sLastObjType != sObjtype)
                {
                  ObjTypeNode = new TreeNode(GetObjectTypeNameFromCode(sObjtype), 2, 2);
                  e.Node.Nodes.Add(ObjTypeNode);
                  sLastObjType = sObjtype;
                }
                if ((sLastItem != sItemName) && (ObjTypeNode != null))
                {
                  Int32 iImageIndex = GetImageIndexFromCode(sObjtype);
                  ObjItemNode = new TreeNode(sItemName, iImageIndex, iImageIndex);
                  ObjTypeNode.Nodes.Add(ObjItemNode);
                  sLastItem = sItemName;
                }
                if (ObjItemNode != null)
                {
                  string sVarLen = Convert.ToString(dr["ColLen"]);
                  string sColType = Convert.ToString(dr["Coltype"]);
                  if ((sColType.ToLower() == "varchar") && (sVarLen == "-1")) {
                    sVarLen = "MAX";
                  }
                  string sCol = Convert.ToString(dr["Col"]);
                  ObjItemNode.Nodes.Add(new TreeNode((sColType.Contains("char") ? sCol + " " + sColType + "(" + sVarLen + ")" : sCol + " " + sColType), 7, 7));
                }
              }
            }
          }
          catch (Exception ee) {
            MessageBox.Show(this.Owner, ee.Message, "dbWorkshop Error");
          }
        break;
      }
    }
    
    private void tvMain_AfterSelect(object sender,TreeViewEventArgs e) {
      label1.Text = "Focused Item: "+ e.Node.Text;
      tvMain_OnActiveSelectionChange(e.Node);
      if (e.Node.Level == 0){
        tvMain.ContextMenuStrip = cmsDatabase;
        addConnectionToolStripMenuItem.Enabled = true;
        dropConnectionToolStripMenuItem.Enabled = true;
        editConnectionToolStripMenuItem.Enabled = true;
      }else {
        tvMain.ContextMenuStrip = cmsItem;
     //   addConnectionToolStripMenuItem.Enabled = true;
     //   dropConnectionToolStripMenuItem.Enabled = false;
     //   editConnectionToolStripMenuItem.Enabled = false;
      }
    }

    private void addConnectionToolStripMenuItem_Click(object sender, EventArgs e){
      if (mCon.Edit("")) {
        mCon.Write();
        ReloadTree();
      }
    }

    private void dropConnectionToolStripMenuItem_Click(object sender, EventArgs e){
      string dbName = tvMain.SelectedNode.Text.ParseString(":", 0);
      ConnectionStringSettings aCSS = mCon.GetConnectionStringSetting(dbName);
      ConfigurationManager.ConnectionStrings.Remove(aCSS);
      mCon.Write();
      ReloadTree();
    }

    private void editConnectionToolStripMenuItem_Click(object sender, EventArgs e){
      string dbName = tvMain.SelectedNode.Text.ParseString(":",0);
      ConnectionStringSettings aCSS = mCon.GetConnectionStringSetting(dbName);
      if (mCon.Edit(dbName)) {
        mCon.Write();
        ReloadTree();
      }
    }

    private void button1_Click(object sender,EventArgs e){
            
      byte[] aba = Ionic.Zlib.ZlibStream.CompressString("This is a test of the compress function this is only a test. ");
      string s = aba.toHexStr();
      edScratch.Text = s;
      edScratch.Text = Ionic.Zlib.ZlibStream.UncompressString(s.toByteArray());

//      using(ZipFile zf = new ZipFile())
//      {
//        zf.AddFile(sFileToZip,"");      
//        zf.Save(sFileZipAs);
//      }

    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e) {
      TreeNode sel = tvMain.SelectedNode;
      TreeNode con;
      TreeNode tnDB;
      Int32 iLevel = sel.Level; 
      if (iLevel == 1) {  // add db
        con = sel.Parent;
        tnDB = sel;
      edScratch.Text = con.Text.ParseString(":",0)+"["+con.Text.ParseString(":",1)+"]."+tnDB.Text  + Environment.NewLine + edScratch.Text;
      } else if (iLevel == 2) { // add obj grp
        con = sel.Parent.Parent;
        tnDB = sel.Parent;
      edScratch.Text = con.Text.ParseString(":",0)+"["+con.Text.ParseString(":",1)+"]." + tnDB.Text+"."+sel.Text+ Environment.NewLine + edScratch.Text;
      } else if (iLevel == 3) { // add Obj
        con = sel.Parent.Parent.Parent;
        tnDB = sel.Parent.Parent;
      edScratch.Text = con.Text.ParseString(":",0)+"["+con.Text.ParseString(":",1)+"]." + tnDB.Text+".dbo."+sel.Text+ Environment.NewLine + edScratch.Text;
      } 

    }

   
  }
}
