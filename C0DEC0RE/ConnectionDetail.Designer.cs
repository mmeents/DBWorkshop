﻿namespace C0DEC0RE
{
  partial class ConnectionDetail
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
      if (disposing && (components != null))
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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(180, 14);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(302, 26);
      this.textBox1.TabIndex = 0;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(180, 51);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(302, 26);
      this.textBox2.TabIndex = 1;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(180, 89);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(302, 26);
      this.textBox3.TabIndex = 2;
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(180, 127);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(302, 26);
      this.textBox4.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 20);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(136, 20);
      this.label1.TabIndex = 4;
      this.label1.Text = "Connection Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 54);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(95, 20);
      this.label2.TabIndex = 5;
      this.label2.Text = "SQL Server ";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 92);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 20);
      this.label3.TabIndex = 6;
      this.label3.Text = "Database";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 130);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(128, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Connect as User";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 169);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(78, 20);
      this.label5.TabIndex = 8;
      this.label5.Text = "Password";
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(180, 166);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(302, 26);
      this.textBox5.TabIndex = 9;
      // 
      // button1
      // 
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Location = new System.Drawing.Point(105, 255);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(119, 49);
      this.button1.TabIndex = 10;
      this.button1.Text = "OK Save";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button2.Location = new System.Drawing.Point(241, 255);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(119, 49);
      this.button2.TabIndex = 11;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // ConnectionDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 366);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.textBox5);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox4);
      this.Controls.Add(this.textBox3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.Name = "ConnectionDetail";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ConnectionDetail";
      this.Shown += new System.EventHandler(this.ConnectionDetail_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}