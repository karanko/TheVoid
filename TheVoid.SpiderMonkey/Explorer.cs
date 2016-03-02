using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.SpiderMonkey
{
    public partial class Explorer : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Explorer()
        {
            InitializeComponent();
            treeView.Nodes.Add(new TreeNode() { Name="Functions" });
            
        //   RefreshTree();

        }
        public void RefreshTree()
        {
           
            string cmd = @" Object.keys(this).filter(function(x){if (!(this[x] instanceof Function)) return false; return !/\[native code\]/.test(this[x].toString()) ? true : false;});";
            treeView.BeginUpdate();
            try
            {
                treeView.Nodes[0].Nodes.Clear();
                foreach (var x in TheVoid.Client.Proxy.Evaluate(cmd).Split(','))
                {
                    treeView.Nodes[0].Nodes.Add(x);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
           
            }
            treeView.EndUpdate();
        }

        private void Explorer_Load(object sender, EventArgs e)
        {

        }
    }
}
