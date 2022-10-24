using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using C0DEC0RE;

namespace FileTableTest {

  //  C is for Concurrent.  so that threads off the main can have access too.   
  //  Most common type is string lookup version so lets call them Objects. 
  #region class CObject 

  public class CObject : ConcurrentDictionary<string, object> {
    public CObject() : base() { }
    public Boolean Contains(String aKey) { return base.Keys.Contains(aKey); }
    public new object this[string aKey] {
      get { return (Contains(aKey) ? base[aKey] : null); }
      set { base[aKey] = value; }
    }
    public void Remove(string aKey) {
      if (Contains(aKey)) {
        object outcast;
        base.TryRemove(aKey, out outcast);
      }
    }
  }

  #endregion 

  //  Decimal Rank order dictionary is a book.
  public class CBook : ConcurrentDictionary<decimal, object> {
    public CBook() : base() {}
    public Boolean Contains(decimal aKey) { return base.Keys.Contains(aKey); }
    public new object this[decimal aKey] {
      get { return (Contains(aKey) ? base[aKey] : null); }
      set { base[aKey] = value; }
    }
    public void Remove(decimal aKey) {
      if (Contains(aKey)) { base.TryRemove(aKey, out object outcast); }
    }
    public decimal ElementKeyAt(Int32 iIndex) {
      IEnumerable<decimal> lQS = base.Keys.OrderByDescending(x => (x));
      return lQS.ElementAt(iIndex);
    }
  }

  //  Integer order is a Cache where rank is from Max to Min from first to last. 
  #region public class CCache variants 
  
  public class CCache16 : ConcurrentDictionary<Int16, object> {
    public Int16 Nonce = Int16.MaxValue;
    public Int16 Height => Convert.ToInt16(Int16.MaxValue.toInt32() - this.Nonce.toInt32());
    public Boolean Contains(Int16 aKey) { return base.Keys.Contains(aKey); }
    public CCache16() : base() { }
    public object Add(object aObj) { Nonce--; base[Nonce] = aObj; return aObj; }
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) { base.TryRemove(base.Keys.OrderBy(x => x).Last(), out aR); }
      return aR;
    }
    public void Remove(Int16 aKey) {
      if (Contains(aKey)) { base.TryRemove(aKey, out object outcast); }
    }
  }

  public class CCache32 : ConcurrentDictionary<Int32, object> {
    public Int32 Nonce = Int32.MaxValue;
    public Int32 Height => Int32.MaxValue - Nonce;
    public Boolean Contains(Int32 aKey) { return base.Keys.Contains(aKey); }
    public CCache32() : base() { }
    public object Add(object aObj) {Nonce--; base[Nonce] = aObj; return aObj; }
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) { base.TryRemove(base.Keys.OrderBy(x => x).Last(), out aR); }
      return aR;
    }
    public void Remove(Int32 aKey) {
      if (Contains(aKey)) {  base.TryRemove(aKey, out object outcast); }
    }
  }

  public class CCache64 : ConcurrentDictionary<Int64, object> {
    public Int64 Nonce = Int64.MaxValue;
    public Int64 Height { get { return Int64.MaxValue - Nonce; } }
    public Boolean Contains(Int64 aKey) {return base.Keys.Contains(aKey); }
    public CCache64() : base() { }
    public object Add(object aObj) { Nonce--; base[Nonce] = aObj; return aObj;}
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) { base.TryRemove(base.Keys.OrderBy(x => x).Last(), out aR); }
      return aR;
    }
    public void Remove(Int64 aKey) {
      if (Contains(aKey)) { base.TryRemove(aKey, out object outcast); }
    }
  }

  #endregion

  //  Another Int is a Queue where rank is from Min to Max and First in is First out.
  #region public class CQueue variants 

  public class CQueue16 : ConcurrentDictionary<Int16, object> {
    public Int16 Nonce = Int16.MinValue;
    public CQueue16() : base() { }
    public Boolean Contains(Int16 aKey) {
      return base.Keys.Contains(aKey);
    }
    public object Add(object aObj) {
      Nonce++;
      base[Nonce] = aObj;
      return aObj;
    }
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) {
        base.TryRemove(base.Keys.OrderBy(x => x).First(), out aR);
      }
      return aR;
    }
    public void Remove(Int16 aKey) {
      if (Contains(aKey)) {
        base.TryRemove(aKey, out object outcast);
      }
    }
  }

  public class CQueue32 : ConcurrentDictionary<Int64, object> {
    public Int32 Nonce = Int32.MinValue;
    public CQueue32() : base() { }
    public Boolean Contains(Int32 aKey) {
      return base.Keys.Contains(aKey);
    }
    public object Add(object aObj) {
      Nonce++;
      base[Nonce] = aObj;
      return aObj;
    }
    public object Pop() {
      Object aR = null;
      if (Keys.Count > 0) {
        base.TryRemove(base.Keys.OrderBy(x => x).First(), out aR);
      }
      return aR;
    }
    public void Remove(Int32 aKey) {
      if (Contains(aKey)) {
        base.TryRemove(aKey, out object outcast);
      }
    }
  }

  public class CQueue64 : ConcurrentDictionary<Int64, object> {
    public Int64 Nonce = Int64.MinValue;
    public CQueue64() : base() { }
    public Boolean Contains(Int64 aKey) {
      return base.Keys.Contains(aKey);
    }
    public object Add(object aObj) {
      Nonce++;
      base[Nonce] = aObj;
      return aObj;
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
        base.TryRemove(aKey, out object outcast);
      }
    }
  }

  #endregion

  //  Lets call them the start of the C Class variants.  
}
