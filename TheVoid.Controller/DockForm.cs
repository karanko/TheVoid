using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TheVoid.Controller
{
    public partial class DockForm : Form
    {
        public DockForm()
        {
            InitializeComponent();


           var enginesform =  new EngineList();
           enginesform.Show(dockPanel, DockState.DockRight);
           enginesform.Parent = this;

           this.IsMdiContainer = true;

        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new CommandForm().Show(dockPanel, DockState.Float);
            }
            catch { }
        }
    }
}
