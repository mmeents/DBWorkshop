using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticExtensions;

namespace DBWorkshop {
  public static class AppStatic {
    public static Int32 GetImageIndexFromCode(string ObjectType) {      
      Int32 sResult = 0;
      if (ObjectType == "Server") { sResult = 0; } 
      else if (ObjectType == "Database") { sResult = 1; } 
      else if (ObjectType == "Folder") {   sResult = 2; } 
      else if (ObjectType == "Table") {    sResult = 3; } 
      else if (ObjectType == "View") {     sResult = 4; } 
      else if (ObjectType == "Procedure"){ sResult = 5; } 
      else if (ObjectType == "Function") { sResult = 6; }
      return sResult;
    }

  }

  public static class CodeStatic {
    public static string SQLDefNullValue(string sqlType) {
      string w = sqlType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = "\"\"";
      else if (w == "varchar") result = "\"\"";
      else if (w == "int") result = "0";
      else if (w == "bigint") result = "0";
      else if (w == "binary") result = "null";
      else if (w == "bit") result = "0";
      else if (w == "datetime") result = "null";
      else if (w == "decimal") result = "0.0";
      else if (w == "float") result = "0.0";
      else if (w == "image") result = "null";
      else if (w == "money") result = "0.0";
      else if (w == "numeric") result = "0.0";
      else if (w == "nchar") result = "\"\"";
      else if (w == "ntext") result = "\"\"";
      else if (w == "nvarchar") result = "\"\"";
      else if (w == "real") result = "0.0";
      else if (w == "smallint") result = "0";
      else if (w == "smallmoney") result = "0.0";
      else if (w == "smalldatetime") result = "null";
      else if (w == "text") result = "\"\"";
      else if (w == "timestamp") result = "null";
      else if (w == "tinyint") result = "0";
      else if (w == "uniqueidentifier") result = "\"\"";
      else if (w == "varbinary") result = "null";
      return result;
    }
    public static string GetSQLParamList(this TreeNode tnTable) {
      string sRes = "";
      foreach (TreeNode tnColumn in tnTable.Nodes) {
        if (sRes == "") {
          sRes = "@" + tnColumn.Text;
        } else {
          sRes = sRes + "," + Environment.NewLine + "  @" + tnColumn.Text;
        }
      }
      return sRes;
    }
    public static string GetSQLInsertListAsSQLParam(this TreeNode tnTable) {
      string sRes = ""; string sFTT = "true";
      foreach (TreeNode tn in tnTable.Nodes) {
        if (sFTT == "true") {
          sFTT = "false";
        } else {
          if (sRes == "") {
            sRes = "@" + tn.Text.ParseString(" ()", 0);
          } else {
            sRes = sRes + ", @" + tn.Text.ParseString(" ()", 0);
          }
        }
      }
      return sRes;
    }
    public static string GetSQLColumnList(this TreeNode tnTable, Boolean IncludeKeyField) {
      string sRes = ""; string sFTT = (IncludeKeyField ? "false" : "true");
      foreach (TreeNode tn in tnTable.Nodes) {
        if (sFTT == "true") {
          sFTT = "false";  // don't include the first Keyfield.
        } else {
          if (sRes == "") {
            sRes = "[" + tn.Text.ParseString(" ()", 0) + "]";
          } else {
            sRes = sRes + ", [" + tn.Text.ParseString(" ()", 0) + "]";
          }
        }
      }
      return sRes;
    }
    public static string GetAssignChildSQLColList(this TreeNode tnTable) {
      string sRes = ""; string sFTT = "true";
      foreach (TreeNode tn in tnTable.Nodes) {
        string sCurCol = tn.Text.ParseString(" ()", 0);
        if (sFTT == "true") {
          sFTT = "false";
        } else {
          if (sRes == "") {
            sRes = "      [" + sCurCol + "] = @" + sCurCol;
          } else {
            sRes = sRes + "," + Environment.NewLine + "      [" + sCurCol + "] = @" + sCurCol;
          }
        }
      }
      return sRes;
    }
    public static string GenerateSQLAddUpdateStoredProc(this TreeNode tnTable) {
      TreeNode cn = tnTable;
      string nl = Environment.NewLine;
      string tblName = tnTable.Text;
      string sSQLParam1 = tnTable.GetSQLParamList();
      string sInsertListAsSQlParams = tnTable.GetSQLInsertListAsSQLParam();
      string sColList = tnTable.GetSQLColumnList(false);
      string sAssignColSQL = GetAssignChildSQLColList(tnTable);
      string sFirstCol;
      string sKeyType = "", sKey = "";
      if (tnTable.Nodes.Count > 0) {
        sFirstCol = tnTable.Nodes[0].Text.ToLower();
        sKey = "[" + sFirstCol.ParseString(" ()", 0) + "]";
        sKeyType = sFirstCol.ParseString(" ()", 1);
        if (sKeyType.Contains("char")) {
          sKeyType = sKeyType + "(" + sFirstCol.ParseString(" ()", 2) + ")";
        }
      }
      string sUpdateDefWhere = sKey + " = @a";
      string sDefNullValue = SQLDefNullValue(sKeyType);
      return
        "-- Add Update SQL Stored Proc for " + tblName + "" + nl +
        "Create Procedure dbo.sp_AddUpdate" + tblName.ParseLast(".") +
        " (" + nl + "  " + sSQLParam1 + nl + ") as " + nl +
        "  set nocount on " + nl +
        "  declare @a " + sKeyType + " set @a = isnull((select " + sKey + " from " + tblName +
          " where (" + sKey + " = @" + sKey + ")), " + sDefNullValue + ")  " + nl +
        "  if (@a = " + sDefNullValue + ") begin" + nl +
        "    Insert into " + cn.Text + " (" + nl +
        "      " + sColList + nl +
        "    ) values (" + nl + "      " + sInsertListAsSQlParams + ")" + nl +
        "    set @a = @@Identity " + nl +
        "  end else begin" + nl +
        "    Update " + tblName +
             " set" + nl + sAssignColSQL + nl +
          "    where " + sUpdateDefWhere + nl +
        "  end" + nl +
        "  select @a " + sKey + nl + "return";


    }

    public static string GetCTypeFromSQLType(string sqlType) {
      string w = sqlType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = "string ";
      else if (w == "varchar") result = "string";
      else if (w == "int") result = "int";
      else if (w == "bigint") result = "long";
      else if (w == "binary") result = "byte";
      else if (w == "bit") result = "bool";
      else if (w == "datetime") result = "DateTime";
      else if (w == "decimal") result = "decimal";
      else if (w == "float") result = "float";
      else if (w == "image") result = "Image";
      else if (w == "money") result = "decimal";
      else if (w == "numeric") result = "decimal";
      else if (w == "nchar") result = "byte";
      else if (w == "ntext") result = "string";
      else if (w == "nvarchar") result = "string";
      else if (w == "real") result = "decimal";
      else if (w == "smallint") result = "short";
      else if (w == "smallmoney") result = "decimal";
      else if (w == "smalldatetime") result = "DateTime";
      else if (w == "text") result = "string";
      else if (w == "timestamp") result = "DateTime";
      else if (w == "tinyint") result = "short";
      else if (w == "uniqueidentifier") result = "string";
      else if (w == "varbinary") result = "byte";
      return result;
    }
    public static string GetCSharpColAsProps(this TreeNode cn) {
      string sRes = "";
      string nl = Environment.NewLine;
      foreach (TreeNode tn in cn.Nodes) {
        string scol = tn.Text.ParseFirst(" ");
        scol = scol[..1].ToUpper() + scol[1..];
        sRes = sRes + $"    public {GetCTypeFromSQLType(tn.Text.ParseLast(" "))} {scol}" + "{get; set;} = " + SQLDefNullValue(tn.Text.ParseLast(" ")) + nl;
      }
      return sRes;
    }
    public static string GenerateCSharpRepoLikeClassFromTable(this TreeNode tnTable) {
      TreeNode cn = tnTable;      
      string tblName = cn.Text;
      String sDB = cn.Parent.Parent.Text;
      string sColListb = cn.GetSQLColumnList(true);
      string nl = Environment.NewLine;
      string sFirstCol;
      string sKeyType = "", sKey = "";
      if (cn.Nodes.Count > 0) {
        sFirstCol = cn.Nodes[0].Text;
        sKey = sFirstCol.ParseString(" ()", 0).AsLowerCaseFirstLetter();        
        sKeyType = GetCTypeFromSQLType(sFirstCol.ParseLast(" ").ToLower());
      }      
      string className = tblName.ParseLast(".").AsUpperCaseFirstLetter();
      string classVarName = className.AsLowerCaseFirstLetter();
      return
        "using Dapper;  // data io is based on Dapper." + nl +
        "using StaticExtensions;  // see StaticExtensions in nuget." + nl + nl +
       $"namespace {sDB}"+"{" + nl + nl +
        "  // C Entity Class " + nl +
       $"  public class {className}" + "{" + nl +
       $"    public {tblName.ParseLast(".")}()" + "{}" + nl +
               cn.GetCSharpColAsProps() +
        "  }" + nl + nl +
       $"  public class {className}Repository" + "{" + nl +
       $"    // C Dapper Load List of {className}" + nl +
       $"    public async Task<ActionResult> {className}IndexAsync()" + "{" + nl +
       $"      IEnumerable<{className}> result;" + nl +
        "      string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
       $"        result = await connection.QueryAsync<{className}>(\"select {sColListb} from {tblName} \");" + nl +
        "      }" + nl +
        "      return Ok(result);" + nl +
        "    }" + nl + nl +
        "    // C Dapper Load single Item" + nl +
       $"    public async Task<ActionResult> {className}ItemAsync({sKeyType} {sKey})" + "{" + nl +
        "      string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
       $"      {className} result;" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        "        var param = new {" + sKey + "};" + nl +
       $"        result = await connection.QueryFirstOrDefaultAsync<{className}>(\"select {sColListb} from {tblName} where {sKey} = @{sKey} \", param);" + nl +
        "      }" + nl +
        "      return Ok($\"{result.AsJson()}\");" + nl +
        "    }" + nl + nl +
        "    // C Dapper Edit via Add Update stored procdure" + nl +
       $"    public async Task<ActionResult> {className}EditAsync({className} {classVarName}) " + "{" + nl +
        "      string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
       $"      {className} result;" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
       $"        result = await connection.QueryFirstOrDefaultAsync<{className}>(\"dbo.sp_AddUpdate{className}\", {classVarName}, commandType: CommandType.StoredProcedure);" + nl +
        "      }" + nl +
        "      return Ok(result.AsJson());" + nl +
        "    }" + nl + nl +
        "    // C Dapper delete via Execute" + nl +
       $"    public async Task<ActionResult> {className}DeleteAsync({sKeyType}{sKey})" + "{" + nl +
        "      int result = 0;" + nl +
        "      string connectionString = Settings.GetConnectionString(\"PD\");" + nl +
        "      var param = new {" + $"{sKey}" + "};" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        "        result = await connection.ExecuteAsync(\"delete from " + $"[{className}] where [{sKey}] = @{sKey} " + "\", param);" + nl +
        "      }" + nl +
        "      return Ok(result == 1);" + nl +
        "    }" + nl +
        "  }" + nl +
        "} ";
     
     
    }


  }
}
