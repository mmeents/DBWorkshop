using System;
using C0DEC0RE;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileTableTest {

  [TestClass]
  public class UnitTest2 {
    public UnitTest2(){

    }

    [TestMethod]
    public void TestMethod1() {

      for (Int64 i = Int64.MinValue; i < Int64.MinValue + 100; i++) {
        Console.WriteLine( "i "+ i.toString());
      }

    }
  }
}
