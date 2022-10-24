using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.IO;
using System.Security.Cryptography;
using C0DEC0RE;
using System.Linq;

namespace UnitTestProject1 {

  public class CObject : ConcurrentDictionary<string, object> {
    public CObject() : base() { }
    public Boolean Contains(String aKey) { return base.Keys.Contains(aKey); }
    public new object this[string aKey] {
      get { return (Contains(aKey) ? base[aKey] : null); }
      set { base[aKey] = value; }
    }
    public void Remove(string aKey) {
      if (Contains(aKey)) {
        base.TryRemove(aKey, out object outcast);
      }
    }
    public void Merge(CObject aObject, Boolean OnDupOverwiteExisting) {
      if (aObject != null) {
        if (OnDupOverwiteExisting) {
          foreach (string sKey in aObject.Keys) {
            base[sKey] = aObject[sKey];
          }
        } else {
          foreach (string sKey in aObject.Keys) {
            if (!Contains(sKey)) {
              base[sKey] = aObject[sKey];
            }
          }
        }
      }
    }
  }

  public class CQueue : ConcurrentDictionary<Int64, object> {
    public Int64 Nonce = Int64.MinValue;
    public Boolean Contains(Int64 aKey) { return base.Keys.Contains(aKey); }
    public CQueue() : base() { }
    public object Add(object aObj) {
      Nonce++;
      base[Nonce] = aObj;
      return aObj;
      //return base[Nonce++] = aObj;
    }
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) {
        base.TryRemove(base.Keys.OrderBy(x => x).First(), out aR);
      }
      return aR;
    }
    public void Remove(Int64 aKey) {
      if (Contains(aKey)) {
        object outcast;
        base.TryRemove(aKey, out outcast);
      }
    }
  }

  public enum KeyType { AES, DES, RSA };

  public class CKey : CObject {

    private PasswordDeriveBytes PDB = null;

    public CKey(string Secret) : base () {
      PDB = new PasswordDeriveBytes(Secret, null);
    }

    public string toAESCipher(string sText) {
      string sResult = "";      
      AesCryptoServiceProvider aASP = new AesCryptoServiceProvider();
      AesManaged aes = new AesManaged();
      aes.Key = PDB.GetBytes(32);
      aes.IV = PDB.GetBytes(16);
      MemoryStream ms = new MemoryStream();
      CryptoStream encStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
      StreamWriter sw = new StreamWriter(encStream);
      sw.WriteLine(sText.toBase64EncodedStr());
      sw.Close();
      encStream.Close();
      byte[] buffer = ms.ToArray();
      ms.Close();
      sResult = buffer.toHexStr();      
      return sResult;
    }
    public string toDecryptAES(string sAESCipherText) {
      string val = "";
      try {
        AesCryptoServiceProvider aASP = new AesCryptoServiceProvider();
        AesManaged aes = new AesManaged();
        aes.Key = PDB.GetBytes(32);
        aes.IV = PDB.GetBytes(16);
        MemoryStream ms = new MemoryStream(sAESCipherText.toByteArray());
        CryptoStream encStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        StreamReader sr = new StreamReader(encStream);
        val = sr.ReadToEnd();
        val = val.toBase64DecodedStr();
        sr.Close();
        encStream.Close();
        ms.Close();
      } catch (Exception e) {
        throw e;
      }
      return val;
    }

    public string toDESCipher(string sText) {
      string sResult = "";
      DESCryptoServiceProvider aCSP = new DESCryptoServiceProvider();
      aCSP.Key = PDB.CryptDeriveKey("DES", "SHA1", 64, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
      aCSP.IV = MMExt.defIV;
      MemoryStream ms = new MemoryStream();
      CryptoStream encStream = new CryptoStream(ms, aCSP.CreateEncryptor(), CryptoStreamMode.Write);
      StreamWriter sw = new StreamWriter(encStream);
      sw.WriteLine(sText.toBase64EncodedStr());
      sw.Close();
      encStream.Close();
      byte[] buffer = ms.ToArray();
      ms.Close();
      sResult = buffer.toHexStr();
      return sResult;
    }
    public string toDecryptDES(string sDESCipherText) {
      DESCryptoServiceProvider aCSP = new DESCryptoServiceProvider();
      aCSP.Key = PDB.CryptDeriveKey("DES", "SHA1", 64, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
      aCSP.IV = MMExt.defIV;
      MemoryStream ms = new MemoryStream(sDESCipherText.toByteArray());
      CryptoStream encStream = new CryptoStream(ms, aCSP.CreateDecryptor(), CryptoStreamMode.Read);
      StreamReader sr = new StreamReader(encStream);
      string val = sr.ReadToEnd().toBase64DecodedStr();
      sr.Close();
      encStream.Close();
      ms.Close();
      return val;
    }

  }


  [TestClass]
  public class ResearchCoreUnderstanding {
    
    [TestMethod]
    public void TestAdd1000() {


    
    }

    [TestMethod]
    public void TestAdd10001() {
    
    }

    [TestMethod]
    public void TestAdd10002() {
    
    }


    [TestMethod]
    public void TestMethod2() {
                  
    }

    [TestMethod]
    public void TestMethod3() {      


    }

  }

 
}
