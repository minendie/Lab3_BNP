using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic.Logging;

namespace Lab3
{
    public partial class Form10 : Form
    {
        // Will hold the user name
        private string UserName;
        private StreamWriter writer;
        private StreamReader reader;
        private TcpClient client;
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);
        // Needed to set the form to a "disconnected" state from another thread
        // private delegate void CloseConnectionCallback(string strReason);
        private Thread receivedThr;
        private IPAddress ipAddr;

        public Form10()
        {

            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //int clientport = 6990;
        public void InitializeConnection()
        {
            ipAddr = IPAddress.Parse("127.0.0.1");
            client = new TcpClient();
            client.Connect(ipAddr, 8080);
            button2.Text = "Connected";
            button2.Enabled = false;
            // Prepare the form
            UserName = textBox1.Text;
            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            writer.WriteLine(UserName);
            writer.Flush();

            receivedThr = new Thread(new ThreadStart(ReceiveMessages));
            receivedThr.Start();
        }
        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    UpdateLog(message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLog(string strMessage)
        {
            // Append text also scrolls the TextBox to the bottom each time
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(UpdateLog), strMessage);
            }
            else
            {
                richTextBox1.AppendText(strMessage + Environment.NewLine);
            }
        }

        private void SendMessage()
        {
            writer.WriteLine(textBox2.Text);
            writer.Flush();
            textBox2.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text)) // Kiểm tra nếu chưa nhập username
            {
                MessageBox.Show("Enter message to send!");
                return;
            }
             
            SendMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) // Kiểm tra nếu chưa nhập username
            {
                MessageBox.Show("Enter username before chatting!");
                return;
            }

            InitializeConnection();
        }
    }
}
