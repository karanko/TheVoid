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
    public partial class FunctionEditor : Form
    {
      //  TheVoid.Combustion combustion = new Combustion();
     //  Form1 form ;
        public FunctionEditor()
        {
            InitializeComponent();
          //  form = ((Form1)this.Owner);

            this.listBox1.DataBindings.Clear();
        
         
        }
        
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FunctionEditor_Load(object sender, EventArgs e)
        {
            try
            {
                this.listBox1.DataBindings.Add(new Binding("Values", ((Form1)this.Owner).combustion, "Functions"));
            }
            catch(Exception ex)
            { System.Diagnostics.Debug.WriteLine(ex.ToString()); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = ((Form1)this.Owner).combustion.Functions[listBox1.SelectedValue.ToString()];
            }catch(Exception ex)
            { System.Diagnostics.Debug.WriteLine(ex); }
        }
    }
}
