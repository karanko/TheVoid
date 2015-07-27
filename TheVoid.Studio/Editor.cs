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
    public partial class Editor : Form
    {
        private Form1 parent;
        public Editor()
        {
            InitializeComponent();
            parent = (Form1)this.Owner;
        }
      
        public string Data
        {
            get { return textBox1.Name ; }
            set {
 textBox1.Name = value;
 this.Text = "Editor - " + textBox1.Name;
 try { 


     textBox1.Text = ((Form1)this.Owner).combustion.Functions[textBox1.Name].ToString();
}
 catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex); }

            }
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ((Form1)this.Owner).combustion.Functions[textBox1.Name] = textBox1.Text;
            }
            catch(Exception ex)
            { System.Diagnostics.Debug.WriteLine(ex); }
        }


    }
}
