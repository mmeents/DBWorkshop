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
      tabControlMain.Margin = new Padding(3, 4, 3, 4);
      tabControlMain.Name = "tabControlMain";
      tabControlMain.SelectedIndex = 0;
      tabControlMain.Size = new Size(919, 737);
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
      tabWelcome.Location = new Point(4, 29);
      tabWelcome.Margin = new Padding(0);
      tabWelcome.Name = "tabWelcome";
      tabWelcome.Size = new Size(911, 704);
      tabWelcome.TabIndex = 0;
      tabWelcome.Text = "Welcome";
      tabWelcome.Click += tabWelcome_Click;
      // 
      // btnRemoveConnection
      // 
      btnRemoveConnection.ForeColor = Color.Red;
      btnRemoveConnection.Location = new Point(70, 340);
      btnRemoveConnection.Margin = new Padding(3, 4, 3, 4);
      btnRemoveConnection.Name = "btnRemoveConnection";
      btnRemoveConnection.Size = new Size(62, 31);
      btnRemoveConnection.TabIndex = 13;
      btnRemoveConnection.Text = "Remove";
      btnRemoveConnection.UseVisualStyleBackColor = true;
      btnRemoveConnection.Visible = false;
      btnRemoveConnection.Click += btnRemoveConnection_Click;
      // 
      // btnSaveCon
      // 
      btnSaveCon.ForeColor = Color.Red;
      btnSaveCon.Location = new Point(445, 312);
      btnSaveCon.Margin = new Padding(3, 4, 3, 4);
      btnSaveCon.Name = "btnSaveCon";
      btnSaveCon.Size = new Size(62, 31);
      btnSaveCon.TabIndex = 12;
      btnSaveCon.Text = "Save";
      btnSaveCon.UseVisualStyleBackColor = true;
      btnSaveCon.Visible = false;
      btnSaveCon.Click += btnSaveCon_Click;
      // 
      // edPassword
      // 
      edPassword.Location = new Point(445, 260);
      edPassword.Margin = new Padding(3, 4, 3, 4);
      edPassword.Name = "edPassword";
      edPassword.Size = new Size(298, 27);
      edPassword.TabIndex = 11;
      edPassword.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edUserName
      // 
      edUserName.Location = new Point(445, 223);
      edUserName.Margin = new Padding(3, 4, 3, 4);
      edUserName.Name = "edUserName";
      edUserName.Size = new Size(298, 27);
      edUserName.TabIndex = 10;
      edUserName.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edDatabase
      // 
      edDatabase.Location = new Point(445, 187);
      edDatabase.Margin = new Padding(3, 4, 3, 4);
      edDatabase.Name = "edDatabase";
      edDatabase.Size = new Size(298, 27);
      edDatabase.TabIndex = 9;
      edDatabase.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // edServer
      // 
      edServer.Location = new Point(445, 149);
      edServer.Margin = new Padding(3, 4, 3, 4);
      edServer.Name = "edServer";
      edServer.Size = new Size(298, 27);
      edServer.TabIndex = 8;
      edServer.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new Point(299, 260);
      label6.Name = "label6";
      label6.Size = new Size(103, 20);
      label6.TabIndex = 7;
      label6.Text = "User Password";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(299, 223);
      label5.Name = "label5";
      label5.Size = new Size(82, 20);
      label5.TabIndex = 6;
      label5.Text = "User Name";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(299, 187);
      label4.Name = "label4";
      label4.Size = new Size(72, 20);
      label4.TabIndex = 5;
      label4.Text = "Database";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(299, 149);
      label3.Name = "label3";
      label3.Size = new Size(50, 20);
      label3.TabIndex = 4;
      label3.Text = "Server";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(299, 112);
      label2.Name = "label2";
      label2.Size = new Size(132, 20);
      label2.TabIndex = 3;
      label2.Text = "Connection Name ";
      // 
      // edConName
      // 
      edConName.Location = new Point(445, 112);
      edConName.Margin = new Padding(3, 4, 3, 4);
      edConName.Name = "edConName";
      edConName.Size = new Size(298, 27);
      edConName.TabIndex = 2;
      edConName.ModifiedChanged += tbConName_ModifiedChanged;
      // 
      // listBox1
      // 
      listBox1.BorderStyle = BorderStyle.None;
      listBox1.FormattingEnabled = true;
      listBox1.ItemHeight = 20;
      listBox1.Location = new Point(70, 116);
      listBox1.Margin = new Padding(3, 4, 3, 4);
      listBox1.Name = "listBox1";
      listBox1.Size = new Size(207, 200);
      listBox1.TabIndex = 1;
      listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(43, 65);
      label1.Name = "label1";
      label1.Size = new Size(131, 28);
      label1.TabIndex = 0;
      label1.Text = "Connections ";
      // 
      // tabBuildIt
      // 
      tabBuildIt.BackColor = Color.FromArgb(64, 64, 64);
      tabBuildIt.BorderStyle = BorderStyle.FixedSingle;
      tabBuildIt.Controls.Add(splitContainer1);
      tabBuildIt.Location = new Point(4, 29);
      tabBuildIt.Margin = new Padding(2, 3, 2, 3);
      tabBuildIt.Name = "tabBuildIt";
      tabBuildIt.Size = new Size(911, 704);
      tabBuildIt.TabIndex = 1;
      tabBuildIt.Text = "Build It";
      tabBuildIt.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      splitContainer1.BackColor = Color.FromArgb(64, 64, 64);
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.Location = new Point(0, 0);
      splitContainer1.Margin = new Padding(3, 4, 3, 4);
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
      splitContainer1.Size = new Size(909, 702);
      splitContainer1.SplitterDistance = 585;
      splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      splitContainer2.Dock = DockStyle.Fill;
      splitContainer2.Location = new Point(0, 0);
      splitContainer2.Margin = new Padding(3, 4, 3, 4);
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
      splitContainer2.Size = new Size(909, 585);
      splitContainer2.SplitterDistance = 278;
      splitContainer2.SplitterWidth = 5;
      splitContainer2.TabIndex = 0;
      // 
      // panel1
      // 
      panel1.Dock = DockStyle.Top;
      panel1.Location = new Point(0, 0);
      panel1.Margin = new Padding(3, 4, 3, 4);
      panel1.Name = "panel1";
      panel1.Size = new Size(278, 33);
      panel1.TabIndex = 1;
      // 
      // tvMain
      // 
      tvMain.BackColor = Color.FromArgb(64, 64, 64);
      tvMain.BorderStyle = BorderStyle.None;
      tvMain.Dock = DockStyle.Bottom;
      tvMain.ForeColor = Color.FromArgb(224, 224, 224);
      tvMain.ImageIndex = 0;
      tvMain.ImageList = ilMain;
      tvMain.LineColor = Color.FromArgb(224, 224, 224);
      tvMain.Location = new Point(0, 32);
      tvMain.Margin = new Padding(3, 4, 3, 4);
      tvMain.Name = "tvMain";
      tvMain.SelectedImageIndex = 0;
      tvMain.Size = new Size(278, 553);
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
      tabControlTextEditors.Size = new Size(626, 585);
      tabControlTextEditors.TabIndex = 0;
      tabControlTextEditors.Selected += tabControlTextEditors_Selected;
      // 
      // MenuStripSql
      // 
      MenuStripSql.ImageScalingSize = new Size(20, 20);
      MenuStripSql.Items.AddRange(new ToolStripItem[] { copyToolStripMenuItem, saveFileAsToolStripMenuItem, saveSelectedToFileToolStripMenuItem });
      MenuStripSql.Name = "MenuStripSql";
      MenuStripSql.Size = new Size(216, 76);
      MenuStripSql.Text = "Copy";
      MenuStripSql.Opening += MenuStripSql_Opening;
      // 
      // copyToolStripMenuItem
      // 
      copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      copyToolStripMenuItem.Size = new Size(215, 24);
      copyToolStripMenuItem.Text = "Copy";
      copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
      // 
      // saveFileAsToolStripMenuItem
      // 
      saveFileAsToolStripMenuItem.Name = "saveFileAsToolStripMenuItem";
      saveFileAsToolStripMenuItem.Size = new Size(215, 24);
      saveFileAsToolStripMenuItem.Text = "Execute Selected Sql";
      saveFileAsToolStripMenuItem.Click += MenuExecuteSql_ClickAsync;
      // 
      // saveSelectedToFileToolStripMenuItem
      // 
      saveSelectedToFileToolStripMenuItem.Name = "saveSelectedToFileToolStripMenuItem";
      saveSelectedToFileToolStripMenuItem.Size = new Size(215, 24);
      saveSelectedToFileToolStripMenuItem.Text = "Save Selected to File";
      saveSelectedToFileToolStripMenuItem.Click += saveSelectedToFileToolStripMenuItem_Click;
      // 
      // tabSQL
      // 
      tabSQL.Controls.Add(tbSQL);
      tabSQL.Location = new Point(4, 27);
      tabSQL.Margin = new Padding(3, 4, 3, 4);
      tabSQL.Name = "tabSQL";
      tabSQL.Padding = new Padding(3, 4, 3, 4);
      tabSQL.Size = new Size(618, 554);
      tabSQL.TabIndex = 1;
      tabSQL.Text = "SQL";
      tabSQL.UseVisualStyleBackColor = true;
      // 
      // tbSQL
      // 
      tbSQL.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      tbSQL.AutoIndent = false;
      tbSQL.AutoIndentCharsPatterns = "";
      tbSQL.AutoScrollMinSize = new Size(52, 18);
      tbSQL.BackBrush = null;
      tbSQL.BackColor = Color.Black;
      tbSQL.CaretColor = Color.White;
      tbSQL.CharHeight = 18;
      tbSQL.CharWidth = 10;
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
      tbSQL.Location = new Point(3, 4);
      tbSQL.Margin = new Padding(0);
      tbSQL.Name = "tbSQL";
      tbSQL.Paddings = new Padding(0);
      tbSQL.ReplaceForm = null;
      tbSQL.RightBracket = ')';
      tbSQL.SelectionColor = Color.FromArgb(120, 192, 255, 255);
      tbSQL.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("tbSQL.ServiceColors");
      tbSQL.Size = new Size(612, 546);
      tbSQL.TabIndex = 0;
      tbSQL.Text = "tbSQL";
      tbSQL.TextAreaBorderColor = Color.FromArgb(64, 64, 64);
      tbSQL.Zoom = 100;
      // 
      // tabCSharp
      // 
      tabCSharp.Controls.Add(tbCSharp);
      tabCSharp.Location = new Point(4, 27);
      tabCSharp.Margin = new Padding(3, 4, 3, 4);
      tabCSharp.Name = "tabCSharp";
      tabCSharp.Size = new Size(618, 554);
      tabCSharp.TabIndex = 2;
      tabCSharp.Text = "C#";
      tabCSharp.UseVisualStyleBackColor = true;
      // 
      // tbCSharp
      // 
      tbCSharp.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      tbCSharp.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      tbCSharp.AutoScrollMinSize = new Size(192, 18);
      tbCSharp.BackBrush = null;
      tbCSharp.BackColor = Color.Black;
      tbCSharp.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      tbCSharp.CaretColor = Color.White;
      tbCSharp.CharHeight = 18;
      tbCSharp.CharWidth = 10;
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
      tbCSharp.Margin = new Padding(3, 4, 3, 4);
      tbCSharp.Name = "tbCSharp";
      tbCSharp.Paddings = new Padding(0);
      tbCSharp.ReplaceForm = null;
      tbCSharp.RightBracket = ')';
      tbCSharp.RightBracket2 = '}';
      tbCSharp.SelectionColor = Color.FromArgb(123, 192, 255, 255);
      tbCSharp.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("tbCSharp.ServiceColors");
      tbCSharp.Size = new Size(618, 554);
      tbCSharp.TabIndex = 0;
      tbCSharp.Text = "fastColoredTextBox1";
      tbCSharp.Zoom = 100;
      // 
      // MenuStripCSharp
      // 
      MenuStripCSharp.ImageScalingSize = new Size(20, 20);
      MenuStripCSharp.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
      MenuStripCSharp.Name = "MenuStripSql";
      MenuStripCSharp.Size = new Size(157, 52);
      MenuStripCSharp.Text = "Copy";
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new Size(156, 24);
      toolStripMenuItem1.Text = "Copy";
      // 
      // toolStripMenuItem2
      // 
      toolStripMenuItem2.Name = "toolStripMenuItem2";
      toolStripMenuItem2.Size = new Size(156, 24);
      toolStripMenuItem2.Text = "Save File As";
      toolStripMenuItem2.Click += toolStripMenuItem2_Click;
      // 
      // edError
      // 
      edError.AutoCompleteBracketsList = new char[] { '(', ')', '{', '}', '[', ']', '"', '"', '\'', '\'' };
      edError.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
      edError.AutoScrollMinSize = new Size(2, 18);
      edError.BackBrush = null;
      edError.BackColor = Color.Black;
      edError.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
      edError.CaretColor = Color.White;
      edError.CharHeight = 18;
      edError.CharWidth = 10;
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
      edError.Margin = new Padding(3, 4, 3, 4);
      edError.Name = "edError";
      edError.Paddings = new Padding(0);
      edError.ReplaceForm = null;
      edError.RightBracket = ')';
      edError.RightBracket2 = '}';
      edError.SelectionColor = Color.FromArgb(60, 0, 0, 255);
      edError.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("edError.ServiceColors");
      edError.Size = new Size(909, 113);
      edError.TabIndex = 2;
      edError.Zoom = 100;
      // 
      // SD
      // 
      SD.DefaultExt = "*.cs";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(8F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(64, 64, 64);
      ClientSize = new Size(919, 737);
      Controls.Add(tabControlMain);
      Icon = (Icon)resources.GetObject("$this.Icon");
      Margin = new Padding(3, 4, 3, 4);
      Name = "MainForm";
      Text = "DBWorkshop - Set Connection Strings";
      Shown += MainForm_Shown;
      Resize += MainForm_Resize;
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