namespace TheVoid.Tracker
{
    partial class Console
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
            this.Window = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Window
            // 
            this.Window.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Window.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Window.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Window.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Window.ForeColor = System.Drawing.SystemColors.Window;
            this.Window.Location = new System.Drawing.Point(0, 0);
            this.Window.Multiline = true;
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(240, 569);
            this.Window.TabIndex = 0;
            this.Window.WordWrap = false;
            this.Window.TextChanged += new System.EventHandler(this.Window_TextChanged);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 569);
            this.Controls.Add(this.Window);
            this.Name = "Console";
            this.Text = "Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Window;
    }
}