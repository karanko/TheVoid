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
    public partial class Command : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public Command(string value = null)
        {this.IsMdiContainer = true;
            InitializeComponent();
            textBox.Text = value;

            
        }
        private string lastresult;

        private void Command_Load(object sender, EventArgs e)
        {

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F5))
            {
                try
                {
                    if (textBox.SelectionLength > 1)
                    {
                        ((MainForm)this.ParentForm).ResultForm.SetValue( TheVoid.Client.Proxy.Evaluate("Default", textBox.SelectedText));
                    }
                    else
                    {
                        ((MainForm)this.ParentForm).ResultForm.SetValue(TheVoid.Client.Proxy.Evaluate("Default", textBox.Text));

                    }
                    // listBox1.Items.Clear();
                    // listBox1.Items.AddRange(service.ListMessages(listBox1.Items.Count));
                    this.Text = this.Text.Replace("*", "");
                 //   ((MainForm)this.ParentForm).ObsList.RefreshTree();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //  System.Diagnostics.Debug.WriteLine("Test");

            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
