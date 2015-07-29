using System;
using System.Windows.Forms;

namespace LowDefinition
{
    public partial class LowWindow : Form
    {
        public LowWindow()
        {
            InitializeComponent();
            Data.Text = "";
        }
        public void Message(object message)
        {
            Data.Text = message.ToString() + Environment.NewLine + Data.Text;
         //   this.Show();
        }

        private void LowWindow_FormClosing(object sender, FormClosingEventArgs e)
        {Data.Text = "";
            this.Hide(); 
            
            e.Cancel = true;
          
        }


    }
}
