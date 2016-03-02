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

namespace TheVoid.SpiderMonkey
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.IsMdiContainer = true;
            InitializeComponent();

           CommandForms.Add(new Command());
            CommandForms.Add(new Command());

          
        }
        private Explorer explorer = new Explorer();
    
      //  private WeifenLuo.WinFormsUI.Docking.VS2005Theme vS2005Theme1;
        public ResultForm ResultForm= new ResultForm();
        public List<Command> CommandForms = new List<Command>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            ResultForm.Show(dockPanel, DockState.DockBottom);
            explorer.Show(dockPanel, DockState.DockLeft);
            foreach(var x in CommandForms)
            {
                //x.Show(dockPanel, DockState.Document);               
            }
        }
    }
}
