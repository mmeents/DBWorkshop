using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCrypto.Models;

namespace DBWorkshop {
  public class DBConNode : TreeNode {
    public DbConnectionInfo _dBConnection;
    public DBConNode(DbConnectionInfo dBConnectionInfo) : base() { 
      _dBConnection = dBConnectionInfo;
      Text = _dBConnection.ConnectionName+":"+_dBConnection.ServerName;
      ImageIndex = 0;
      this.Nodes.Add(new TreeNode("Placeholder", 1, 1));
    }
  }

  public class DBNode : TreeNode {
    public DbConnectionInfo _dBConnection;
    public DBNode(DbConnectionInfo dBConnectionInfo, string DatabaseName) : base(DatabaseName, 1, 1) {
      _dBConnection = new DbConnectionInfo(DatabaseName, dBConnectionInfo.ConnectionString);
      _dBConnection.InitialCatalog = DatabaseName;
      Text = DatabaseName;      
      this.Nodes.Add(new TreeNode("Placeholder", 1, 1));
    }
  }

}
