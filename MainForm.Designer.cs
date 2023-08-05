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
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      ilMain = new ImageList(components);
      tabControlMain = new TabControl();
      tabWelcome = new TabPage();
      btnRemoveConnection = new Button();
      btnSaveCon = new Button();
      edPassword = new TextBox();
      edUserName = new TextBox();
      edDatabase = new TextBox();
      edServer = new TextBox();
      label6 = new Label();
      label5 = new Label();
      label4 = new Label();
      label3 = new Label();
      label2 = new Label();
      edConName = new TextBox();
      listBox1 = new ListBox();
      label1 = new Label();
      tabBuildIt = new TabPage();
      splitContainer1 = new SplitContainer();
      splitContainer2 = new SplitContainer();
      panel1 = new Panel();
      tvMain = new TreeView();
      tabControlTextEditors = new TabControl();
      MenuStripSql = new ContextMenuStrip(components);
      copyToolStripMenuItem = new ToolStripMenuItem();
      saveFileAsToolStripMenuItem = new ToolStripMenuItem();
      saveSelectedToFileToolStripMenuItem = new ToolStripMenuItem();
      tabSQL = new TabPage();
      tbSQL = new FastColoredTextBoxNS.FastColoredTextBox();
      tabCSharp = new TabPage();
      tbCSharp = new FastColoredTextBoxNS.FastColoredTextBox();
      MenuStripCSharp = new ContextMenuStrip(components);
      toolStripMenuItem1 = new ToolStripMenuItem();
      toolStripMenuItem2 = new ToolStripMenuItem();
      edError = new FastColoredTextBoxNS.FastColoredTextBox();
      SD = new SaveFileDialog();
      tabControlMain.SuspendLayout();
      tabWelcome.SuspendLayout();
      tabBuildIt.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      tabControlTextEditors.SuspendLayout();
      MenuStripSql.SuspendLayout();
      tabSQL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)tbSQL).BeginInit();
      tabCSharp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)tbCSharp).BeginInit();
      MenuStripCSharp.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)edError).BeginInit();
      SuspendLayout();
      // 
      // ilMain
      // 
      ilMain.ColorDepth = ColorDepth.Depth8Bit;
      ilMain.ImageStream = (ImageListStreamer)resources.GetObject("ilMain.ImageStream");
      ilMain.TransparentColor = Color.Transparent;
      ilMain.Images.SetKeyName(0, "Network-Server-icon.png");
      ilMain.Images.SetKeyName(1, "Database-icon.png");
      ilMain.Images.SetKeyName(2, "folder-database-icon.png");
      ilMain.Images.SetKeyName(3, "database-table-icon.png");
      ilMain.Images.SetKeyName(4, "Database-Table-icon (1).png");
      ilMain.Images.SetKeyName(5, "server-components-icon.png");
      ilMain.Images.SetKeyName(6, "function-icon.png");
      ilMain.Images.SetKeyName(7, "list-components-icon.png");
      // 
      // tabControlMain
      // 
      tabControlMain.Controls.Add(tabWelcome);
      tabControlMain.Controls.Add(tabBuildIt);
      tabControlMain.Dock = DockStyle.Fill;
      tabControlMain.Location = new Point(0, 0);
      tabControlMain.Name = "tabControlMain";
      tabControlMain.SelectedIndex = 0;
      tabControlMain.Size = new Size(804, 553);
      tabControlMain.TabIndex = 1;
      tabControlMain.SelectedIndexChanged += tabControlMain_SelectedIndexChanged;
      // 
      // tabWelcome
      // 
      tabWelcome.BackColor = Color.Gray;
      tabWelcome.Controls.Add(btnRemoveConnection);
      tabWelcome.Controls.Add(btnSaveCon);
      tabWelcome.Controls.Add(edPassword);
      tabWelcome.Controls.Add(edUserName);
      tabWelcome.Controls.Add(edDatabase);
      tabWelcome.Controls.Add(edServer);
      tabWelcome.Controls.Add(label6);
      tabWelcome.Controls.Add(label5);
      tabWelcome.Controls.Add(label4);
      tabWelcome.Controls.Add(label3);
      tabWelcome.Controls.Add(label2);
      tabWelcome.Controls.Add(edConName);
      tabWelcome.Controls.Add(listBox1);
      tabWelcome.Controls.Add(label1);
      tabWelcome.ForeColor = Color.White;
      tabWelcome.Location = new Point(4, 24);
      tabWelcome.Margin = new Padding(0);
      tabWelcome.Name = "tabWelcome";
      tabWelcome.Size = new Size(796, 525);
      tabWelcome.TabIndex = 0;
      tabWelcome.Text = "Welcome";
      // 
      // btnRemoveConnection
      // 
      btnRemoveConnection.ForeColor = Color.Red;
      btnRemoveConnection.Location = new Point(61, 255);
      btnRemoveConnection.Name = "btnRemoveConnection";
      btnRemoveConnection.Size = new Size(54, 23);
      btnRemoveConnection.TabIndex = 13;
      btnRemoveConnection.Text = "Remove";
      btnRemoveConnection.UseVisualStyleBackColor = true;
      btnRemoveConnection.Visible = false;
      btnRemoveConnection.Click += btnRemoveConnection_Click;
      // 
      // btnSaveCon
      // 
      btnSaveCon.ForeColor = Color.Red;
      btnSaveCon.Location = new Point(389, 234);
      btnSaveCon.Name = "btnSaveCon";
      btnSaveCon.Size = new Size(54, 23);
      btnSaveCon.TabIndex = 12;
      btnSaveCon.Text = "Save";
      btnSaveCon.UseVisualStyleBackColor = true;
      btnSaveCon.Visible = false;
      btnSaveCon.Click += btnSaveCon_Click;
      // 
      // edPassword
      // 
      edPassword.Location = new Point(389, 195);
      edPassword.Name = "edPassword";
      edPassword.Size = new Size(261, 23);
      edPassword.TabIndex = 11;
      edPassword.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edUserName
      // 
      edUserName.Location = new Point(389, 167);
      edUserName.Name = "edUserName";
      edUserName.Size = new Size(261, 23);
      edUserName.TabIndex = 10;
      edUserName.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edDatabase
      // 
      edDatabase.Location = new Point(389, 140);
      edDatabase.Name = "edDatabase";
      edDatabase.Size = new Size(261, 23);
      edDatabase.TabIndex = 9;
      edDatabase.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edServer
      // 
      edServer.Location = new Point(389, 112);
      edServer.Name = "edServer";
      edServer.Size = new Size(261, 23);
      edServer.TabIndex = 8;
      edServer.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new Point(262, 195);
      label6.Name = "label6";
      label6.Size = new Size(83, 15);
      label6.TabIndex = 7;
      label6.Text = "User Password";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(262, 167);
      label5.Name = "label5";
      label5.Size = new Size(65, 15);
      label5.TabIndex = 6;
      label5.Text = "User Name";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(262, 140);
      label4.Name = "label4";
      label4.Size = new Size(55, 15);
      label4.TabIndex = 5;
      label4.Text = "Database";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(262, 112);
      label3.Name = "label3";
      label3.Size = new Size(39, 15);
      label3.TabIndex = 4;
      label3.Text = "Server";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(262, 84);
      label2.Name = "label2";
      label2.Size = new Size(107, 15);
      label2.TabIndex = 3;
      label2.Text = "Connection Name ";
      // 
      // edConName
      // 
      edConName.Location = new Point(389, 84);
      edConName.Name = "edConName";
      edConName.Size = new Size(261, 23);
      edConName.TabIndex = 2;
      edConName.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // listBox1
      // 
      listBox1.BorderStyle = BorderStyle.None;
      listBox1.FormattingEnabled = true;
      listBox1.ItemHeight = 15;
      listBox1.Location = new Point(61, 87);
      listBox1.Name = "listBox1";
      listBox1.Size = new Size(181, 150);
      listBox1.TabIndex = 1;
      listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(38, 49);
      label1.Name = "label1";
      label1.Size = new Size(105, 21);
      label1.TabIndex = 0;
      label1.Text = "Connections ";
      // 
      // tabBuildIt
      // 
      tabBuildIt.BackColor = Color.FromArgb(64, 64, 64);
      tabBuildIt.BorderStyle = BorderStyle.FixedSingle;
      tabBuildIt.Controls.Add(splitContainer1);
      tabBuildIt.Location = new Point(4, 24);
      tabBuildIt.Margin = new Padding(2);
      tabBuildIt.Name = "tabBuildIt";
      tabBuildIt.Size = new Size(796, 525);
      tabBuildIt.TabIndex = 1;
      tabBuildIt.Text = "Build It";
      tabBuildIt.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      splitContainer1.BackColor = Color.FromArgb(64, 64, 64);
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(0, 0);
      splitContainer1.Name = "splitContainer1";
      splitContainer1.Orientation = Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.AutoScroll = true;
      splitContainer1.Panel2.BackColor = Color.FromArgb(64, 64, 64);
      splitContainer1.Panel2.Controls.Add(edError);
      splitContainer1.Size = new Size(794, 523);
      splitContainer1.SplitterDistance = 436;
      splitContainer1.SplitterWidth = 3;
      splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      splitContainer2.Dock = DockStyle.Fill;
      splitContainer2.Location = new Point(0, 0);
      splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      splitContainer2.Panel1.Controls.Add(panel1);
      splitContainer2.Panel1.Controls.Add(tvMain);
      // 
      // splitContainer2.Panel2
      // 
      splitContainer2.Panel2.Controls.Add(tabControlTextEditors);
      splitContainer2.Size = new Size(794, 436);
      splitContainer2.SplitterDistance = 243;
      splitContainer2.TabIndex = 0;
      // 
      // panel1
      // 
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Name = "panel1";
      panel1.Size = new Size(243, 25);
      panel1.TabIndex = 1;
      // 
      // tvMain
      // 
      tvMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tvMain.BackColor = Color.FromArgb(64, 64, 64);
      tvMain.BorderStyle = BorderStyle.None;
      tvMain.ForeColor = Color.FromArgb(224, 224, 224);
      tvMain.ImageIndex = 0;
      tvMain.ImageList = ilMain;
      tvMain.LineColor = Color.FromArgb(224, 224, 224);
      tvMain.Location = new Point(0, 26);
      tvMain.Name = "tvMain";
      tvMain.SelectedImageIndex = 0;
      tvMain.Size = new Size(241, 412);
      tvMain.TabIndex = 0;
      tvMain.BeforeExpand += TvMain_BeforeExpand;
      tvMain.AfterSelect += tvMain_AfterSelect;
      // 
      // tabControlTextEditors
      // 
      tabControlTextEditors.ContextMenuStrip = MenuStripSql;
      tabControlTextEditors.Controls.Add(tabSQL);
      tabControlTextEditors.Controls.Add(tabCSharp);
      tabControlTextEditors.Dock = DockStyle.Fill;
      tabControlTextEditors.Location = new Point(0, 0);
      tabControlTextEditors.Margin = new Padding(0);
      tabControlTextEditors.Name = "tabControlTextEditors";
      tabControlTextEditors.Padding = new Point(6, 2);
      tabControlTextEditors.SelectedIndex = 0;
      tabControlTextEditors.Size = new Size(547, 436);
      tabControlTextEditors.TabIndex = 0;
      tabControlTextEditors.Selected += tabControlTextEditors_Selected;
      // 
      // MenuStripSql
      // 
      MenuStripSql.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, saveFileAsToolStripMenuItem, saveSelectedToFileToolStripMenuItem });
      MenuStripSql.Name = "MenuStripSql";
      MenuStripSql.Size = new Size(182, 92);
      MenuStripSql.Text = "Copy";
      MenuStripSql.Opening += MenuStripSql_Opening;
      // 
      // copyToolStripMenuItem
      // 
      copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      copyToolStripMenuItem.Size = new Size(181, 22);
      copyToolStripMenuItem.Text = "Copy";
      copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
      // 
      // saveFileAsToolStripMenuItem
      // 
      saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
      saveFileAsToolStripMenuItem.Size = new Size(181, 22);
      saveFileAsToolStripMenuItem.Text = "Execute Selected Sql";
      saveFileAsToolStripMenuItem.Click += MenuExecuteSql_ClickAsync;
      // 
      // saveSelectedToFileToolStripMenuItem
      // 
      saveSelectedToFileToolStripMenuItem.Name = "saveSelectedToFileToolStripMenuItem";
      saveSelectedToFileToolStripMenuItem.Size = new Size(181, 22);
      saveSelectedToFileToolStripMenuItem.Text = "Save Selected to File";
      saveSelectedToFileToolStripMenuItem.Click += saveSelectedToFileToolStripMenuItem_Click;
      // 
      // tabSQL
      // 
      tabSQL.Controls.Add(tbSQL);
      tabSQL.Location = new Point(4, 22);
      tabSQL.Name = "tabSQL";
      tabSQL.Padding = new Padding(3);
      tabSQL.Size = new Size(539, 410);
      tabSQL.TabIndex = 1;
      tabSQL.Text = "SQL";
      tabSQL.UseVisualStyleBackColor = true;
      // 
      // tbSQL
      // 
      tbSQL.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      tbSQL.AutoIndent = false;
      tbSQL.AutoIndentCharsPatterns = "";
      tbSQL.AutoScrollMinSize = new Size(67, 14);
      tbSQL.BackBrush = null;
      tbSQL.BackColor = Color.Black;
      tbSQL.CaretColor = Color.White;
      tbSQL.CharHeight = 14;
      tbSQL.CharWidth = 8;
      tbSQL.CommentPrefix = "--";
      tbSQL.ContextMenuStrip = MenuStripSql;
      tbSQL.CurrentLineColor = Color.FromArgb(64, 64, 64);
      tbSQL.DefaultMarkerSize = 8;
      tbSQL.DisabledColor = Color.FromArgb(100, 180, 180, 180);
      tbSQL.Dock = DockStyle.Fill;
      tbSQL.FindForm = null;
      tbSQL.ForeColor = Color.White;
      tbSQL.GoToForm = null;
      tbSQL.Hotkeys = resources.GetString("tbSQL.Hotkeys");
      tbSQL.IndentBackColor = Color.FromArgb(64, 64, 64);
      tbSQL.IsReplaceMode = false;
      tbSQL.Language = FastColoredTextBoxNS.Text.Language.SQL;
      tbSQL.LeftBracket = '(';
      tbSQL.LineNumberColor = Color.Gold;
      tbSQL.Location = new Point(3, 3);
      tbSQL.Margin = new Padding(0);
      tbSQL.Name = "tbSQL";
      tbSQL.Paddings = new Padding(0);
      tbSQL.ReplaceForm = null;
      tbSQL.RightBracket = ')';
      tbSQL.SelectionColor = Color.FromArgb(120, 192, 255, 255);
      tbSQL.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("tbSQL.ServiceColors");
      tbSQL.Size = new Size(533, 404);
      tbSQL.TabIndex = 0;
      tbSQL.Text = "tbSQL";
      tbSQL.TextAreaBorderColor = Color.FromArgb(64, 64, 64);
      tbSQL.Zoom = 100;
      // 
      // tabCSharp
      // 
      tabCSharp.Controls.Add(tbCSharp);
      tabCSharp.Location = new Point(4, 22);
      tabCSharp.Name = "tabCSharp";
      tabCSharp.Size = new Size(539, 410);
      tabCSharp.TabIndex = 2;
      tabCSharp.Text = "C#";
      tabCSharp.UseVisualStyleBackColor = true;
      // 
      // tbCSharp
      // 
      tbCSharp.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      tbCSharp.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      tbCSharp.AutoScrollMinSize = new Size(179, 14);
      tbCSharp.BackBrush = null;
      tbCSharp.BackColor = Color.Black;
      tbCSharp.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      tbCSharp.CaretColor = Color.White;
      tbCSharp.CharHeight = 14;
      tbCSharp.CharWidth = 8;
      tbCSharp.ContextMenuStrip = MenuStripCSharp;
      tbCSharp.DefaultMarkerSize = 8;
      tbCSharp.DisabledColor = Color.FromArgb(100, 180, 180, 180);
      tbCSharp.Dock = DockStyle.Fill;
      tbCSharp.FindForm = null;
      tbCSharp.ForeColor = Color.White;
      tbCSharp.GoToForm = null;
      tbCSharp.Hotkeys = resources.GetString("tbCSharp.Hotkeys");
      tbCSharp.IndentBackColor = Color.FromArgb(64, 64, 64);
      tbCSharp.IsReplaceMode = false;
      tbCSharp.Language = FastColoredTextBoxNS.Text.Language.CSharp;
      tbCSharp.LeftBracket = '(';
      tbCSharp.LeftBracket2 = '{';
      tbCSharp.LineNumberColor = Color.Gold;
      tbCSharp.Location = new Point(0, 0);
      tbCSharp.Name = "tbCSharp";
      tbCSharp.Paddings = new Padding(0);
      tbCSharp.ReplaceForm = null;
      tbCSharp.RightBracket = ')';
      tbCSharp.RightBracket2 = '}';
      tbCSharp.SelectionColor = Color.FromArgb(123, 192, 255, 255);
      tbCSharp.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("tbCSharp.ServiceColors");
      tbCSharp.Size = new Size(539, 410);
      tbCSharp.TabIndex = 0;
      tbCSharp.Text = "fastColoredTextBox1";
      tbCSharp.Zoom = 100;
      // 
      // MenuStripCSharp
      // 
      MenuStripCSharp.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
      MenuStripCSharp.Name = "MenuStripSql";
      MenuStripCSharp.Size = new Size(136, 48);
      MenuStripCSharp.Text = "Copy";
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new Size(135, 22);
      toolStripMenuItem1.Text = "Copy";
      // 
      // toolStripMenuItem2
      // 
      toolStripMenuItem2.Name = "toolStripMenuItem2";
      toolStripMenuItem2.Size = new Size(135, 22);
      toolStripMenuItem2.Text = "Save File As";
      toolStripMenuItem2.Click += toolStripMenuItem2_Click;
      // 
      // edError
      // 
      edError.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      edError.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      edError.AutoScrollMinSize = new Size(27, 14);
      edError.BackBrush = null;
      edError.BackColor = Color.Black;
      edError.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      edError.CaretColor = Color.White;
      edError.CharHeight = 14;
      edError.CharWidth = 8;
      edError.DefaultMarkerSize = 8;
      edError.DisabledColor = Color.FromArgb(100, 180, 180, 180);
      edError.Dock = DockStyle.Fill;
      edError.FindForm = null;
      edError.ForeColor = Color.White;
      edError.GoToForm = null;
      edError.Hotkeys = resources.GetString("edError.Hotkeys");
      edError.IndentBackColor = Color.FromArgb(64, 64, 64);
      edError.IsReplaceMode = false;
      edError.Language = FastColoredTextBoxNS.Text.Language.CSharp;
      edError.LeftBracket = '(';
      edError.LeftBracket2 = '{';
      edError.LineNumberColor = Color.Gold;
      edError.Location = new Point(0, 0);
      edError.Name = "edError";
      edError.Paddings = new Padding(0);
      edError.ReplaceForm = null;
      edError.RightBracket = ')';
      edError.RightBracket2 = '}';
      edError.SelectionColor = Color.FromArgb(60, 0, 0, 255);
      edError.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("edError.ServiceColors");
      edError.Size = new Size(794, 84);
      edError.TabIndex = 2;
      edError.Zoom = 100;
      // 
      // SD
      // 
      SD.DefaultExt = "*.cs";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(64, 64, 64);
      ClientSize = new Size(804, 553);
      Controls.Add(tabControlMain);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Name = "MainForm";
      Text = "DBWorkshop - Set Connection Strings";
      Shown += MainForm_Shown;
      tabControlMain.ResumeLayout(false);
      tabWelcome.ResumeLayout(false);
      tabWelcome.PerformLayout();
      tabBuildIt.ResumeLayout(false);
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      splitContainer2.Panel1.ResumeLayout(false);
      splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
      splitContainer2.ResumeLayout(false);
      tabControlTextEditors.ResumeLayout(false);
      MenuStripSql.ResumeLayout(false);
      tabSQL.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)tbSQL).EndInit();
      tabCSharp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)tbCSharp).EndInit();
      MenuStripCSharp.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)edError).EndInit();
      ResumeLayout(false);
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
    private TabControl tabControlTextEditors;
    private TabPage tabSQL;
    private TabPage tabCSharp;
    private Button btnSaveCon;
    private TextBox edPassword;
    private TextBox edUserName;
    private TextBox edDatabase;
    private TextBox edServer;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private TextBox edConName;
    private ListBox listBox1;
    private Label label1;
    private FastColoredTextBoxNS.FastColoredTextBox tbSQL;
    private FastColoredTextBoxNS.FastColoredTextBox tbCSharp;
    private Button btnRemoveConnection;
    private FastColoredTextBoxNS.FastColoredTextBox edError;
    private ContextMenuStrip MenuStripSql;
    private ToolStripMenuItem copyToolStripMenuItem;
    private ToolStripMenuItem saveFileAsToolStripMenuItem;
    private SaveFileDialog SD;
    private ContextMenuStrip MenuStripCSharp;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem saveSelectedToFileToolStripMenuItem;
  }
}