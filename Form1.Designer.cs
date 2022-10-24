namespace dbWorkshop
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tvMain = new System.Windows.Forms.TreeView();
      this.cmsDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.addConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dropConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ilMain = new System.Windows.Forms.ImageList(this.components);
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.edSQL = new System.Windows.Forms.TextBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.edC = new System.Windows.Forms.TextBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.edSQLCursor = new System.Windows.Forms.TextBox();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.edScratch = new System.Windows.Forms.TextBox();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.edWiki = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cmsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.cmsDatabase.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.tabPage4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.panel1.SuspendLayout();
      this.cmsItem.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(0, 49);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tvMain);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
      this.splitContainer1.Size = new System.Drawing.Size(815, 520);
      this.splitContainer1.SplitterDistance = 199;
      this.splitContainer1.TabIndex = 0;
      // 
      // tvMain
      // 
      this.tvMain.ContextMenuStrip = this.cmsDatabase;
      this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tvMain.ImageIndex = 0;
      this.tvMain.ImageList = this.ilMain;
      this.tvMain.Location = new System.Drawing.Point(0, 0);
      this.tvMain.Name = "tvMain";
      this.tvMain.SelectedImageIndex = 0;
      this.tvMain.Size = new System.Drawing.Size(199, 520);
      this.tvMain.TabIndex = 0;
      this.tvMain.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMain_BeforeExpand);
      this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
      // 
      // cmsDatabase
      // 
      this.cmsDatabase.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.cmsDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConnectionToolStripMenuItem,
            this.dropConnectionToolStripMenuItem,
            this.editConnectionToolStripMenuItem});
      this.cmsDatabase.Name = "cmsDatabase";
      this.cmsDatabase.Size = new System.Drawing.Size(166, 70);
      // 
      // addConnectionToolStripMenuItem
      // 
      this.addConnectionToolStripMenuItem.Name = "addConnectionToolStripMenuItem";
      this.addConnectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.addConnectionToolStripMenuItem.Text = "Add Connection";
      this.addConnectionToolStripMenuItem.Click += new System.EventHandler(this.addConnectionToolStripMenuItem_Click);
      // 
      // dropConnectionToolStripMenuItem
      // 
      this.dropConnectionToolStripMenuItem.Name = "dropConnectionToolStripMenuItem";
      this.dropConnectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.dropConnectionToolStripMenuItem.Text = "Drop Connection";
      this.dropConnectionToolStripMenuItem.Click += new System.EventHandler(this.dropConnectionToolStripMenuItem_Click);
      // 
      // editConnectionToolStripMenuItem
      // 
      this.editConnectionToolStripMenuItem.Name = "editConnectionToolStripMenuItem";
      this.editConnectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
      this.editConnectionToolStripMenuItem.Text = "Edit Connection";
      this.editConnectionToolStripMenuItem.Click += new System.EventHandler(this.editConnectionToolStripMenuItem_Click);
      // 
      // ilMain
      // 
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
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Controls.Add(this.tabPage4);
      this.tabControl1.Controls.Add(this.tabPage5);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(612, 520);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.edSQL);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(604, 494);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "   SQL   ";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // edSQL
      // 
      this.edSQL.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edSQL.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edSQL.Location = new System.Drawing.Point(3, 3);
      this.edSQL.Multiline = true;
      this.edSQL.Name = "edSQL";
      this.edSQL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edSQL.Size = new System.Drawing.Size(598, 488);
      this.edSQL.TabIndex = 0;
      this.edSQL.WordWrap = false;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.edC);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(604, 494);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "   C#   ";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // edC
      // 
      this.edC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edC.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edC.Location = new System.Drawing.Point(3, 3);
      this.edC.Multiline = true;
      this.edC.Name = "edC";
      this.edC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edC.Size = new System.Drawing.Size(598, 488);
      this.edC.TabIndex = 2;
      this.edC.WordWrap = false;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.edSQLCursor);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(604, 494);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "SQL Cursor";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // edSQLCursor
      // 
      this.edSQLCursor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edSQLCursor.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edSQLCursor.Location = new System.Drawing.Point(3, 3);
      this.edSQLCursor.Multiline = true;
      this.edSQLCursor.Name = "edSQLCursor";
      this.edSQLCursor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edSQLCursor.Size = new System.Drawing.Size(598, 488);
      this.edSQLCursor.TabIndex = 3;
      this.edSQLCursor.WordWrap = false;
      // 
      // tabPage4
      // 
      this.tabPage4.Controls.Add(this.edScratch);
      this.tabPage4.Location = new System.Drawing.Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage4.Size = new System.Drawing.Size(604, 494);
      this.tabPage4.TabIndex = 3;
      this.tabPage4.Text = "Scratch";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // edScratch
      // 
      this.edScratch.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edScratch.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edScratch.Location = new System.Drawing.Point(3, 3);
      this.edScratch.Multiline = true;
      this.edScratch.Name = "edScratch";
      this.edScratch.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edScratch.Size = new System.Drawing.Size(598, 488);
      this.edScratch.TabIndex = 4;
      this.edScratch.WordWrap = false;
      // 
      // tabPage5
      // 
      this.tabPage5.Controls.Add(this.edWiki);
      this.tabPage5.Location = new System.Drawing.Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage5.Size = new System.Drawing.Size(604, 494);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Wiki";
      this.tabPage5.UseVisualStyleBackColor = true;
      // 
      // edWiki
      // 
      this.edWiki.Dock = System.Windows.Forms.DockStyle.Fill;
      this.edWiki.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edWiki.Location = new System.Drawing.Point(3, 3);
      this.edWiki.Multiline = true;
      this.edWiki.Name = "edWiki";
      this.edWiki.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.edWiki.Size = new System.Drawing.Size(598, 488);
      this.edWiki.TabIndex = 4;
      this.edWiki.WordWrap = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(815, 43);
      this.panel1.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(726, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(82, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "Save Scratch";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 14);
      this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "label1";
      // 
      // cmsItem
      // 
      this.cmsItem.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.cmsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
      this.cmsItem.Name = "cmsDatabase";
      this.cmsItem.Size = new System.Drawing.Size(181, 48);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.toolStripMenuItem1.Text = "Add Connection";
      this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(815, 570);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.splitContainer1);
      this.Name = "Form1";
      this.Text = "dbWorkshop";
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.cmsDatabase.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.cmsItem.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView tvMain;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox edSQL;
    private System.Windows.Forms.TextBox edC;
    private System.Windows.Forms.ImageList ilMain;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ContextMenuStrip cmsDatabase;
    private System.Windows.Forms.ToolStripMenuItem addConnectionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dropConnectionToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editConnectionToolStripMenuItem;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TextBox edSQLCursor;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TextBox edScratch;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ContextMenuStrip cmsItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.TextBox edWiki;
  }
}

