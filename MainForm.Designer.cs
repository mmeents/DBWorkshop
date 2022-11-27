namespace DBWorkshop {
  partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.ilMain = new System.Windows.Forms.ImageList(this.components);
      this.tabControlMain = new System.Windows.Forms.TabControl();
      this.tabWelcome = new System.Windows.Forms.TabPage();
      this.btnSaveCon = new System.Windows.Forms.Button();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.tbUserName = new System.Windows.Forms.TextBox();
      this.tbDatabase = new System.Windows.Forms.TextBox();
      this.tbServer = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbConName = new System.Windows.Forms.TextBox();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabBuildIt = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tvMain = new System.Windows.Forms.TreeView();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabSQL = new System.Windows.Forms.TabPage();
      this.tbSQL = new FastColoredTextBoxNS.FastColoredTextBox();
      this.tabCSharp = new System.Windows.Forms.TabPage();
      this.tabWiki = new System.Windows.Forms.TabPage();
      this.tbCSharp = new FastColoredTextBoxNS.FastColoredTextBox();
      this.tabControlMain.SuspendLayout();
      this.tabWelcome.SuspendLayout();
      this.tabBuildIt.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabSQL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbSQL)).BeginInit();
      this.tabCSharp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbCSharp)).BeginInit();
      this.SuspendLayout();
      // 
      // ilMain
      // 
      this.ilMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
      this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
      this.ilMain.Images.SetKeyName(0, "Network-Server-icon.png");
      this.ilMain.Images.SetKeyName(1, "Database-icon.png");
      this.ilMain.Images.SetKeyName(2, "folder-database-icon.png");
      this.ilMain.Images.SetKeyName(3, "database-table-icon.png");
      this.ilMain.Images.SetKeyName(4, "Database-Table-icon (1).png");
      this.ilMain.Images.SetKeyName(5, "server-components-icon.png");
      this.ilMain.Images.SetKeyName(6, "function-icon.png");
      this.ilMain.Images.SetKeyName(7, "list-components-icon.png");
      // 
      // tabControlMain
      // 
      this.tabControlMain.Controls.Add(this.tabWelcome);
      this.tabControlMain.Controls.Add(this.tabBuildIt);
      this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlMain.Location = new System.Drawing.Point(0, 0);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new System.Drawing.Size(804, 663);
      this.tabControlMain.TabIndex = 1;
      this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
      // 
      // tabWelcome
      // 
      this.tabWelcome.Controls.Add(this.btnSaveCon);
      this.tabWelcome.Controls.Add(this.tbPassword);
      this.tabWelcome.Controls.Add(this.tbUserName);
      this.tabWelcome.Controls.Add(this.tbDatabase);
      this.tabWelcome.Controls.Add(this.tbServer);
      this.tabWelcome.Controls.Add(this.label6);
      this.tabWelcome.Controls.Add(this.label5);
      this.tabWelcome.Controls.Add(this.label4);
      this.tabWelcome.Controls.Add(this.label3);
      this.tabWelcome.Controls.Add(this.label2);
      this.tabWelcome.Controls.Add(this.tbConName);
      this.tabWelcome.Controls.Add(this.listBox1);
      this.tabWelcome.Controls.Add(this.label1);
      this.tabWelcome.Location = new System.Drawing.Point(4, 24);
      this.tabWelcome.Name = "tabWelcome";
      this.tabWelcome.Padding = new System.Windows.Forms.Padding(3);
      this.tabWelcome.Size = new System.Drawing.Size(796, 635);
      this.tabWelcome.TabIndex = 0;
      this.tabWelcome.Text = "Welcome";
      this.tabWelcome.UseVisualStyleBackColor = true;
      // 
      // btnSaveCon
      // 
      this.btnSaveCon.Location = new System.Drawing.Point(389, 234);
      this.btnSaveCon.Name = "btnSaveCon";
      this.btnSaveCon.Size = new System.Drawing.Size(54, 23);
      this.btnSaveCon.TabIndex = 12;
      this.btnSaveCon.Text = "Save";
      this.btnSaveCon.UseVisualStyleBackColor = true;
      this.btnSaveCon.Visible = false;
      this.btnSaveCon.Click += new System.EventHandler(this.btnSaveCon_Click);
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(389, 195);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.Size = new System.Drawing.Size(261, 23);
      this.tbPassword.TabIndex = 11;
      this.tbPassword.ModifiedChanged += new System.EventHandler(this.tbConName_ModifiedChanged);
      // 
      // tbUserName
      // 
      this.tbUserName.Location = new System.Drawing.Point(389, 167);
      this.tbUserName.Name = "tbUserName";
      this.tbUserName.Size = new System.Drawing.Size(261, 23);
      this.tbUserName.TabIndex = 10;
      this.tbUserName.ModifiedChanged += new System.EventHandler(this.tbConName_ModifiedChanged);
      // 
      // tbDatabase
      // 
      this.tbDatabase.Location = new System.Drawing.Point(389, 140);
      this.tbDatabase.Name = "tbDatabase";
      this.tbDatabase.Size = new System.Drawing.Size(261, 23);
      this.tbDatabase.TabIndex = 9;
      this.tbDatabase.ModifiedChanged += new System.EventHandler(this.tbConName_ModifiedChanged);
      // 
      // tbServer
      // 
      this.tbServer.Location = new System.Drawing.Point(389, 112);
      this.tbServer.Name = "tbServer";
      this.tbServer.Size = new System.Drawing.Size(261, 23);
      this.tbServer.TabIndex = 8;
      this.tbServer.ModifiedChanged += new System.EventHandler(this.tbConName_ModifiedChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(265, 198);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(83, 15);
      this.label6.TabIndex = 7;
      this.label6.Text = "User Password";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(265, 170);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 15);
      this.label5.TabIndex = 6;
      this.label5.Text = "User Name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(265, 143);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 15);
      this.label4.TabIndex = 5;
      this.label4.Text = "Database";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(265, 115);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(39, 15);
      this.label3.TabIndex = 4;
      this.label3.Text = "Server";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(265, 87);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(107, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "Connection Name ";
      // 
      // tbConName
      // 
      this.tbConName.Location = new System.Drawing.Point(389, 84);
      this.tbConName.Name = "tbConName";
      this.tbConName.Size = new System.Drawing.Size(261, 23);
      this.tbConName.TabIndex = 2;
      this.tbConName.ModifiedChanged += new System.EventHandler(this.tbConName_ModifiedChanged);
      // 
      // listBox1
      // 
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 15;
      this.listBox1.Items.AddRange(new object[] {
            "Enter Info click Save"});
      this.listBox1.Location = new System.Drawing.Point(61, 87);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(181, 150);
      this.listBox1.TabIndex = 1;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(41, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(105, 21);
      this.label1.TabIndex = 0;
      this.label1.Text = "Connections ";
      // 
      // tabBuildIt
      // 
      this.tabBuildIt.Controls.Add(this.splitContainer1);
      this.tabBuildIt.Location = new System.Drawing.Point(4, 24);
      this.tabBuildIt.Name = "tabBuildIt";
      this.tabBuildIt.Padding = new System.Windows.Forms.Padding(3);
      this.tabBuildIt.Size = new System.Drawing.Size(796, 635);
      this.tabBuildIt.TabIndex = 1;
      this.tabBuildIt.Text = "Build It";
      this.tabBuildIt.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(790, 629);
      this.splitContainer1.SplitterDistance = 541;
      this.splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.panel1);
      this.splitContainer2.Panel1.Controls.Add(this.tvMain);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
      this.splitContainer2.Size = new System.Drawing.Size(790, 541);
      this.splitContainer2.SplitterDistance = 338;
      this.splitContainer2.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(338, 25);
      this.panel1.TabIndex = 1;
      // 
      // tvMain
      // 
      this.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tvMain.ImageIndex = 0;
      this.tvMain.ImageList = this.ilMain;
      this.tvMain.Location = new System.Drawing.Point(0, 26);
      this.tvMain.Name = "tvMain";
      this.tvMain.SelectedImageIndex = 0;
      this.tvMain.Size = new System.Drawing.Size(336, 517);
      this.tvMain.TabIndex = 0;
      this.tvMain.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMain_BeforeExpand);
      this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabSQL);
      this.tabControl1.Controls.Add(this.tabCSharp);
      this.tabControl1.Controls.Add(this.tabWiki);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(448, 541);
      this.tabControl1.TabIndex = 0;
      // 
      // tabSQL
      // 
      this.tabSQL.Controls.Add(this.tbSQL);
      this.tabSQL.Location = new System.Drawing.Point(4, 24);
      this.tabSQL.Name = "tabSQL";
      this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
      this.tabSQL.Size = new System.Drawing.Size(440, 513);
      this.tabSQL.TabIndex = 1;
      this.tabSQL.Text = "SQL";
      this.tabSQL.UseVisualStyleBackColor = true;
      // 
      // tbSQL
      // 
      this.tbSQL.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.tbSQL.AutoIndent = false;
      this.tbSQL.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
      this.tbSQL.AutoScrollMinSize = new System.Drawing.Size(67, 14);
      this.tbSQL.BackBrush = null;
      this.tbSQL.CharHeight = 14;
      this.tbSQL.CharWidth = 8;
      this.tbSQL.DefaultMarkerSize = 8;
      this.tbSQL.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.tbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbSQL.FindForm = null;
      this.tbSQL.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tbSQL.GoToForm = null;
      this.tbSQL.Hotkeys = resources.GetString("tbSQL.Hotkeys");
      this.tbSQL.IsReplaceMode = false;
      this.tbSQL.Language = FastColoredTextBoxNS.Text.Language.SQL;
      this.tbSQL.Location = new System.Drawing.Point(3, 3);
      this.tbSQL.Name = "tbSQL";
      this.tbSQL.Paddings = new System.Windows.Forms.Padding(0);
      this.tbSQL.ReplaceForm = null;
      this.tbSQL.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.tbSQL.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbSQL.ServiceColors")));
      this.tbSQL.Size = new System.Drawing.Size(434, 507);
      this.tbSQL.TabIndex = 0;
      this.tbSQL.Text = "tbSQL";
      this.tbSQL.Zoom = 100;
      // 
      // tabCSharp
      // 
      this.tabCSharp.Controls.Add(this.tbCSharp);
      this.tabCSharp.Location = new System.Drawing.Point(4, 24);
      this.tabCSharp.Name = "tabCSharp";
      this.tabCSharp.Size = new System.Drawing.Size(440, 513);
      this.tabCSharp.TabIndex = 2;
      this.tabCSharp.Text = "C#";
      this.tabCSharp.UseVisualStyleBackColor = true;
      // 
      // tabWiki
      // 
      this.tabWiki.Location = new System.Drawing.Point(4, 24);
      this.tabWiki.Name = "tabWiki";
      this.tabWiki.Size = new System.Drawing.Size(440, 513);
      this.tabWiki.TabIndex = 3;
      this.tabWiki.Text = "Wiki";
      this.tabWiki.UseVisualStyleBackColor = true;
      // 
      // tbCSharp
      // 
      this.tbCSharp.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
      this.tbCSharp.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
      this.tbCSharp.AutoScrollMinSize = new System.Drawing.Size(179, 14);
      this.tbCSharp.BackBrush = null;
      this.tbCSharp.CharHeight = 14;
      this.tbCSharp.CharWidth = 8;
      this.tbCSharp.DefaultMarkerSize = 8;
      this.tbCSharp.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
      this.tbCSharp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbCSharp.FindForm = null;
      this.tbCSharp.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tbCSharp.GoToForm = null;
      this.tbCSharp.Hotkeys = resources.GetString("tbCSharp.Hotkeys");
      this.tbCSharp.IsReplaceMode = false;
      this.tbCSharp.Language = FastColoredTextBoxNS.Text.Language.CSharp;
      this.tbCSharp.Location = new System.Drawing.Point(0, 0);
      this.tbCSharp.Name = "tbCSharp";
      this.tbCSharp.Paddings = new System.Windows.Forms.Padding(0);
      this.tbCSharp.ReplaceForm = null;
      this.tbCSharp.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
      this.tbCSharp.SelectionLength = 19;
      this.tbCSharp.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("tbCSharp.ServiceColors")));
      this.tbCSharp.Size = new System.Drawing.Size(440, 513);
      this.tbCSharp.TabIndex = 0;
      this.tbCSharp.Text = "fastColoredTextBox1";
      this.tbCSharp.Zoom = 100;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 663);
      this.Controls.Add(this.tabControlMain);
      this.Name = "MainForm";
      this.Text = "DBWorkshop - Set Connection Strings";
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.tabControlMain.ResumeLayout(false);
      this.tabWelcome.ResumeLayout(false);
      this.tabWelcome.PerformLayout();
      this.tabBuildIt.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabSQL.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.tbSQL)).EndInit();
      this.tabCSharp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.tbCSharp)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private ImageList ilMain;
    private TabControl tabControlMain;
    private TabPage tabWelcome;
    private TabPage tabBuildIt;
    private SplitContainer splitContainer1;
    private SplitContainer splitContainer2;
    private Panel panel1;
    private TreeView tvMain;
    private TabControl tabControl1;
    private TabPage tabSQL;
    private TabPage tabCSharp;
    private TabPage tabWiki;
    private Button btnSaveCon;
    private TextBox tbPassword;
    private TextBox tbUserName;
    private TextBox tbDatabase;
    private TextBox tbServer;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private TextBox tbConName;
    private ListBox listBox1;
    private Label label1;
    private FastColoredTextBoxNS.FastColoredTextBox tbSQL;
    private FastColoredTextBoxNS.FastColoredTextBox tbCSharp;
  }
}