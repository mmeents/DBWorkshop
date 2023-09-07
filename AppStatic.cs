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
    public static string nl { get { return Environment.NewLine; } }
    public static string SQLDefNullValueCSharp(string sqlType) {
      string w = sqlType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = "\"\"";
      else if (w == "varchar") result = "\"\"";
      else if (w == "int") result = "0";
      else if (w == "bigint") result = "0";
      else if (w == "binary") result = "null";
      else if (w == "bit") result = "false";
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

    public static string SQLDefNullValueSQL(string sqlType) {
      string w = sqlType.ToLower().ParseString(" ()", 0);
      string result = "";
      if (w == "char") result = "''";
      else if (w == "varchar") result = "''";
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
      else if (w == "nchar") result = "''";
      else if (w == "ntext") result = "''";
      else if (w == "nvarchar") result = "''";
      else if (w == "real") result = "0.0";
      else if (w == "smallint") result = "0";
      else if (w == "smallmoney") result = "0.0";
      else if (w == "smalldatetime") result = "null";
      else if (w == "text") result = "''";
      else if (w == "timestamp") result = "null";
      else if (w == "tinyint") result = "0";
      else if (w == "uniqueidentifier") result = "''";
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
    public static string GetSQLInsertListAsSQLParam(this TreeNode tnTable, bool IncludeFirstCol = false) {
      string sRes = ""; string sFTT = "true";
      foreach (TreeNode tn in tnTable.Nodes) {
        if (sFTT == "true") {
          sFTT = "false";
          if (IncludeFirstCol) {
            sRes = "@" + tn.Text.ParseString(" ()@", 0);
          }
        } else {
          if (sRes == "") {
            sRes = "@" + tn.Text.ParseString(" ()@", 0);
          } else {
            sRes = sRes + ", @" + tn.Text.ParseString(" ()@", 0);
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
      string tblName = tnTable.Text.ParseFirst(".")+".["+tnTable.Text.ParseLast(".")+"]";
      string sSQLParam1 = tnTable.GetSQLParamList();
      string sInsertListAsSQlParams = tnTable.GetSQLInsertListAsSQLParam();
      string sColList = tnTable.GetSQLColumnList(false);
      string sAssignColSQL = GetAssignChildSQLColList(tnTable);
      string sFirstCol;
      string sKeyType = "", sKey = "", sKeyB = "";
      if (tnTable.Nodes.Count > 0) {
        sFirstCol = tnTable.Nodes[0].Text;
        sKey = sFirstCol.ParseString(" ()", 0);
        sKeyB = "[" + sKey + "]";
        sKeyType = sFirstCol.ParseString(" ()", 1);
        if (sKeyType.Contains("char")) {
          sKeyType = sKeyType + "(" + sFirstCol.ParseString(" ()", 2) + ")";
        }
      }      
      string sDefNullValue = SQLDefNullValueSQL(sKeyType);
      return
        "-- Add Update SQL Stored Proc for " + tblName + "" + nl +
        "Create Procedure dbo.sp_AddUpdate" + tblName.ParseLast(".[]") +
        " (" + nl + "  " + sSQLParam1 + nl + ") as " + nl +
        "  set nocount on " + nl +
       $"  declare @a { sKeyType } set @a = case when (@{sKey}=0) then 0 else isnull((select " + sKeyB + " from " + tblName +
          " where " + sKeyB + " = @" + sKey + "), " + sDefNullValue + ") end  " + nl +
        "  if (@a = " + sDefNullValue + ") begin" + nl +
        "    Insert into " + tblName + " (" + nl +
        "      " + sColList + nl +
        "    ) values (" + nl + "      " + sInsertListAsSQlParams + ")" + nl +
        "    set @a = @@Identity " + nl +
        "  end else begin" + nl +
        "    Update " + tblName +
             " set" + nl + sAssignColSQL + nl +
          "    where " + sKeyB + " = @a" + nl +
        "  end" + nl +
        "  select @a " + sKey + nl + "return";


    }
    public static string GenerateCreateTableSQL(this TreeNode tnTable) { 
      string sTableName = tnTable.Text;
      string s = "DECLARE @object_name SYSNAME, @object_id INT, @SQL NVARCHAR(MAX)" + Environment.NewLine +
        "  SELECT  @object_name = '[' + OBJECT_SCHEMA_NAME(o.[object_id]) + '].[' + OBJECT_NAME([object_id]) + ']', " + Environment.NewLine +
        "    @object_id = [object_id] FROM ( SELECT [object_id] = OBJECT_ID('" + sTableName + "', 'U') ) o  " + Environment.NewLine +
        "  SELECT @SQL = 'CREATE TABLE ' + @object_name + '(' + CHAR(13) + CHAR(10) + " + Environment.NewLine +
        "    STUFF((SELECT CHAR(13) + CHAR(10) +  '  ,[' + c.name + '] ' +   " + Environment.NewLine +
        "      CASE WHEN c.is_computed = 1 " + Environment.NewLine +
        "        THEN 'AS ' + OBJECT_DEFINITION(c.[object_id], c.column_id)  " + Environment.NewLine +
        "        ELSE   " + Environment.NewLine +
        "          CASE WHEN c.system_type_id != c.user_type_id   " + Environment.NewLine +
        "            THEN '[' + SCHEMA_NAME(tp.[schema_id]) + '].[' + tp.name + ']'   " + Environment.NewLine +
        "            ELSE '[' + UPPER(tp.name) + ']'   " + Environment.NewLine +
        "          END  +   " + Environment.NewLine +
        "          CASE " + Environment.NewLine +
        "            WHEN tp.name IN ('varchar', 'char', 'varbinary', 'binary') THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length AS VARCHAR(5)) END + ')'  " + Environment.NewLine +
        "            WHEN tp.name IN ('nvarchar', 'nchar') THEN '(' + CASE WHEN c.max_length = -1 THEN 'MAX' ELSE CAST(c.max_length / 2 AS VARCHAR(5)) END + ')'  " + Environment.NewLine +
        "            WHEN tp.name IN ('datetime2', 'time2', 'datetimeoffset') THEN '(' + CAST(c.scale AS VARCHAR(5)) + ')'  " + Environment.NewLine +
        "            WHEN tp.name = 'decimal' THEN '(' + CAST(c.[precision] AS VARCHAR(5)) + ',' + CAST(c.scale AS VARCHAR(5)) + ')'  " + Environment.NewLine +
        "            ELSE '' " + Environment.NewLine +
        "          END +  " + Environment.NewLine +
        "          CASE WHEN c.collation_name IS NOT NULL AND c.system_type_id = c.user_type_id   " + Environment.NewLine +
        "            THEN ' COLLATE ' + c.collation_name ELSE '' END +  " + Environment.NewLine +
        "              CASE WHEN c.is_nullable = 1 THEN ' NULL' ELSE ' NOT NULL' END +  " + Environment.NewLine +
        "              CASE WHEN c.default_object_id != 0   " + Environment.NewLine +
        "                THEN ' CONSTRAINT [' + OBJECT_NAME(c.default_object_id) + '] DEFAULT ' + OBJECT_DEFINITION(c.default_object_id)  " + Environment.NewLine +
        "                ELSE ''  " + Environment.NewLine +
        "              END +   " + Environment.NewLine +
        "              CASE WHEN cc.[object_id] IS NOT NULL   " + Environment.NewLine +
        "                THEN ' CONSTRAINT [' + cc.name + '] CHECK ' + cc.[definition]  " + Environment.NewLine +
        "                ELSE ''  " + Environment.NewLine +
        "              END +  " + Environment.NewLine +
        "              CASE WHEN c.is_identity = 1  " + Environment.NewLine +
        "                THEN ' IDENTITY(' + CAST(IDENTITYPROPERTY(c.[object_id], 'SeedValue') AS VARCHAR(5)) + ',' +   " + Environment.NewLine +
        "                  CAST(IDENTITYPROPERTY(c.[object_id], 'IncrementValue') AS VARCHAR(5)) + ')'   " + Environment.NewLine +
        "                ELSE ''   " + Environment.NewLine +
        "              END   " + Environment.NewLine +
        "          END  " + Environment.NewLine +
        "      FROM sys.columns c WITH(NOLOCK) " + Environment.NewLine +
        "        JOIN sys.types tp WITH(NOLOCK) ON c.user_type_id = tp.user_type_id  " + Environment.NewLine +
        "        LEFT JOIN sys.check_constraints cc WITH(NOLOCK) ON c.[object_id] = cc.parent_object_id AND cc.parent_column_id = c.column_id  " + Environment.NewLine +
        "      WHERE c.[object_id] = @object_id  " + Environment.NewLine +
        "      ORDER BY c.column_id  " + Environment.NewLine +
        "      FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 5, '   ') +   " + Environment.NewLine +
        "      ISNULL((SELECT CHAR(13) + CHAR(10) + '  ,CONSTRAINT [' + i.name + '] PRIMARY KEY ' +   " + Environment.NewLine +
        "      CASE WHEN i.index_id = 1 THEN 'CLUSTERED' ELSE 'NONCLUSTERED' END +" + Environment.NewLine +
        "      ' (' + ( SELECT STUFF(CAST((SELECT ', [' + COL_NAME(ic.[object_id], ic.column_id) + ']' +" + Environment.NewLine +
        "                  CASE WHEN ic.is_descending_key = 1 THEN ' DESC' ELSE '' END  " + Environment.NewLine +
        "          FROM sys.index_columns ic WITH(NOLOCK)  " + Environment.NewLine +
        "          WHERE i.[object_id] = ic.[object_id]  " + Environment.NewLine +
        "              AND i.index_id = ic.index_id  " + Environment.NewLine +
        "          FOR XML PATH(N''), TYPE) AS NVARCHAR(MAX)), 1, 2, '')) + ')'  " + Environment.NewLine +
        "      FROM sys.indexes i WITH(NOLOCK)  " + Environment.NewLine +
        "      WHERE i.[object_id] = @object_id AND i.is_primary_key = 1), '') + CHAR(13) + CHAR(10) +  ')'    " + Environment.NewLine +
        " select @SQL sOut ";
      return s;
    }

    public static string GetNamespaceText(string sDB) { 
      return 
        "using Dapper;  // data io is based on Dapper." + nl +
        "using System.Data;" + nl +
        "using System.Data.SqlClient;  // from nuget as well." + nl +
        "using StaticExtensions;  // see StaticExtensions in nuget." + nl + nl +
       $"namespace {sDB}" + "{" + nl + nl; 
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
        sRes = sRes + $"    public {GetCTypeFromSQLType(tn.Text.ParseLast(" "))} {scol}" + "{get; set;} = " + SQLDefNullValueCSharp(tn.Text.ParseLast(" "))+";" + nl;
      }
      return sRes;
    }
    public static string GenerateCSharpRepoLikeClassFromTable(this TreeNode tnTable, bool IncludeNamespace = true) {
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
      string a = "";
      string d = "";
      for (Int32 i = 0; i < tnTable.Nodes.Count; i++) {        
        a = a + (a == "" ? "" : ", ") + $"{tnTable.Nodes[i].Text.ParseFirst(" @").AsUpperCaseFirstLetter()} = {tnTable.Nodes[i].Text.ParseFirst(" @").AsLowerCaseFirstLetter()}";
        d = d + (d == "" ? "" : ", ") + $"{GetCTypeFromSQLType(tnTable.Nodes[i].Text.ParseLast(" "))} {tnTable.Nodes[i].Text.ParseFirst(" @").AsLowerCaseFirstLetter()}";
      }
      string className = tblName.ParseLast(".").AsUpperCaseFirstLetter();
      string classVarName = className.AsLowerCaseFirstLetter();
      return
        (IncludeNamespace ? GetNamespaceText(sDB) : "") +
        "  // C Entity Class " + nl +
       $"  public class {className}" + "{" + nl +
       $"    public {tblName.ParseLast(".")}()" + "{}" + nl +
               cn.GetCSharpColAsProps() +
        "  }" + nl + nl +
       $"  public class {className}Repository" + "{" + nl +
       $"    // C Dapper Load List of {className}" + nl +
       $"    public async Task<ActionResult> {className}IndexAsync()" + "{" + nl +
       $"      IEnumerable<{className}> result;" + nl +
        "      string connectionString = GetConnectionString();" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
       $"        result = await connection.QueryAsync<{className}>("+nl+
       $"          \"select {sColListb} from {tblName} \");" + nl +
        "      }" + nl +
        "      return Ok(result);" + nl +
        "    }" + nl + nl +
        "    // C Dapper Load single Item" + nl +
       $"    public async Task<ActionResult> {className}ItemAsync({sKeyType} {sKey})" + "{" + nl +
        "      string connectionString = GetConnectionString();" + nl +
       $"      {className} result;" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        "        var param = new {" + sKey + "};" + nl +
       $"        result = await connection.QueryFirstOrDefaultAsync<{className}>("+nl+
       $"          \"select {sColListb} from {tblName} where {sKey} = @{sKey} \", param);" + nl +
        "      }" + nl +
        "      return Ok($\"{result.AsJson()}\");" + nl +
        "    }" + nl + nl +
        "    // C Dapper Edit via Add Update stored procdure" + nl +
       $"    public async Task<int> {className}EditAsync({className} {classVarName}) " + "{" + nl +
        "      string connectionString = GetConnectionString();" + nl +
       $"      int result = 0;" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
       $"        result = await connection.QueryFirstOrDefaultAsync<int>("+nl+
       $"          \"dbo.sp_AddUpdate{className}\", {classVarName}, commandType: CommandType.StoredProcedure);" + nl +
        "      }" + nl +
        "      return result;" + nl +
        "    }" + nl + nl +
        "    // C Dapper Edit via Add Update stored procdure x2" + nl +
       $"    public async Task<int> {className}Edit2Async({d}) " + "{" + nl +
        "      string connectionString = GetConnectionString();" + nl +
       $"      int result = 0;" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
       $"        {className} {classVarName} = new {className}(){{ {a} }};" +nl+
       $"        result = await connection.QueryFirstOrDefaultAsync<int>(" + nl +
       $"          \"dbo.sp_AddUpdate{className}\", {classVarName}, commandType: CommandType.StoredProcedure);" + nl +
        "      }" + nl +
        "      return result;" + nl +
        "    }" + nl + nl +
        "    // C Dapper delete via Execute" + nl +
       $"    public async Task<ActionResult> {className}DeleteAsync({sKeyType}{sKey})" + "{" + nl +
        "      int result = 0;" + nl +
        "      string connectionString = GetConnectionString();" + nl +
        "      var param = new {" + $"{sKey}" + "};" + nl +
        "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        "        result = await connection.ExecuteAsync("+nl+
        "          \"delete from " + $"[{className}] where [{sKey}] = @{sKey} " + "\", param);" + nl +
        "      }" + nl +
        "      return Ok(result == 1);" + nl +
        "    }" + nl +
        "  }" + nl +
        (IncludeNamespace ? "}" : "");
     
     
    }

    public static string GenerateCSharpExecStoredProc(this TreeNode tnStProc) {      
      string sDBName = tnStProc.Parent.Parent.Parent.Text.ParseFirst(":");
      string a = "";      
      string d = "";
      for (Int32 i = 0; i < tnStProc.Nodes.Count; i++) {
        a = a + (a == "" ? "" : ", ") + tnStProc.Nodes[i].Text.ParseString(" @", 0);                
        d = d + (d == "" ? "" : ", ") + $"{GetCTypeFromSQLType(tnStProc.Nodes[i].Text.ParseLast(" "))} {tnStProc.Nodes[i].Text.ParseFirst(" @")}";
      }
      string className = tnStProc.Text.ParseLast(".").AsUpperCaseFirstLetter();
      var s = "    // C Dapper Edit via Add Update stored procdure" + nl +
        $"    public async Task<ActionResult> Exec{className}Async({d}) " + "{" + nl +
        $"      string connectionString = Settings.GetConnectionString(\"{sDBName}\");" + nl +
        $"      {className}Result result;" + nl + 
         "      var params = new {" + $"{a}" + "};" + nl +
         "      using (SqlConnection connection = new SqlConnection(connectionString)) {" + nl +
        $"        result = await connection.QueryAsync<{className}Result>(\"{tnStProc.Text.ParseFirst(" ")}\", params, commandType: CommandType.StoredProcedure);" + nl +
         "      }" + nl +
         "      return Ok(result.ToJson());" + nl +
         "    }" + nl + nl;
      return s;
    }

    public static string GetDeclareSQLParam(this TreeNode tnStProc) { 
      string s = "";
      foreach(TreeNode cn in tnStProc.Nodes) { 
        s = s +"declare "+ cn.Text + " set " +cn.Text.ParseFirst(" ")+" = "+ SQLDefNullValueSQL(cn.Text.ParseLast(" "))+";" + CodeStatic.nl;
      }
      return s;
    }
    public static string GetExecSQLStoredProcedure(this TreeNode tnStProc) { 
      return "--  the call to execute " + nl 
        +GetDeclareSQLParam(tnStProc)+nl 
        +$"Exec {tnStProc.Text} {tnStProc.GetSQLInsertListAsSQLParam(true)}";
    }

  }
}
