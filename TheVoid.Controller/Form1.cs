using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Controller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            checkBox1.Checked = getarraystate(1);
            checkBox2.Checked = getarraystate(2);
            checkBox3.Checked = getarraystate(3);
            checkBox4.Checked = getarraystate(4);
            checkBox5.Checked = getarraystate(5);
            checkBox6.Checked = getarraystate(6);
            checkBox7.Checked = getarraystate(7);
            checkBox8.Checked = getarraystate(8);
            checkBox9.Checked = getarraystate(9);
            checkBox10.Checked = getarraystate(10);
            checkBox11.Checked = getarraystate(11);
            checkBox12.Checked = getarraystate(12);
            checkBox13.Checked = getarraystate(13);
            checkBox14.Checked = getarraystate(14);
            checkBox15.Checked = getarraystate(15);
            checkBox16.Checked = getarraystate(16);
            checkBox17.Checked = getarraystate(17);
            checkBox18.Checked = getarraystate(18);
            checkBox19.Checked = getarraystate(19);
            checkBox20.Checked = getarraystate(20);
            checkBox21.Checked = getarraystate(21);
            checkBox22.Checked = getarraystate(22);
            checkBox23.Checked = getarraystate(23);
            checkBox24.Checked = getarraystate(24);
            checkBox25.Checked = getarraystate(25);
            checkBox26.Checked = getarraystate(26);
            checkBox27.Checked = getarraystate(27);
            checkBox28.Checked = getarraystate(28);
            checkBox29.Checked = getarraystate(29);
            checkBox30.Checked = getarraystate(30);
            checkBox31.Checked = getarraystate(31);
            checkBox32.Checked = getarraystate(32);

        }
        private  void setarraystate(int item, bool value)
        {
            string command = "bit = ( typeof bit != 'undefined' && bit instanceof Array ) ? bit : []; ";


          
                if (value)
                {
                    command += "bit[" + item + " -1] = true ;";
                }
                else
                {
                    command += "delete bit[" + item + " -1] ;";

                }


          
                Client.Proxy.Execute(command);
        
        }
        private bool  getarraystate(int item)
        {
            try
            {
                string command = "bit = ( typeof bit != 'undefined' && bit instanceof Array ) ? bit : []; bit[" + item + " -1];";
                string result = Client.Proxy.Evaluate(command);
                if (result.ToLower().Contains("true"))
                {
                    return true;
                }
                else if (result.ToLower().Equals("1"))
                {
                    return true;
                }
                else { return false; }
            }
            catch { return false; }
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(1, checkBox1.Checked);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(8, checkBox1.Checked);

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(3, checkBox1.Checked);

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(4, checkBox1.Checked);

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(5, checkBox1.Checked);

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(6, checkBox1.Checked);

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(7, checkBox1.Checked);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(2, checkBox1.Checked);

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(9, checkBox1.Checked);

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(10, checkBox1.Checked);

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(11, checkBox1.Checked);

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(12, checkBox1.Checked);

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(13, checkBox1.Checked);

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(14, checkBox1.Checked);

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(15, checkBox1.Checked);

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(16, checkBox1.Checked);

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(17, checkBox1.Checked);

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(18, checkBox1.Checked);

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(19, checkBox1.Checked);

        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(20, checkBox1.Checked);

        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {

            setarraystate(21, checkBox1.Checked);
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(22, checkBox1.Checked);

        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(23, checkBox1.Checked);

        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(24, checkBox1.Checked);

        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(25, checkBox1.Checked);

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(26, checkBox1.Checked);

        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(27, checkBox1.Checked);

        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(28, checkBox1.Checked);

        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(29, checkBox1.Checked);

        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(30, checkBox1.Checked);

        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            setarraystate(32, checkBox1.Checked);

        }

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {

            setarraystate(32, checkBox1.Checked);
        }
    }
}
