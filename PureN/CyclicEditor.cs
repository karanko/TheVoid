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
    public partial class CyclicEditor : UserControl
    {
        public CyclicEditor()
        {
            InitializeComponent();
            cyclic = new Cyclic();
            this.Selected = 0;
        }
        public Cyclic cyclic;
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
            checkedListBox1.SetItemChecked(cyclic.Get(Selected, 0), true);
            checkedListBox2.SetItemChecked(cyclic.Get(Selected, 1), true);
            checkedListBox3.SetItemChecked(cyclic.Get(Selected, 2), true);
            checkedListBox4.SetItemChecked(cyclic.Get(Selected, 3), true);

            checkedListBox5.SetItemChecked(cyclic.Get(Selected, 4), true);
            checkedListBox6.SetItemChecked(cyclic.Get(Selected, 5), true);
            checkedListBox7.SetItemChecked(cyclic.Get(Selected, 6), true);
            checkedListBox8.SetItemChecked(cyclic.Get(Selected, 7), true);

            checkedListBox9.SetItemChecked(cyclic.Get(Selected, 8), true);
            checkedListBox10.SetItemChecked(cyclic.Get(Selected, 9), true);
            checkedListBox11.SetItemChecked(cyclic.Get(Selected, 10), true);
            checkedListBox12.SetItemChecked(cyclic.Get(Selected, 11), true);

            checkedListBox13.SetItemChecked(cyclic.Get(Selected, 12), true);
            checkedListBox14.SetItemChecked(cyclic.Get(Selected, 13), true);
            checkedListBox15.SetItemChecked(cyclic.Get(Selected, 14), true);
            checkedListBox16.SetItemChecked(cyclic.Get(Selected, 15), true);




        }



        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var chklist = sender as CheckedListBox;
            
                
            var number = Convert.ToInt16(chklist.Name.Replace("checkedListBox", "")) - 1;

            for (int ix = 0; ix < chklist.Items.Count; ++ix)
            {
                if (ix != e.Index)
                {
                    chklist.SetItemChecked(ix, false);
                }


            }

            if (chklist.CheckedItems.Contains(e.Index))
            {
                cyclic.Set(Selected, number, e.Index);
             //   chklist.ClearSelected();

            }
         
           
        }
    }
}
