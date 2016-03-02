using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controller
{
    public partial class EngineList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public EngineList()
        {
            InitializeComponent();
            Refresher();
        }
        
        public void Refresher()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            listBox.Items.AddRange(Client.Proxy.Engines());
            listBox.EndUpdate();

        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            CommandForm ddd = new CommandForm(listBox.SelectedItem.ToString());
            ddd.Show(((DockForm)this.ParentForm).dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);
          //  ddd.Parent = this;
           
           
        }
    }
}
