using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Studio
{
    public partial class Pickertest : Form
    {
        Editor x = new Editor();
        public Pickertest()
        {
            InitializeComponent();      
            x.Show();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            x.Text = String.Format("Editor  - {0}");
            x.Data = textBox1.Text;
        }
    }
}
