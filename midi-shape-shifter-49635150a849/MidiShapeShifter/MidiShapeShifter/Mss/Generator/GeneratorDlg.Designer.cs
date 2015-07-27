﻿namespace MidiShapeShifter.Mss.Generator
{
    partial class GeneratorDlg
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
            this.components = new System.ComponentModel.Container();
            this.genNameLbl = new System.Windows.Forms.Label();
            this.genNameTextBox = new System.Windows.Forms.TextBox();
            this.loopCheckBox = new System.Windows.Forms.CheckBox();
            this.periodTypeCombo = new System.Windows.Forms.ComboBox();
            this.periodTypeLbl = new System.Windows.Forms.Label();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.periodLbl = new System.Windows.Forms.Label();
            this.periodTextBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // genNameLbl
            // 
            this.genNameLbl.AutoSize = true;
            this.genNameLbl.Location = new System.Drawing.Point(7, 13);
            this.genNameLbl.Name = "genNameLbl";
            this.genNameLbl.Size = new System.Drawing.Size(88, 13);
            this.genNameLbl.TabIndex = 0;
            this.genNameLbl.Text = "Generator Name:";
            // 
            // genNameTextBox
            // 
            this.genNameTextBox.Location = new System.Drawing.Point(101, 10);
            this.genNameTextBox.Name = "genNameTextBox";
            this.genNameTextBox.Size = new System.Drawing.Size(105, 20);
            this.genNameTextBox.TabIndex = 1;
            // 
            // loopCheckBox
            // 
            this.loopCheckBox.AutoSize = true;
            this.loopCheckBox.Location = new System.Drawing.Point(10, 88);
            this.loopCheckBox.Name = "loopCheckBox";
            this.loopCheckBox.Size = new System.Drawing.Size(50, 17);
            this.loopCheckBox.TabIndex = 7;
            this.loopCheckBox.Text = "Loop";
            this.loopCheckBox.UseVisualStyleBackColor = true;
            // 
            // periodTypeCombo
            // 
            this.periodTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodTypeCombo.FormattingEnabled = true;
            this.periodTypeCombo.Location = new System.Drawing.Point(101, 37);
            this.periodTypeCombo.Name = "periodTypeCombo";
            this.periodTypeCombo.Size = new System.Drawing.Size(105, 21);
            this.periodTypeCombo.TabIndex = 3;
            this.periodTypeCombo.SelectedIndexChanged += new System.EventHandler(this.periodTypeCombo_SelectedIndexChanged);
            // 
            // periodTypeLbl
            // 
            this.periodTypeLbl.AutoSize = true;
            this.periodTypeLbl.Location = new System.Drawing.Point(7, 40);
            this.periodTypeLbl.Name = "periodTypeLbl";
            this.periodTypeLbl.Size = new System.Drawing.Size(67, 13);
            this.periodTypeLbl.TabIndex = 2;
            this.periodTypeLbl.Text = "Period Type:";
            // 
            // periodCombo
            // 
            this.periodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodCombo.FormattingEnabled = true;
            this.periodCombo.Location = new System.Drawing.Point(101, 64);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(105, 21);
            this.periodCombo.TabIndex = 5;
            // 
            // periodLbl
            // 
            this.periodLbl.AutoSize = true;
            this.periodLbl.Location = new System.Drawing.Point(7, 67);
            this.periodLbl.Name = "periodLbl";
            this.periodLbl.Size = new System.Drawing.Size(40, 13);
            this.periodLbl.TabIndex = 4;
            this.periodLbl.Text = "Period:";
            // 
            // periodTextBox
            // 
            this.periodTextBox.Location = new System.Drawing.Point(101, 65);
            this.periodTextBox.Name = "periodTextBox";
            this.periodTextBox.Size = new System.Drawing.Size(105, 20);
            this.periodTextBox.TabIndex = 6;
            this.periodTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.periodTextBox_Validating);
            // 
            // cancelBtn
            // 
            this.cancelBtn.CausesValidation = false;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(109, 136);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(28, 136);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 9;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(10, 111);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.enabledCheckBox.TabIndex = 8;
            this.enabledCheckBox.Text = "Enabled";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneratorDlg
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(212, 168);
            this.Controls.Add(this.enabledCheckBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.periodTextBox);
            this.Controls.Add(this.periodCombo);
            this.Controls.Add(this.periodLbl);
            this.Controls.Add(this.periodTypeCombo);
            this.Controls.Add(this.periodTypeLbl);
            this.Controls.Add(this.loopCheckBox);
            this.Controls.Add(this.genNameTextBox);
            this.Controls.Add(this.genNameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratorDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generator Editor";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label genNameLbl;
        internal System.Windows.Forms.TextBox genNameTextBox;
        private System.Windows.Forms.CheckBox loopCheckBox;
        internal System.Windows.Forms.ComboBox periodTypeCombo;
        private System.Windows.Forms.Label periodTypeLbl;
        internal System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.Label periodLbl;
        internal System.Windows.Forms.TextBox periodTextBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox enabledCheckBox;

    }
}