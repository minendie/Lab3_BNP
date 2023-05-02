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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public void StartUnsafeThread()
        {
            int bytesreceived = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            //listView1.Items.Add(new ListViewItem("New client connected"));
            while (clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesreceived = clientSocket.Receive(recv);
                    text += Encoding.UTF8.GetString(recv);
                }
                while (text[text.Length - 1] != '\n');
                ListViewItem item = new ListViewItem(text);
                string endline = "";
                item.SubItems.Add(endline);
                listView1.Items.Add(item);
            }
            listenerSocket.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread udpServerThread = new Thread(new ThreadStart(StartUnsafeThread));
            udpServerThread.Start();
            udpServerThread.IsBackground = true;
        }
    }
}
