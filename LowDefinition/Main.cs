using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowDefinition
{
    public partial class Main : Form
    {
        public LowWindow MessageWindow = new LowWindow();
        public SessionDefinition Session;
        public TheVoid.Ignition Metro;
        public TheVoid.Combustion Combustion;

        public Main()
        {
            Combustion = new TheVoid.Combustion();
            Metro = new TheVoid.Ignition();
            Metro.addeventhandler(new System.Timers.ElapsedEventHandler(Combustion.tickhandler));
         InitializeComponent();
         //   numericUpDown1.DataBindings.Clear();
            numericUpDown1.DataBindings.Add(new Binding("Value", Metro, "bpm"));
         //   numericUpDown1.DataBindings.Add(new Binding("Value", Session, "BPM"));
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 300;
            numericUpDown1.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            FunctionList.DataSource = new List<string>(Combustion.Functions.Keys);
   
            Session = new SessionDefinition();
            numericUpDown1.Value = Session.BPM;
            SessionNameTextBox.Text = Session.Name;
            /*
            MessageWindow.Message("Loading:" + Session.Name);
            MessageWindow.Message(Environment.NewLine);
            MessageWindow.Message("-----------------");
            MessageWindow.Message("Welcome to Low!");
            MessageWindow.Hide();
             * */
         
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Session.BPM = numericUpDown1.Value;
            MessageWindow.Message("BPM:" + Session.BPM);
        }

        private void SessionNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Session.Name = SessionNameTextBox.Text;
            this.Text = String.Format("Low Definition - {0}", Session.Name);
        }

        private void Run_CheckedChanged(object sender, EventArgs e)
        {
            if(Run.Checked)
            {
           
                MessageWindow.Show();
               // MessageWindow.Message("Run");
            }
            else
            {
                MessageWindow.Close();

            }
            Metro.running = Run.Checked;
        }

        private void FunctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Combustion.Functions[FunctionList.SelectedValue.ToString()];
            }
            catch (Exception ex) { MessageWindow.Message(ex.Message); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Combustion.Functions[FunctionList.SelectedValue.ToString()] = textBox1.Text;
            }
            catch (Exception ex) { MessageWindow.Message(ex.Message); }
        }

        private void FunctionList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Combustion.ExecutingFunctions.Clear();
            foreach(var item in FunctionList.CheckedItems)
            {
                MessageWindow.Message(item.ToString()); 
                Combustion.ExecutingFunctions.Add(item.ToString());
            }
        }
    }
}
