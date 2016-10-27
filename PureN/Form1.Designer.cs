namespace PureN
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.noteDensity1 = new PureN.NoteDensity();
            this.velocityRange1 = new PureN.VelocityRange();
            this.cyclicEditor1 = new PureN.CyclicEditor();
            this.cyclicEditor2 = new PureN.CyclicEditor();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cyclicEditor2);
            this.flowLayoutPanel1.Controls.Add(this.cyclicEditor1);
            this.flowLayoutPanel1.Controls.Add(this.noteDensity1);
            this.flowLayoutPanel1.Controls.Add(this.velocityRange1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(354, 562);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // noteDensity1
            // 
            this.noteDensity1.Location = new System.Drawing.Point(3, 213);
            this.noteDensity1.Name = "noteDensity1";
            this.noteDensity1.Selected = 0;
            this.noteDensity1.Size = new System.Drawing.Size(113, 342);
            this.noteDensity1.TabIndex = 0;
            // 
            // velocityRange1
            // 
            this.velocityRange1.Location = new System.Drawing.Point(122, 213);
            this.velocityRange1.Name = "velocityRange1";
            this.velocityRange1.Selected = 0;
            this.velocityRange1.Size = new System.Drawing.Size(112, 350);
            this.velocityRange1.TabIndex = 1;
            this.velocityRange1.Load += new System.EventHandler(this.velocityRange1_Load);
            // 
            // cyclicEditor1
            // 
            this.cyclicEditor1.Location = new System.Drawing.Point(3, 108);
            this.cyclicEditor1.Name = "cyclicEditor1";
            this.cyclicEditor1.Selected = 0;
            this.cyclicEditor1.Size = new System.Drawing.Size(344, 99);
            this.cyclicEditor1.TabIndex = 2;
            this.cyclicEditor1.Load += new System.EventHandler(this.cyclicEditor1_Load);
            // 
            // cyclicEditor2
            // 
            this.cyclicEditor2.Location = new System.Drawing.Point(3, 3);
            this.cyclicEditor2.Name = "cyclicEditor2";
            this.cyclicEditor2.Selected = 0;
            this.cyclicEditor2.Size = new System.Drawing.Size(344, 99);
            this.cyclicEditor2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 562);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NoteDensity noteDensity1;
        private VelocityRange velocityRange1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CyclicEditor cyclicEditor2;
        private CyclicEditor cyclicEditor1;
    }
}

