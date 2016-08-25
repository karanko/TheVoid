namespace TheVoid.Controller
{
    partial class APCPageControl
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
            this.components = new System.ComponentModel.Container();
            this.proxyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proxyBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.proxyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // proxyBindingSource
            // 
            this.proxyBindingSource.DataSource = typeof(TheVoid.Client.Proxy);
            // 
            // proxyBindingSource1
            // 
            this.proxyBindingSource1.DataSource = typeof(TheVoid.Client.Proxy);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(315, 383);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // APCPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "APCPageControl";
            this.Size = new System.Drawing.Size(315, 383);
            this.Load += new System.EventHandler(this.APCPageControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proxyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource proxyBindingSource;
        private System.Windows.Forms.BindingSource proxyBindingSource1;
        private System.Windows.Forms.TreeView treeView1;
    }
}
