namespace TheVoid.CosmicController
{
    partial class ExecutionForm
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
            this.Command = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ResultPage = new System.Windows.Forms.TabPage();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.MessagePage = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ResultPage.SuspendLayout();
            this.MessagePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Command
            // 
            this.Command.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Command.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Command.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command.Location = new System.Drawing.Point(0, 0);
            this.Command.Multiline = true;
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(739, 292);
            this.Command.TabIndex = 0;
            this.Command.TextChanged += new System.EventHandler(this.Command_TextChanged);
            this.Command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Command);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(739, 535);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ResultPage);
            this.tabControl1.Controls.Add(this.MessagePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 239);
            this.tabControl1.TabIndex = 0;
            // 
            // ResultPage
            // 
            this.ResultPage.Controls.Add(this.ResultTextBox);
            this.ResultPage.Location = new System.Drawing.Point(4, 22);
            this.ResultPage.Name = "ResultPage";
            this.ResultPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResultPage.Size = new System.Drawing.Size(731, 213);
            this.ResultPage.TabIndex = 0;
            this.ResultPage.Text = "Result";
            this.ResultPage.UseVisualStyleBackColor = true;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTextBox.Location = new System.Drawing.Point(3, 3);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(725, 207);
            this.ResultTextBox.TabIndex = 0;
            // 
            // MessagePage
            // 
            this.MessagePage.Controls.Add(this.listBox1);
            this.MessagePage.Location = new System.Drawing.Point(4, 22);
            this.MessagePage.Name = "MessagePage";
            this.MessagePage.Padding = new System.Windows.Forms.Padding(3);
            this.MessagePage.Size = new System.Drawing.Size(731, 213);
            this.MessagePage.TabIndex = 1;
            this.MessagePage.Text = "Messages";
            this.MessagePage.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(725, 207);
            this.listBox1.TabIndex = 0;
            // 
            // ExecutionForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 535);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ExecutionForm";
            this.ShowIcon = false;
            this.Text = "TheVoid.RemoteExecution";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResultPage.ResumeLayout(false);
            this.ResultPage.PerformLayout();
            this.MessagePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Command;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ResultPage;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.TabPage MessagePage;
        private System.Windows.Forms.ListBox listBox1;

    }
}

