using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Server
{
    public partial class FastEval : Form
    {
        public FastEval()
        {
            InitializeComponent();
           // textBox1.BackColor = Color.Transparent;
      
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // textBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessagesTextbox.Text = Combustion.Evaluate("default", textBox1.Text);

        }

    }
}
