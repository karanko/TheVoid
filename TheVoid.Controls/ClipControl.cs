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
    public partial class ClipControl : UserControl
    {
        public ClipControl()
        {
            InitializeComponent();
            this.SuspendLayout();
            _active = false;
         //   this.button2.Text = "";
            this.Dock = DockStyle.Fill;
         //   this.AutoSize = true;
         //   this.Enabled = true;
        //    this.Visible = true;
            
            this.Active = false;
            this.Play = false;
        //    this.StateButton.Text = "[]";
            this.ResumeLayout();


        }
        private bool _active;
        private bool _playing;
        private string _label;
        private Color _color;
        private int _varience = 0;
        private void ColorUpdate()
        {
            if (this.Active)
            {
                     Random randonGen = new Random(new Random(DateTime.Now.Millisecond).Next());

                     _color = Color.FromArgb(randonGen.Next(128, 255), randonGen.Next(_varience, 255), randonGen.Next(_varience, 255), randonGen.Next(_varience, 255));
                    
                this.button2.BackColor = _color;
                this.button2.BackColor = Color.FromArgb(_color.A, (((_color.R + 200) - _varience) % 200) + 54, (((_color.G + 200) - _varience) % 200) + 54, (((_color.B + 200) - _varience) % 200) + 54);
                this.button2.FlatAppearance.BorderSize = 1;
                this.StateButton.FlatAppearance.BorderSize = 1;

            }
            else
            {
                this.button2.BackColor = Color.Gray;
                this.button2.FlatAppearance.BorderSize = 0;
                this.StateButton.FlatAppearance.BorderSize = 0;

            }
        }

        public bool Active { get { return _active; } set { _active = value;
       
            this.StateButton.Visible = _active;
            if (this.Active)
            {
                this.button2.Text = _label;
            }

        } }
        public int Varience { get { return _varience/10; } set {
            _varience = value*10;
            ColorUpdate();        
        } }
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                this.Active = this.Active;
            }
        }
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                ColorUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!this.Active)
            {
                this.Active = true;
                this.Play = this.Play;
                ColorUpdate();
            }
        }
        public bool Play
        {
            get { return _playing; }
            set
            {
                _playing = value;
                if (this.Active)
                {

                    if (this._playing)
                    {
                        this.StateButton.Text = "[]";
                        this.StateButton.FlatAppearance.BorderColor = Color.Black;

                       // this.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        //  this._playing = false;
                    }
                    else
                    {
                      //  this._playing = true;
                        this.StateButton.Text = ">";
                       // this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.StateButton.FlatAppearance.BorderColor = Color.DarkGray;




                    }
                }
                else
                {
                    this.StateButton.Text = "";
                }
            }
        }

        private void StateButton_Click(object sender, EventArgs e)
        {

            this.Play = !this.Play;
           // Debug.WriteLine(this.Play);

        }

        private void button2_Resize(object sender, EventArgs e)
        {

        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
           // Debug.WriteLine("keydown");

            if (e.KeyCode == Keys.F2)
            {
              //  Debug.WriteLine("F2");

                // Enter (return) was pressed.
                // ... Call a custom method when user presses this key.
                using (var d = new SimpleInput("Rename Clip") { Data = this.Label })
              {
                  d.ShowDialog();
                  if(d.DialogResult.Equals(DialogResult.OK))
                  {
                     // Debug.WriteLine(d.Data);
                      this.Label = d.Data.ToLower().Trim();
                  }

              }
            }
        }


    }
}
