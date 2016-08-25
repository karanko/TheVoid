using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controller
{
    public partial class APCPageControl : UserControl
    {
        public APCPageControl()
        {
            InitializeComponent();
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            foreach (var x in Client.Proxy.listAPCPages())
            {
                var n = new TreeNode();
                n.Name = String.Format("Page (Vel:{0})", x.Vel);
                int i = 0;
                foreach (var p in x.Pattern.Steps)
                {
                    n.Nodes.Add(i.ToString(), p.ToString());
                    i++;
                }
               // treeView1.Nodes.
            //    checkedListBox1.Items.Add(x, x.Solo);
            }
            treeView1.EndUpdate();
        }

        private void APCPageControl_Load(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
