namespace TheVoid.CosmicController
{
    partial class CommandForm
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
            this.Command = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Command
            // 
            this.Command.AcceptsTab = true;
            this.Command.AutoWordSelection = true;
            this.Command.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.Command.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Command.DetectUrls = false;
            this.Command.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(209)))), ((int)(((byte)(210)))));
            this.Command.Location = new System.Drawing.Point(0, 0);
            this.Command.Margin = new System.Windows.Forms.Padding(10);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(606, 346);
            this.Command.TabIndex = 0;
            this.Command.Text = "";
            this.Command.TextChanged += new System.EventHandler(this.Command_TextChanged);
            this.Command.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Command_KeyDown);
            // 
            // CommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 346);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.Command);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CommandForm";
            this.Text = "CommandForm";
            this.Load += new System.EventHandler(this.CommandForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Command;

    }
}