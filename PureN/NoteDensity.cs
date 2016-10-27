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
    public partial class NoteDensity : UserControl
    {
        public NoteDensity()
        {
            InitializeComponent();
         
            density = new Density();
              this.Selected = 0;
        }
        public Density density;

        public int Selected
        {
            get { return comboBox1.SelectedIndex; }
            set {
                if(value >= 0 & value <= comboBox1.Items.Count-1)
                { 

                comboBox1.SelectedIndex = value;
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
             density.Set(this.Selected, 0, trackBar1.Value);

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            density.Set(this.Selected, 1, trackBar2.Value);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            density.Set(this.Selected, 2, trackBar3.Value);

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            density.Set(this.Selected, 3, trackBar4.Value);

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            density.Set(this.Selected, 4, trackBar5.Value);

        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            density.Set(this.Selected, 5, trackBar6.Value);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Value = density.Get(this.Selected, 0);
            trackBar2.Value = density.Get(this.Selected, 1);
            trackBar3.Value = density.Get(this.Selected, 2);
            trackBar4.Value = density.Get(this.Selected, 3);
            trackBar5.Value = density.Get(this.Selected, 4);
            trackBar6.Value = density.Get(this.Selected, 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Selected--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Selected++;
        }
    }
}
