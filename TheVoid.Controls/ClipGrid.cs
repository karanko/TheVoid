using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TheVoid.Controls
{
    public partial class ClipGrid : UserControl
    {
        public ClipGrid()
        {
            InitializeComponent();
            this.TableGrid.RowCount = 1;
            this.TableGrid.ColumnCount = 1;
            this.DoubleBuffered = true;

         
        }
        public int Rows { set {  this.TableGrid.RowCount = value +1; } get {return this.TableGrid.RowCount - 1;}}
        public int Columns { set { this.TableGrid.ColumnCount = value + 1; } get { return this.TableGrid.ColumnCount - 1; } }
        public void FillTableWithClips()
        {
            int ic = 0;

            ColumnStyle cs = new ColumnStyle(SizeType.AutoSize);
            RowStyle rs = new RowStyle(SizeType.AutoSize);

            this.TableGrid.ColumnStyles.Clear();
            this.TableGrid.RowStyles.Clear();

            this.TableGrid.ColumnStyles.Add(cs);
            this.TableGrid.RowStyles.Add(rs);
            int i = 1;
            this.TableGrid.SuspendLayout();

            while (ic < this.TableGrid.ColumnCount -1)
            {
                int ir = 0;
                // this.TableGrid.
               
                while (ir < this.TableGrid.RowCount-1)
                {
                  

                   this.TableGrid.Controls.Add(new ClipControl() { 
                     //   Active = true,   
                       Label = "clip"+i.ToString()
                     //Varience = ir+1
                    },
                        ic, ir);
                  //  Debug.WriteLine((ic+1)+"-"+(ir+1));
                i++;
                    ir++;
                }
              

                ic++;
            }
            this.TableGrid.ResumeLayout();
           // this.TableGrid.Refresh();
        
        }

        private void TableGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableGrid_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}
