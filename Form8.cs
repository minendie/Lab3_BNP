using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private void StartUnsafeThread()
        {
            int bytesReceievd = 0;
            byte[] recv = new byte[1];

            Socket clientSocket;
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipEndPoint);
            listenerSocket.Listen(-1);
            richTextBox1.Text += "Server running on 127.0.0.1:8080\n";
            bool flag = false;
            clientSocket = listenerSocket.Accept();
            while (clientSocket.Connected)
            {
                if (flag!=true) { richTextBox1.Text += "New client connected\n"; }
                flag = true;
                string text = "";
                do
                {
                    bytesReceievd = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                } while (text[text.Length - 1] != '\n');
                 richTextBox1.Text += text ;
            }
            listenerSocket.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
            serverThread.IsBackground = true;
        }
    }
}
