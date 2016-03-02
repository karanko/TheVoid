using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteController
{
    public partial class Grid : UserControl
    {
        public Grid()
        {
            InitializeComponent();
         this.Panel.RowCount = 8;
         this.Panel.ColumnCount = 8;
         FillTableWithClips();

        }
     private void FillTableWithClips()
        {
            int ic = 0;

            ColumnStyle cs = new ColumnStyle(SizeType.AutoSize);
            RowStyle rs = new RowStyle(SizeType.AutoSize);

            this.Panel.ColumnStyles.Clear();
            this.Panel.RowStyles.Clear();

            this.Panel.ColumnStyles.Add(cs);
            this.Panel.RowStyles.Add(rs);
            int i = 1;
            this.Panel.SuspendLayout();

            while (ic < this.Panel.ColumnCount - 1)
            {
                int ir = 0;
                // this.TableGrid.

                while (ir < this.Panel.RowCount - 1)
                {

                    //x.Size.Height = this.Panel.Height / this.Panel.ColumnCount;
                    //x.Size.Width = this.Panel.Width / this.Panel.RowCount;
                    this.Panel.Controls.Add(new LilButton() { Enabled = true }, ic, ir);
                    //  Debug.WriteLine((ic+1)+"-"+(ir+1));
                    i++;
                    ir++;
                }


                ic++;
            }
            this.Panel.ResumeLayout();
            // this.TableGrid.Refresh();

        }

    

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
