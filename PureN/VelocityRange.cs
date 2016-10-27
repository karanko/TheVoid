using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureN
{
    public partial class VelocityRange : UserControl
    {
        public VelocityRange()
        {
            InitializeComponent();
            range = new Range();
            this.Selected = 0;
        }
        Range range;
        public int Selected
        {
            get { return comboBox1.SelectedIndex; }
            set
            {
                if (value >= 0 & value <= comboBox1.Items.Count - 1)
                {

                    comboBox1.SelectedIndex = value;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Selected--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Selected++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = range.Get(Selected, 0).Key;
            numericUpDown4.Value = range.Get(Selected, 1).Key;
            numericUpDown6.Value = range.Get(Selected, 2).Key;
            numericUpDown8.Value = range.Get(Selected, 3).Key;
            numericUpDown10.Value = range.Get(Selected,4).Key;
            numericUpDown12.Value = range.Get(Selected, 5).Key;

            numericUpDown1.Value = range.Get(Selected, 0).Value;
            numericUpDown3.Value = range.Get(Selected, 1).Value;
            numericUpDown5.Value = range.Get(Selected, 2).Value;
            numericUpDown7.Value = range.Get(Selected, 3).Value;
            numericUpDown9.Value = range.Get(Selected, 4).Value;
            numericUpDown11.Value = range.Get(Selected, 5).Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 0, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            comboBox1_SelectedIndexChanged(sender, e);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 0, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            comboBox1_SelectedIndexChanged(sender, e);



        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 1, (int)numericUpDown4.Value, (int)numericUpDown3.Value);
            comboBox1_SelectedIndexChanged(sender, e);



        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 1, (int)numericUpDown4.Value, (int)numericUpDown3.Value);
            comboBox1_SelectedIndexChanged(sender, e);



        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 2, (int)numericUpDown6.Value, (int)numericUpDown5.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 2, (int)numericUpDown6.Value, (int)numericUpDown5.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 3, (int)numericUpDown8.Value, (int)numericUpDown7.Value);
            comboBox1_SelectedIndexChanged(sender, e);

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 3, (int)numericUpDown8.Value, (int)numericUpDown7.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 4, (int)numericUpDown10.Value, (int)numericUpDown9.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 4, (int)numericUpDown10.Value, (int)numericUpDown9.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 5, (int)numericUpDown12.Value, (int)numericUpDown11.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            range.Set(Selected, 5, (int)numericUpDown12.Value, (int)numericUpDown11.Value);
            comboBox1_SelectedIndexChanged(sender, e);


        }
    }
}
