using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheVoid.Tracker
{
    public partial class TrackStrip : UserControl
    {
        public TrackStrip()
        {
            InitializeComponent();
           // track = 
        }
       
        public Track track;
        public void FillTrack()
        {

            this.tableLayoutPanel.RowCount = track.Steps.Count();
            ColumnStyle cs = new ColumnStyle(SizeType.AutoSize);
            RowStyle rs = new RowStyle(SizeType.AutoSize);

            this.tableLayoutPanel.ColumnStyles.Clear();
            this.tableLayoutPanel.RowStyles.Clear();

            this.tableLayoutPanel.ColumnStyles.Add(cs);
            this.tableLayoutPanel.RowStyles.Add(rs);
            this.tableLayoutPanel.SuspendLayout();
          
                int ir = 0;
                // this.TableGrid.

                while (ir < this.tableLayoutPanel.RowCount - 1)
                {
                    this.tableLayoutPanel.Controls.Add(new TrackElement(ir) { Enabled = true }, 1, ir);
                    //  Debug.WriteLine((ic+1)+"-"+(ir+1));
             
                    ir++;
                }

            this.tableLayoutPanel.ResumeLayout();
            // this.TableGrid.Refresh();

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
