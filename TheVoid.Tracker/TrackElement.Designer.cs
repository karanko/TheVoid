namespace TheVoid.Tracker
{
    partial class TrackElement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Check = new System.Windows.Forms.CheckBox();
            this.NoteNumber = new System.Windows.Forms.NumericUpDown();
            this.Velocity = new System.Windows.Forms.NumericUpDown();
            this.Length = new System.Windows.Forms.NumericUpDown();
            this.Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NoteNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Velocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).BeginInit();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.AutoSize = true;
            this.Check.Checked = true;
            this.Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check.Location = new System.Drawing.Point(4, 4);
            this.Check.Margin = new System.Windows.Forms.Padding(0);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(15, 14);
            this.Check.TabIndex = 0;
            this.Check.ThreeState = true;
            this.Check.UseVisualStyleBackColor = true;
            // 
            // NoteNumber
            // 
            this.NoteNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoteNumber.Hexadecimal = true;
            this.NoteNumber.Location = new System.Drawing.Point(23, 4);
            this.NoteNumber.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.NoteNumber.Name = "NoteNumber";
            this.NoteNumber.Size = new System.Drawing.Size(45, 20);
            this.NoteNumber.TabIndex = 1;
            // 
            // Velocity
            // 
            this.Velocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Velocity.Hexadecimal = true;
            this.Velocity.Location = new System.Drawing.Point(67, 4);
            this.Velocity.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.Velocity.Name = "Velocity";
            this.Velocity.Size = new System.Drawing.Size(45, 20);
            this.Velocity.TabIndex = 1;
            // 
            // Length
            // 
            this.Length.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Length.Increment = new decimal(new int[] {
            69,
            0,
            0,
            0});
            this.Length.Location = new System.Drawing.Point(111, 4);
            this.Length.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(45, 20);
            this.Length.TabIndex = 1;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Location = new System.Drawing.Point(162, 13);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(13, 13);
            this.Label.TabIndex = 2;
            this.Label.Text = "..";
            // 
            // TrackElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.Label);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.Velocity);
            this.Controls.Add(this.NoteNumber);
            this.Controls.Add(this.Check);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TrackElement";
            this.Size = new System.Drawing.Size(174, 27);
            ((System.ComponentModel.ISupportInitialize)(this.NoteNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Velocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Length)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Check;
        private System.Windows.Forms.NumericUpDown NoteNumber;
        private System.Windows.Forms.NumericUpDown Velocity;
        private System.Windows.Forms.NumericUpDown Length;
        private System.Windows.Forms.Label Label;
    }
}
