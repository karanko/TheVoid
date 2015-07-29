namespace LowDefinition
{
    partial class LowWindow
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
            this.Data = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Data
            // 
            this.Data.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Data.ForeColor = System.Drawing.SystemColors.Window;
            this.Data.Location = new System.Drawing.Point(0, 0);
            this.Data.Multiline = true;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Data.Size = new System.Drawing.Size(417, 266);
            this.Data.TabIndex = 0;
            this.Data.WordWrap = false;
            // 
            // LowWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 266);
            this.Controls.Add(this.Data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LowWindow";
            this.Text = "LowWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LowWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Data;
    }
}