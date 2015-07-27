using JSBeautifyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FungleIDE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {/*
            try
            {
                string script = ;
                string output;
                JSBeautify jsb = new JSBeautify(richTextBox1.Text, new JSBeautifyOptions { preserve_newlines = true  });

                output = jsb.GetResult();

                if (!output.Equals(script))
                {
                    richTextBox1.Text = output;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
          * */
        }
    }
}
