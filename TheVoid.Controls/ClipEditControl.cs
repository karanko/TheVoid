using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controls
{
    public partial class ClipEditControl : UserControl
    {
        public ClipEditControl()
        {
            InitializeComponent();
        }
        public decimal Length
        {
            get { return this.numericUpDown1.Value; }
            set { this.numericUpDown1.Value = value; }

        }
        public decimal Offset
        {
            get { return this.numericUpDown2.Value; }
            set { this.numericUpDown2.Value = value; }

        }
        public decimal Speed
        {
            get { return this.numericUpDown3.Value; }
            set { this.numericUpDown3.Value = value; }

        }
        public string Command
        {
            get { return this.textBox2.Text; }
            set { this.textBox2.Text = value; }

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClipEditControl_Load(object sender, EventArgs e)
        {

        }
    }
}
