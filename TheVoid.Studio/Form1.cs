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
    public partial class Form1 : Form
    {
       public  TheVoid.Combustion combustion;
       public  TheVoid.Ignition metro;
        Editor editorform ;//= new Editor();
        public Form1()
        {
            combustion = new TheVoid.Combustion();
            metro = new TheVoid.Ignition();
            metro.addeventhandler(new System.Timers.ElapsedEventHandler(combustion.tickhandler));
            //metro.addeventhandler(new System.Timers.ElapsedEventHandler(this.updatestudd));
            InitializeComponent();
            listBox1.DataSource = new List<string>(combustion.Functions.Keys);
         //   listBox1.Refresh = true;
         //   dataGridView1.DataSource = new BindingSource(combustion.GlobalVariables, null); // GetPricelevels() returns Dictionary<string, string>
           
         //   dataGridView1.ValueMember = "Key";
           // dataGridView1.DisplayMember = "Value";

            textBox2.Text = metro.bpm.ToString();

            numericUpDown3.DataBindings.Clear();
            numericUpDown3.DataBindings.Add(new Binding("Value", metro, "milliseconds"));
            numericUpDown3.Minimum = 1;
            numericUpDown3.Maximum = 200000;
        //    numericUpDown3.u

            numericUpDown2.DataBindings.Clear();
            numericUpDown2.DataBindings.Add(new Binding("Value", metro, "bpm"));
            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = 200000;
                numericUpDown2.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            //numericUpDown1.DataBindings.Clear();
            //numericUpDown1.DataBindings.Add(new Binding("Value", metro, "beats"));
            //numericUpDown1.Minimum = 1;
            //numericUpDown1.Maximum = 32;

                numericUpDown3.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

                if (editorform == null || editorform.IsDisposed)
                {
                    editorform = new Editor();

                }
                editorform.Visible = false;    
            editorform.Show(this);

           
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                combustion.Functions[listBox1.SelectedValue.ToString()] = textBox1.Text;
               }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = combustion.Functions[listBox1.SelectedValue.ToString()].ToString();
                if (editorform == null || editorform.IsDisposed)
                {
                    editorform = new Editor();

                }
                if (!editorform.Visible)
                {
                    editorform.Visible = true;
                }
                editorform.Data = listBox1.SelectedValue.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            metro.running = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            listBox2.DataSource = new List<object>(combustion.GlobalVariables.Values);
      }

        public void updatestudd(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                listBox2.DataSource = new List<object>(combustion.GlobalVariables.Values);
         
             
            }
            catch { }
            //    new Thread(this.thisthing).Start();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            combustion.ExecutingFunctions = new List<string>(combustion.Functions.Keys);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            combustion.ExecutingFunctions = new List<string>(); ;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metro.bpm = Convert.ToInt16(textBox2.Text);
            }
            catch { }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
          //  metro.beats = (int)numericUpDown3.Value;

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
          //  metro.milliseconds = (int)numericUpDown2.Value;


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
          //  metro.bpm = (int)numericUpDown1.Value;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FunctionEditor().Show(this);
        }
    }
}
