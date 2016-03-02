using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controls
{
    public partial class SimpleInput : Form
    {
        public SimpleInput(string Question)
        {
            InitializeComponent();
            //QuestionLabel.Text = Question;
            this.Text = Question;
            //this.BackColor = ((Form)this.Parent).BackColor;
        }

        private void SimpleInput_Load(object sender, EventArgs e)
        {
            this.textBox1.Focus();

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
           // textBox1.Text;
            this.Hide();

        }
        public string Data { get { return textBox1.Text; } set { textBox1.Text = value; //this.OkButton.Enabled = false; this.CancelButton.Enabled = false; 
        } }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        //    this.OkButton.Enabled = true;
         //   this.CancelButton.Enabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                // this.OkButton.Focus();
            }
        }
    }
}
