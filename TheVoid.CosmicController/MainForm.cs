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

namespace TheVoid.CosmicController
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
            Result = new ResultForm();
            ObsList = new ObjectTree();
         
        }
        
        public  ResultForm Result;
        public ObjectTree ObsList;
        private void MainForm_Load(object sender, EventArgs e)
        {

            Result.Show(dockPanel1, DockState.DockBottomAutoHide);
            Result.Parent = this;
            Result.CloseButtonVisible = false;
          //  Result.Refresh();
            Result.Show(dockPanel1, DockState.DockBottom);
         
            new CommandForm().Show(dockPanel1, DockState.Document);
            new CommandForm().Show(dockPanel1, DockState.Document);
              new CommandForm(Client.Proxy.Evaluate("readcache();")).Show(dockPanel1, DockState.Document);
            new CommandForm(Client.Proxy.Evaluate("if(typeof bang !== 'function'){ log('creating bang()'); this.bang = function bang(){ };}; bang/*do not log*/")).Show(dockPanel1, DockState.Document);
          new Memo().Show(dockPanel1, DockState.DockRightAutoHide);
           new MessagesForm().Show(dockPanel1, DockState.DockRight);
            new HistoryForm().Show(dockPanel1, DockState.DockLeft);
            ObsList.Show(dockPanel1, DockState.DockLeftAutoHide);
        }


   
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // dockPanel1.SaveAsXml("layout.xml");
        }
    }
}
