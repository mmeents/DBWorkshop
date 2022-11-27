using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWorkshop {
  public static class AppStatic {

    public static Int32 GetImageIndexFromCode(string aCode) {      
      Int32 sResult = 0;
      if (aCode == "S") {
        sResult = 0;
      } else if (aCode == "Database") {
        sResult = 1;
      } else if (aCode == "Folder") {
        sResult = 2;
      } else if (aCode == "Table") {
        sResult = 3;
      } else if (aCode == "View") {
        sResult = 4;
      } else if (aCode == "Procedure") {
        sResult = 5;
      } else if (aCode == "Function") {
        sResult = 6;
      }
      return sResult;
    }
  }
}
