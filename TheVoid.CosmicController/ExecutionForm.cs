using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class ExecutionForm : Form
    {
        public ExecutionForm()
        {
            InitializeComponent();

            service = new Service.ServiceClient();

            service.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 2);
            service.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 2);
            service.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 2);
            service.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 2);

        }
        Service.ServiceClient service;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F5))
            {
                try
                {
                    
                   
                    if (Command.SelectionLength > 1)
                    {
                       ResultTextBox.Text =  service.Evaluate("Default", Command.SelectedText);
                    }
                    else
                    {
                        ResultTextBox.Text = service.Evaluate("Default", Command.Text);

                    }
                   // listBox1.Items.Clear();
                    listBox1.Items.AddRange(service.ListMessages(listBox1.Items.Count));
                }
                catch (Exception ex)
                {
                    ResultTextBox.Text = ex.Message;
                }
               
              
            }
        }

        private void Command_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
