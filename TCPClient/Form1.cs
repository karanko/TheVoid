using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Form1(string ip)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(ip))
            {
            sendip = ip;
            }
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox1_KeyPress);

            if (System.IO.File.Exists("lastexecuted.txt"))
            {
               textBox1.Text = System.IO.File.ReadAllText("lastexecuted.txt");
            }
        }
        string sendip = "127.0.0.1";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                
                System.IO.File.WriteAllText("lastexecuted.txt", textBox1.Text);
                TCPSend(sendip, 3000, textBox1.Text.Trim());
            }
     
        }

        private void TCPSend(string SERVER_IP, int PORT_NO, string input)
        {
            byte[] data = new byte[1024];
            string stringData;
            TcpClient server;
            server = new TcpClient(SERVER_IP, PORT_NO);
            server.SendTimeout = 5000;
            server.ReceiveTimeout = 5000;

            NetworkStream ns = server.GetStream();
            try
            {
                int recv = ns.Read(data, 0, data.Length);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ns.Close();
            server.Close();

        }
    }
}
