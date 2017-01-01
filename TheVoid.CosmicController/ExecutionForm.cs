using System;
using System.Windows.Forms;

namespace TheVoid.CosmicController
{
    public partial class ExecutionForm : Form
    {
        public ExecutionForm()
        {
            InitializeComponent();


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.F5))
            {
                try
                {
                    
                   
                    if (Command.SelectionLength > 1)
                    {
                       ResultTextBox.Text = Client.Proxy.Evaluate("Default", Command.SelectedText);
                    }
                    else
                    {
                        ResultTextBox.Text = Client.Proxy.Evaluate("Default", Command.Text);


                    }
                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(Client.Proxy.ListAllMessages());
                    listBox1.EndUpdate();
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
