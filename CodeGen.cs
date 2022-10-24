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
using StaticExtensions;

namespace dbWorkshop {
  public partial class Form1:Form {


    #region On Tree View Active Selection Change 

    public void tvMain_OnActiveSelectionChange(TreeNode focusNode) {
      try { 
      Int32 iCurLevel = focusNode.Level;
      switch(focusNode.ImageIndex) {
        case 0: PrepareServer(focusNode); break;
        case 1: PrepareDatabase(focusNode); break;
        case 2: PrepareFolder(focusNode); break;
        case 3: PrepareTable(focusNode); break;
        case 4: PrepareView(focusNode); break;
        case 5: PrepareStProc(focusNode); break;
        case 6: PrepareFunction(focusNode); break;
      }     
        } catch (Exception ex) { 
          MessageBox.Show(ex.Message);
        }
    }

    public void PrepareServer(TreeNode tnServer) {
      edSQL.Text = "SQL Not Implemented Yet";
      edC.Text = "C# Not Implemented yet ";
      edSQLCursor.Text="Not Implemented see Table or View item on tree.";
      edWiki.Text = "";
    }
    public void PrepareDatabase(TreeNode tnDatabase) {
      edSQL.Text = "SQL Not Implemented Yet";
      edC.Text = "C# Not Implemented yet ";
      edSQLCursor.Text="Not Implemented see Table or View item on tree.";
      edWiki.Text = "";
    }
    public void PrepareFolder(TreeNode tnFolder) {
      edSQL.Text = "SQL Not Implemented Yet";
      edC.Text = "C# Not Implemented yet ";
      edSQLCursor.Text="Not Implemented see Table or View item on tree.";
      edWiki.Text = "";
    }
    public void PrepareFunction(TreeNode tnFunction) {
      edSQL.Text = GetHelpText(tnFunction);
      edC.Text = "C# Not Implemented yet ";
      edSQLCursor.Text="Not Implemented see Table or View item on tree.";
      edWiki.Text = "";
    }
    public void PrepareTable(TreeNode tnTable) {
      TreeNode cn = tnTable;
      String dName = cn.Parent.Parent.Parent.Text.ParseString(":", 0);
      String sDB = cn.Parent.Parent.Text;
      DbConnectionInfo aDBI2 = new DbConnectionInfo(dName, mCon.GetConnectionStringSetting(dName).ConnectionString);
      RCData d1 = new RCData(aDBI2);
      string tblName = cn.Text;
      string sColListb = GetChildColList(cn, true);
      string nl = Environment.NewLine;
      string sFirstCol = "";
      string sKeyType = "", sKey = "";
      if (cn.Nodes.Count > 0) {
        sFirstCol = cn.Nodes[0].Text.ToLower();
        sKey = sFirstCol.ParseString(" ()", 0);
        sKey = sKey.Substring(0,1).ToLower() + sKey.Substring(1, sKey.Length - 1);
        sKeyType = GetDataCTypeBySQLType(sFirstCol.ParseLast(" "));
      }

      edSQL.Text= GetTableCreate(d1, sDB, tblName) + nl + nl +
        $"select {sColListb} from {tblName} "  +nl + nl+
        GetAbout() + GetSQLAddUpdateStoredProc(cn);
      
      string className =tblName.ParseLast(".").toCapFirstLetter();
      string classVarName = className.toLowerFirstLetter(); 
      edC.Text =
         "// C Entity Class "+nl+
        $"public class {className}"+"{"+nl+
        $"  public {tblName.ParseLast(".")}()"+"{}" + nl+
         GetChildColListClass(cn) +
         "  public string ToJson() {"+nl+
         "    return JsonConvert.SerializeObject(this);" + nl +
         "  }" + nl +
         "}" + nl + nl +
        $"// C Dapper Load List of {className}" + nl +
        $"public async Task<ActionResult> {className}IndexAsync()" + "{"+nl+
        $"  IEnumerable<{className}> result;" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" +nl+
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {"+nl+
        $"    result = await connection.QueryAsync<{className}>(\"select {sColListb} from {tblName} \");"+ nl +
         "  }" +nl+        
         "  return Ok(result);"+nl+
         "}"+ nl + nl +

         "// C Dapper Load single Item"+nl+
        $"public async Task<ActionResult> {className}ItemAsync({sKeyType}{sKey})"+"{"+nl+
         "  string connectionString = Settings.GetConnectionString(\"PD\");"+nl+
         "  Values result;" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
         "    var param = new {"+sKey+"};" + nl +
        $"    result = await connection.QueryFirstOrDefaultAsync<{className}>(\"select {sColListb} from {tblName} where {sKey} = @{sKey} \", param);" + nl +
         "  }" + nl +
         "  return Ok($\"{result.ToJson()}\");" + nl +
         "}" + nl + nl +

         "// C Dapper Edit via Add Update stored procdure" + nl +
        $"public async Task<ActionResult> {className}EditAsync({className} {classVarName}) "+"{"+nl+
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
        $"  {className} result;" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        $"    result = await connection.QueryFirstOrDefaultAsync<{className}>(\"dbo.sp_AddUpdate{className}\", {classVarName}, commandType: CommandType.StoredProcedure);" + nl +
         "  }" + nl +
         "  return Ok(result.ToJson());" + nl +
         "}"+ nl + nl +

         "// C Dapper delete via Execute" + nl +
        $"public async Task<ActionResult> {className}DeleteAsync({sKeyType}{sKey})"+"{" + nl +
         "  int result = 0;" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
         "  var param = new {"+$"{sKey}" + "};" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
         "    result = await connection.ExecuteAsync(\"delete from "+$"[{className}] where [{sKey}] = @{sKey} "+ "\", param);" + nl +
         "  }" + nl +
         "  return Ok(result == 1);" + nl +
         "}" + nl +


        nl + nl+
        "// older mmdata based load "+
        "MMData m = new MMData();" +nl+
        "DataSet ds = m.GetDataSet(\"PD\", \"Select " + sColListb +"\" +"+ nl+
        "  \" from " +tblName+ "\");"+nl + 
         GetDeclareVarColList(cn)+

        "foreach(DataRow r in ds.Tables[0].Rows){" +nl 
         + GetAssignChildColList(cn)+nl+
        "} ";
      edSQLCursor.Text=GetSQLCursor(cn);
      edWiki.Text = "";
    }
    public void PrepareView(TreeNode tnView) {
      TreeNode cn = tnView;
      String dName = cn.Parent.Parent.Parent.Text.ParseString(":", 0);
      String sDB = cn.Parent.Parent.Text;      
      string tblName = cn.Text;
      string sColListb = GetChildColList(cn, true);
      string nl = Environment.NewLine;
      string sFirstCol = "";
      string sKeyType = "", sKey = "";
      if (cn.Nodes.Count > 0) {
        sFirstCol = cn.Nodes[0].Text.ToLower();
        sKey = sFirstCol.ParseString(" ()", 0);
        sKey = sKey.Substring(0, 1).ToLower() + sKey.Substring(1, sKey.Length - 1);
        sKeyType = GetDataCTypeBySQLType(sFirstCol.ParseLast(" "));
      }
      string className = tblName.ParseLast(".").toCapFirstLetter();
      string classVarName = className.toLowerFirstLetter();
      edC.Text =
         "// C Entity Class " + nl +
        $"public class {className}" + "{" + nl +
        $"  public {tblName.ParseLast(".")}()" + "{}" + nl +
         GetChildColListClass(cn) +
         "}" + nl + nl +
        $"// C Dapper Load List of {className}" + nl +
        $"public async Task<ActionResult> {className}IndexAsync()" + "{" + nl +
        $"  IEnumerable<{className}> result;" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        $"    result = await connection.QueryAsync<{className}>(\"select {sColListb} from {tblName} \");" + nl +
         "  }" + nl +
         "  return Ok(result);" + nl +
         "}" + nl + nl +

         "// C Dapper Load single Item" + nl +
        $"public async Task<ActionResult> {className}ItemAsync({sKeyType}{sKey})" + "{" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
         "  Values result;" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
         "    var param = new {" + sKey + "};" + nl +
        $"    result = await connection.QueryFirstOrDefaultAsync<{className}>(\"select {sColListb} from {tblName} where {sKey} = @{sKey} \", param);" + nl +
         "  }" + nl +
         "  return Ok($\"{result.ToJson()}\");" + nl +
         "}" + nl + nl +

         "// C Dapper Edit via Add Update stored procdure" + nl +
        $"public async Task<ActionResult> {className}EditAsync({className} {classVarName}) " + "{" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
        $"  {className} result;" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        $"    result = await connection.QueryFirstOrDefaultAsync<{className}>(\"dbo.sp_AddUpdate{className}\", {classVarName}, commandType: CommandType.StoredProcedure);" + nl +
         "  }" + nl +
         "  return Ok(result.ToJson());" + nl +
         "}" + nl + nl +

         "// C Dapper delete via Execute" + nl +
        $"public async Task<ActionResult> {className}DeleteAsync({sKeyType}{sKey})" + "{" + nl +
         "  int result = 0;" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
         "  var param = new {" + $"{sKey}" + "};" + nl +
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
         "    result = await connection.ExecuteAsync(\"delete from " + $"[{className}] where [{sKey}] = @{sKey} " + "\", param);" + nl +
         "  }" + nl +
         "  return Ok(result == 1);" + nl +
         "}" + nl +


        nl + nl +
        "// older mmdata based load " +
        "MMData m = new MMData();" + nl +
        "DataSet ds = m.GetDataSet(\"PD\", \"Select " + sColListb + "\" +" + nl +
        "  \" from " + tblName + "\");" + nl +
         GetDeclareVarColList(cn) +

        "foreach(DataRow r in ds.Tables[0].Rows){" + nl
         + GetAssignChildColList(cn) + nl +
        "} ";

      edSQL.Text=GetHelpText(tnView);              
      edSQLCursor.Text =GetSQLCursor(tnView);
      edWiki.Text = "";
    }
    public void PrepareStProc(TreeNode tnStProc) {
      TreeNode cn = tnStProc;
      string tblName = cn.Text;
      string nl = Environment.NewLine;
      string sFirstCol = "";
      string sKeyType = "", sKey = "";
      if (cn.Nodes.Count > 0) {
        sFirstCol = cn.Nodes[0].Text.ToLower();
        sKey = sFirstCol.ParseString(" ()", 0);
        sKey = sKey.Substring(0, 1).ToLower() + sKey.Substring(1, sKey.Length - 1);
        sKeyType = GetDataCTypeBySQLType(sFirstCol.ParseLast(" "));
      }
      string className = tblName.ParseLast(".").toCapFirstLetter();
      string classVarName = className.toLowerFirstLetter();


      string sDBName = tnStProc.Parent.Parent.Parent.Text.ParseString(":",0);
      string a = "";
      string b = "";
      string c = "";
      for(Int32 i = 0;i < tnStProc.Nodes.Count;i++) {
        if(a == "") {
          a = tnStProc.Nodes[i].Text.ParseString(" ",0);          
        } else {
          a = a + ", " + tnStProc.Nodes[i].Text.ParseString(" ",0);
        }
        
        c = c + nl+ $"  {GetDataCTypeBySQLType(cn.Nodes[i].Text.ParseLast(" "))}{tnStProc.Nodes[i].Text.ParseFirst(" @").toLowerFirstLetter()} = {SQLDefNullValue(cn.Nodes[i].Text.ParseLast(" "))};";
      }
      b=a;
      string s = "";

      Int32 iCount = tnStProc.Nodes.Count;
      String sCSharpDeclareVar = "";
      for(Int32 i = 0;i < iCount;i++) {
        a = tnStProc.Nodes[i].Text.ParseString(" @",0);
        string t = SQLColumnToParamDBType(tnStProc.Nodes[i].Text);
        sCSharpDeclareVar += "  "+t+" "+a+" = "+SQLDefNullValue(tnStProc.Nodes[i].Text.ParseString(" ", 1))+";"+Environment.NewLine;
        if(i == 0) {
          s = s + "    new StProcParam(\"@" + a + "\", DbType." + t + ", " + a + ")";
        } else {
          s = s + "," + Environment.NewLine + "    new StProcParam(\"@" + a + "\", DbType." + t + ", " + a + ")";
        }
      }
      s ="// C Dapper Edit via Add Update stored procdure" + nl +
        $"public async Task<ActionResult> Exec{className}Async() " + "{" + nl +
         "  string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
        $"  {className}Result result;" + nl + c + nl + 
         "  var params = new {"+$"{b.RemoveChar('@')}"+"};"+nl+
         "  using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        $"    result = await connection.QueryAsync<{className}Result>(\"{tnStProc.Text.ParseFirst(" ")}\", params, commandType: CommandType.StoredProcedure);" + nl +
         "  }" + nl +
         "  return Ok(result.ToJson());" + nl +
         "}" + nl + nl +


        "//MMData from C0DEC0RE Library  " + Environment.NewLine +
        "  MMData d = new MMData();" + Environment.NewLine +
        sCSharpDeclareVar+
        "  DataSet Log = d.GetStProcDataSet(\""+sDBName+"\", \"exec " + tnStProc.Text + " " + b + "\", " + Environment.NewLine +
        "    new StProcParam[] {" + Environment.NewLine + 
        s + Environment.NewLine + "  });";

      edSQL.Text = GetHelpText(tnStProc);
      edC.Text =  s;
      edSQLCursor.Text="Not Implemented see Table or View item on tree.";
      edWiki.Text = "";
    }

    #endregion 

    public string GetSQLAddUpdateStoredProc(TreeNode tnTable) {
      TreeNode cn = tnTable;      
      string nl = Environment.NewLine;
      string tblName = tnTable.Text;
      string sSQLParam1 = GetSQLParamList1(tnTable);
      string sSQLParamCall = GetSQLParamCallList(tnTable);
      string sColList = GetChildColList(tnTable, false);      
      string sAssignColSQL = GetAssignChildSQLColList(tnTable);
      string sFirstCol = "";
      string sKeyType = "", sKey = "";
      if (tnTable.Nodes.Count > 0) {
        sFirstCol = tnTable.Nodes[0].Text.ToLower();
        sKey = "["+sFirstCol.ParseString(" ()", 0)+"]";
        sKeyType = sFirstCol.ParseString(" ()", 1);
        if (sKeyType.Contains("char")) {
          sKeyType = sKeyType + "(" + sFirstCol.ParseString(" ()", 2) + ")";
        }
      }
      string sUpdateDefWhere = sKey + " = @a";
      return  
        "-- Add Update SQL Stored Proc for " + tblName + "" + nl +
        "Create Procedure dbo.sp_AddUpdate" + tblName.ParseLast(".") +
        " (" + nl + "  " + sSQLParam1 + nl + ") as " + nl +
        "  set nocount on " + nl +
        "  declare @a " + sKeyType + " set @a = isnull((select " + sKey + " from " + tblName + 
          " where (" + sKey + " = @" + sKey + ")), " + SQLDefNullValue(sKeyType) + ")  " + nl +
        "  if (@a = " + SQLDefNullValue(sKeyType) + ") begin" + nl +
        "    Insert into " + cn.Text + " (" + nl + 
        "      " + sColList + nl +
        "    ) values (" + nl + "      " + sSQLParamCall + ")" + nl +
        "    set @a = @@Identity " + nl +
        "  end else begin" + nl +
        "    Update " + tblName + 
             " set" + nl + sAssignColSQL + nl + 
          "    where " + sUpdateDefWhere + nl +
        "  end" + nl +
        "  select @a " + sKey + nl + "return";
        
       
    }
    public string GetSQLCursor(TreeNode tnTable) {     
      string sSQLDeclareList = GetSQLDeclareVarColList(tnTable);
      string sSQLColumnList = GetChildColListAll(tnTable);
      string sSQLColumnVarList = GetSQLColumnVarList(tnTable);
      return "--  SQL Stored Proc "+tnTable.Text+" Cursor iterate stub "+Environment.NewLine+
        GetAbout()+
        "Create Procedure dbo.spForeach"+tnTable.Text.ParseLast(".")+"Do () as begin "+Environment.NewLine+
           sSQLDeclareList+Environment.NewLine+
        "  declare aCur cursor local fast_forward for "+Environment.NewLine+
        "  select "+sSQLColumnList+Environment.NewLine+
        "    from "+tnTable.Text+Environment.NewLine+
        "  open aCur fetch aCur into "+Environment.NewLine+
        "    "+sSQLColumnVarList+Environment.NewLine+
        "  while @@fetch_status = 0 begin "+Environment.NewLine+
        "    "+Environment.NewLine+
        "    "+Environment.NewLine+
        "    fetch aCur into "+Environment.NewLine+
        "      "+sSQLColumnVarList+Environment.NewLine+
        "  end"+Environment.NewLine+
        "  close aCur"+Environment.NewLine+
        "  deallocate aCur"+Environment.NewLine+
        "end"+ Environment.NewLine;     
    }

    public string GetSQLParamList1(TreeNode cn) {
      string sRes = "";
      foreach(TreeNode tn in cn.Nodes) {
        if(sRes == "") {
          sRes = "@" + tn.Text;
        } else {
          sRes = sRes + "," + Environment.NewLine + "  @" + tn.Text;
        }
      }
      return sRes;
    }

    public string SQLDefNullValue(string sqlKeyType) {
      string w = sqlKeyType.ToLower().ParseString(" ()",0);
      string result = "";
      if(w == "char") result = "\"\"";
      else if(w == "varchar") result = "\"\"";
      else if(w == "int") result = "0";
      else if(w == "bigint") result = "0";
      else if(w == "binary") result = "null";
      else if(w == "bit") result = "0";
      else if(w == "datetime") result = "null";
      else if(w == "decimal") result = "0.0";
      else if(w == "float") result = "0.0";
      else if(w == "image") result = "null";
      else if(w == "money") result = "0.0";
      else if(w == "numeric") result = "0.0";
      else if(w == "nchar") result = "\"\"";
      else if(w == "ntext") result = "\"\"";
      else if(w == "nvarchar") result = "\"\"";
      else if(w == "real") result = "0.0";
      else if(w == "smallint") result = "0";
      else if(w == "smallmoney") result = "0.0";
      else if(w == "smalldatetime") result = "null";
      else if(w == "text") result = "\"\"";
      else if(w == "timestamp") result = "null";
      else if(w == "tinyint") result = "0";
      else if(w == "uniqueidentifier") result = "\"\"";
      else if(w == "varbinary") result = "null";
      return result;
    }
    public string GetDataCastBySQLType(string sType) {      
      string w = sType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = ".toString()";
      else if (w == "varchar") result = ".toString()";
      else if (w == "int") result = ".toInt32()";
      else if (w == "bigint") result = ".toInt64()";
      else if (w == "binary") result = "";
      else if (w == "bit") result = ".toInt32()";
      else if (w == "datetime") result = ".toDateTime()";
      else if (w == "decimal") result = ".toDouble()";
      else if (w == "float") result = ".toDouble()";
      else if (w == "image") result = "";
      else if (w == "money") result = ".toDouble()";
      else if (w == "numeric") result = ".toDouble()";
      else if (w == "nchar") result = "";
      else if (w == "ntext") result = ".toString()";
      else if (w == "nvarchar") result = ".toString()";
      else if (w == "real") result = ".toDouble()";
      else if (w == "smallint") result = ".toInt32()";
      else if (w == "smallmoney") result = ".toDouble()";
      else if (w == "smalldatetime") result = ".toDateTime()";
      else if (w == "text") result = ".toString()";
      else if (w == "timestamp") result = ".toDateTime()";
      else if (w == "tinyint") result = ".toInt32()";
      else if (w == "uniqueidentifier") result = ".toString()";
      else if (w == "varbinary") result = "";
      return result;
    }
    public string GetDataCTypeBySQLType(string sType) {
      string w = sType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = "String ";
      else if (w == "varchar") result = "String ";
      else if (w == "int") result = "Int32 ";
      else if (w == "bigint") result = "Int64 ";
      else if (w == "binary") result = "";
      else if (w == "bit") result = "Int32";
      else if (w == "datetime") result = "DateTime";
      else if (w == "decimal") result = "Double";
      else if (w == "float") result = "Double";
      else if (w == "image") result = "";
      else if (w == "money") result = "Double";
      else if (w == "numeric") result = "Double";
      else if (w == "nchar") result = "";
      else if (w == "ntext") result = "String";
      else if (w == "nvarchar") result = "String";
      else if (w == "real") result = "Double";
      else if (w == "smallint") result = "Int32";
      else if (w == "smallmoney") result = "Double";
      else if (w == "smalldatetime") result = "DateTime";
      else if (w == "text") result = "String";
      else if (w == "timestamp") result = "DateTime";
      else if (w == "tinyint") result = "Int32";
      else if (w == "uniqueidentifier") result = "String";
      else if (w == "varbinary") result = "";
      return result;
    }

    public string GetChildColList(TreeNode cn, Boolean IncludeKeyField) {
      string sRes = ""; string sFTT = (IncludeKeyField?"false":"true");
      foreach(TreeNode tn in cn.Nodes) {
        if(sFTT == "true") {
          sFTT = "false";  // don't include the first Keyfield.
        } else {
          if(sRes == "") {
            sRes = "["+tn.Text.ParseString(" ()",0)+"]";
          } else {
            sRes = sRes + ", [" + tn.Text.ParseString(" ()",0)+"]";
          }
        }
      }
      return sRes;
    }
    public string GetChildColListAll(TreeNode cn){
      string sRes = ""; 
      foreach(TreeNode tn in cn.Nodes){       
        if(sRes=="") {
          sRes="["+tn.Text.ParseString(" ()",0)+"]";
        } else {
          sRes=sRes+", ["+tn.Text.ParseString(" ()",0)+"]";
        }      
      }
      return sRes;
    }

    public string GetChildColListClass(TreeNode cn) {
      string sRes = ""; 
      string nl = Environment.NewLine;
      foreach (TreeNode tn in cn.Nodes) {        
        string scol = tn.Text.ParseFirst(" ");
        scol = scol.Substring(0,1).ToUpper()+scol.Substring(1);
        sRes = sRes +$"  public {GetDataCTypeBySQLType(tn.Text.ParseLast(" "))}{scol}" + "{get; set;} = "+ SQLDefNullValue(tn.Text.ParseLast(" "))+nl;
      }
      return sRes;
    }


    public string GetSQLParamCallList(TreeNode cn) {
      string sRes = ""; string sFTT = "true";
      foreach(TreeNode tn in cn.Nodes) {
        if(sFTT == "true") {
          sFTT = "false";
        } else {
          if(sRes == "") {
            sRes = "@" + tn.Text.ParseString(" ()",0);
          } else {
            sRes = sRes + ", @" + tn.Text.ParseString(" ()",0);
          }
        }
      }
      return sRes;
    }
    public string GetSQLDeclareVarColList(TreeNode rn) {
      string sReturn = "";
      foreach (TreeNode cn in rn.Nodes) {        
        if (sReturn == ""){
          sReturn= "  Declare @"+cn.Text.ParseString(" ",0)+" "+cn.Text.ParseString(" ",1);
        } else {
          sReturn=sReturn + Environment.NewLine + "  Declare @"+cn.Text.ParseString(" ",0)+" "+cn.Text.ParseString(" ",1);          
        }
      }
      return sReturn;
    }
    public string GetDeclareVarColList(TreeNode rn) {
      string sReturn = "";
      foreach (TreeNode cn in rn.Nodes) {
        string sColType = cn.Text.ParseString(" ()", 1);        
        sReturn = sReturn + GetDataCTypeBySQLType(sColType) + " " + cn.Text.ParseString(" ", 0) + " = " + SQLDefNullValue(sColType) + ";"+ Environment.NewLine + "";        
      }
      return sReturn;
    }
    public string GetSQLColumnVarList(TreeNode rn){
      string sReturn = "";
      foreach(TreeNode cn in rn.Nodes){
        if(sReturn==""){
          sReturn="@"+cn.Text.ParseString(" ",0);
        } else {
          sReturn=sReturn+", @"+cn.Text.ParseString(" ",0);
        }
      }
      return sReturn;
    }    
    public string GetAssignChildSQLColList(TreeNode cn) {
      string sRes = ""; string sFTT = "true";
      foreach(TreeNode tn in cn.Nodes) {
        string sCurCol = tn.Text.ParseString(" ()",0);
        if(sFTT == "true") {
          sFTT = "false";
        } else {
          if(sRes == "") {
            sRes = "      [" + sCurCol + "] = @" + sCurCol;
          } else {
            sRes = sRes + "," + Environment.NewLine + "      [" + sCurCol + "] = @" + sCurCol;
          }
        }
      }
      return sRes;
    }
    public string GetAssignChildColList(TreeNode cn) {
      string sRes = ""; 
      foreach (TreeNode tn in cn.Nodes) {
        string sCurCol = tn.Text.ParseString(" ()", 0);
        string sColType = tn.Text.ParseString(" ()", 1);        
        if (sRes == "") {
          sRes = "  " + sCurCol + " = r[\""+ sCurCol + "\"]" + GetDataCastBySQLType(sColType)+";";
        } else {
          sRes = sRes + Environment.NewLine + "  " + sCurCol + " = r[\"" + sCurCol + "\"]" + GetDataCastBySQLType(sColType)+";";
        }        
      }
      return sRes;
    }
    public string GetHelpText(TreeNode cn) { // expecting a Function or Procedure as cn. 
      string sDBName = cn.Parent.Parent.Parent.Text.ParseString(":",0);
      string sDatabase = cn.Parent.Parent.Text;
      string sResult = "";
      MMData d = new MMData();
      try {
        DataSet ds = d.GetStProcDataSet(sDBName,"exec "+sDatabase+".sys.sp_helptext @aObjName",new StProcParam[] { new StProcParam("@aObjName",DbType.String,cn.Text) });
        if(ds.Tables.Count > 0) {
          foreach(DataRow dr in ds.Tables[0].Rows) {
            sResult = sResult + Convert.ToString(dr["Text"]);
          }
        }
      } catch(Exception e) {
        sResult = "Error while accessing sp_HelpText, "+e.Message;
      }
      
      return sResult;
    }

    public string GetObjectTypeNameFromCode(string aCode) {
      string s = aCode;
      string sResult = "";
      if(aCode == "P") {
        sResult = "Procedures";
      } else if(aCode == "U") {
        sResult = "Tables";
      } else if(aCode == "V") {
        sResult = "Views";
      } else if(aCode == "FN") {
        sResult = ("Functions");
      }
      return sResult;
    }
    public Int32 GetImageIndexFromCode(string aCode) {
      string s = aCode;
      Int32 sResult = 0;
      if(aCode == "S") {
        sResult = 0;
      } else if(aCode == "D") {
        sResult = 1;
      } else if(aCode == "F") {
        sResult = 2;
      } else if(aCode == "U") {
        sResult = 3;
      } else if(aCode == "V") {
        sResult = 4;
      } else if(aCode == "P") {
        sResult = 5;
      } else if(aCode == "FN") {
        sResult = 6;
      }
      return sResult;
    }

    public string SQLColumnToParamDBType(string s) {
      string sresult = "";
      string w = s.ToLower().ParseString(" ()",1);
      if(w == "char") { sresult = "AnsiString";
      } else if(w == "varchar") { sresult = "String";
      } else if(w == "int") { sresult = "Int32";
      } else if(w == "bigint") { sresult = "Int64";
      } else if(w == "binary") { sresult = "Binary";
      } else if(w == "bit") { sresult = "Boolean";
      } else if(w == "datetime") { sresult = "DateTime";
      } else if(w == "decimal") { sresult = "Double";
      } else if(w == "float") { sresult = "Double";
      } else if(w == "image") { sresult = "Binary";
      } else if(w == "money") { sresult = "Double";
      } else if(w == "numeric") { sresult = "Double";
      } else if(w == "nchar") { sresult = "AnsiString";
      } else if(w == "ntext") { sresult = "AnsiString";
      } else if(w == "nvarchar") { sresult = "AnsiString";
      } else if(w == "real") { sresult = "Decimal";
      } else if(w == "smallint") { sresult = "Int16";
      } else if(w == "smallmoney") { sresult = "Double";
      } else if(w == "smalldatetime") { sresult = "DateTime";
      } else if(w == "text") { sresult = "AnsiString";
      } else if(w == "timestamp") { sresult = "DateTime";
      } else if(w == "tinyint") { sresult = "Byte";
      } else if(w == "uniqueidentifier") { sresult = "Guid";
      } else if(w == "varbinary") { sresult = "Binary";
      }
      return sresult;
    }

    public string GetAbout() {
      return "-- Generated on " + DateTime.Now.toStrDate() + " via dbWorkshop " + Environment.NewLine;
    }

    public string GetTableCreate(RCData d, string sDB, string sTableName){ 
      string sResult = "";      
      d.CI.InitialCatalog = sDB;
      DataSet ds = d.GetDataSet(
        "DECLARE @object_name SYSNAME, @object_id INT, @SQL NVARCHAR(MAX)"+Environment.NewLine+
       $"  SELECT  @object_name = '[' + OBJECT_SCHEMA_NAME(o.[object_id], DB_ID ('{sDB}')) + '].[' + OBJECT_NAME([object_id], DB_ID ('{sDB}')) + ']', " + Environment.NewLine+
        "    @object_id = [object_id] FROM ( SELECT [object_id] = OBJECT_ID('"+sDB+"."+sTableName+"', 'U') ) o  "+Environment.NewLine+
        "  SELECT @SQL = 'CREATE TABLE ' + @object_name + '(' + CHAR(13) + CHAR(10) + "+Environment.NewLine+
        "    STUFF((SELECT CHAR(13) + CHAR(10) +  '  ,[' + c.name + '] ' +   "+Environment.NewLine+
        "      CASE WHEN c.is_computed = 1 "+Environment.NewLine+
        "        THEN 'AS ' + OBJECT_DEFINITION(c.[object_id], c.column_id)  "+Environment.NewLine+
        "        ELSE   "+Environment.NewLine+
        "          CASE WHEN c.system_type_id != c.user_type_id   "+Environment.NewLine+
        "            THEN '[' + SCHEMA_NAME(tp.[schema_id]) + '].[' + tp.name + ']'   "+Environment.NewLine+
        "            ELSE '[' + UPPER(tp.name) + ']'   "+Environment.NewLine+
        "          END  +   "+Environment.NewLine+
        "          CASE "+Environment.NewLine+
        "            WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary') THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length AS VARCHAR(5)) END + ')'  "+Environment.NewLine+
        "            WHEN tp.name IN ('nvarchar', 'nchar') THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length / 2 AS VARCHAR(5)) END + ')'  "+Environment.NewLine+
        "            WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset') THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'  "+Environment.NewLine+
        "            WHEN tp.name = 'decimal' THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'  "+Environment.NewLine+
        "            ELSE '' "+Environment.NewLine+
        "          END +  "+Environment.NewLine+
  //      "          CASE WHEN c.collation_name IS NOT NULL AND c.system_type_id = c.user_type_id   "+Environment.NewLine+
  //      "            THEN ' COLLATE ' + c.collation_name ELSE '' END +  "+Environment.NewLine+
        "              CASE WHEN c.is_nullable = 1 THEN ' NULL' ELSE ' NOT NULL' END +  "+Environment.NewLine+
        "              CASE WHEN c.default_object_id != 0   "+Environment.NewLine+
        "                THEN ' CONSTRAINT [' + OBJECT_NAME(c.default_object_id) + '] DEFAULT ' + OBJECT_DEFINITION(c.default_object_id)  "+Environment.NewLine+
        "                ELSE ''  "+Environment.NewLine+
        "              END +   "+Environment.NewLine+
        "              CASE WHEN cc.[object_id] IS NOT NULL   "+Environment.NewLine+
        "                THEN ' CONSTRAINT [' + cc.name + '] CHECK ' + cc.[definition]  "+Environment.NewLine+
        "                ELSE ''  "+Environment.NewLine+
        "              END +  "+Environment.NewLine+
        "              CASE WHEN c.is_identity = 1  "+Environment.NewLine+ 
        "                THEN ' IDENTITY(' + CAST(IDENTITYPROPERTY(c.[object_id], 'SeedValue') AS VARCHAR(50)) + ',' +   "+Environment.NewLine+
        "                  CAST(IDENTITYPROPERTY(c.[object_id], 'IncrementValue') AS VARCHAR(50)) + ')'   "+Environment.NewLine+
        "                ELSE ''   "+Environment.NewLine+
        "              END   "+Environment.NewLine+
        "          END  "+Environment.NewLine+
        "      FROM sys.columns c WITH(NOLOCK) "+Environment.NewLine+ 
        "        JOIN sys.types tp WITH(NOLOCK) ON c.user_type_id = tp.user_type_id  "+Environment.NewLine+
        "        LEFT JOIN sys.check_constraints cc WITH(NOLOCK) ON c.[object_id] = cc.parent_object_id AND cc.parent_column_id = c.column_id  "+Environment.NewLine+
        "      WHERE c.[object_id] = @object_id  "+Environment.NewLine+
        "      ORDER BY c.column_id  "+Environment.NewLine+
        "      FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 5, '   ') +   "+Environment.NewLine+
        "      ISNULL((SELECT CHAR(13) + CHAR(10) + '  ,CONSTRAINT [' + i.name + '] PRIMARY KEY ' +   "+Environment.NewLine+
        "      CASE WHEN i.index_id = 1 THEN 'CLUSTERED' ELSE 'NONCLUSTERED' END +"+Environment.NewLine+
        "      ' (' + ( SELECT STUFF(CAST((SELECT ', [' + COL_NAME(ic.[object_id], ic.column_id) + ']' +"+Environment.NewLine+  
        "                  CASE WHEN ic.is_descending_key = 1 THEN ' DESC' ELSE '' END  "+Environment.NewLine+
        "          FROM sys.index_columns ic WITH(NOLOCK)  "+Environment.NewLine+
        "          WHERE i.[object_id] = ic.[object_id]  "+Environment.NewLine+
        "              AND i.index_id = ic.index_id  "+Environment.NewLine+
        "          FOR XML PATH(N''), TYPE) AS NVARCHAR(MAX)), 1, 2, '')) + ')'  "+Environment.NewLine+
        "      FROM sys.indexes i WITH(NOLOCK)  "+Environment.NewLine+
        "      WHERE i.[object_id] = @object_id AND i.is_primary_key = 1), '') + CHAR(13) + CHAR(10) +  ')'    "+Environment.NewLine+
        " select @SQL sOut " );     
        if (ds.hasFirstRow()){ 
          sResult = ds.toFirstRow()["sOut"].toString();
        }
      return sResult;
    }  

  }
}
