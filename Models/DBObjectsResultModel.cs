using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWorkshop.Models {
  internal class DBObjectsResultModel {
    public string ObjectType { get; set;} ="";
    public string ObjectName { get; set; } = "";
    public string ColumnName { get; set; } = "";
    public string ColumnType { get; set; } = "";
    public string ColumnLen { get; set; } = "";
  }
}
