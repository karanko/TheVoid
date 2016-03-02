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
    public partial class ResultForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public ResultForm()
        {
            InitializeComponent();
        }
        public void SetValue(string value)
        {
            TextBox.Text = value;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

        }
    }
}
