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
using Microsoft.VisualBasic.Logging;

namespace Lab3
{
    public partial class Form11 : Form
    {
        private TcpListener tcpListener;
        private List<TcpClient> clients = new List<TcpClient>();
        public Form11()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void StartServer()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8080);
                tcpListener.Start();
                UpdateLog("Server running on 127.0.0.1:8080");
                Thread listenThr = new Thread(ListenForClient);
                listenThr.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListenForClient()
        {
            while (true)
            {
                try
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(start: HandleClientComm);
                    clientThread.Start(tcpClient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            StreamReader reader = new StreamReader(clientStream);
            StreamWriter writer = new StreamWriter(clientStream);
            string userName = reader.ReadLine(); // Đọc tên người dùng từ client
            AddClient(tcpClient, userName); // add client với tên người dùng

            while (tcpClient.Connected) // Kiểm tra trạng thái kết nối
            {

                string message = reader.ReadLine();
                if (message == null)
                    break;


                // Xử lý tin nhắn từ client, ví dụ: broadcast cho toàn bộ client
                BroadcastMessage(userName + ": " + message);

            }
            clients.Remove(tcpClient);

            tcpClient.Close();


        }
        private void AddClient(TcpClient tcpClient, string userName)
        {
            // Thêm client vào danh sách
            clients.Add(tcpClient);
            // Hiển thị thông tin đăng nhập của client lên giao diện            
            UpdateLog("New connection from " + userName);
            // Broadcast tin nhắn chào mừng tới tất cả client, trừ client mới kết nối
            BroadcastMessage(userName + " joined chat.", tcpClient);
        }
        private void BroadcastMessage(string message, TcpClient excludedClient = null)
        {
            // Broadcast tin nhắn tới tất cả client, trừ client trừ ra( nếu có loại trừ)
            foreach (TcpClient client in clients)
            {
                if (client != excludedClient)
                {
                    NetworkStream clientStream = client.GetStream();
                    StreamWriter writer = new StreamWriter(clientStream);
                    writer.WriteLine(message);
                    writer.Flush();
                }
            }
            // Hiển thị tin nhắn lên giao diện
            UpdateLog(message);
        }
        private void UpdateLog(string msg)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Action<string>(UpdateLog), msg);
            }
            else
            {
                richTextBox1.AppendText(msg + Environment.NewLine);
            }
        }


    }
}
