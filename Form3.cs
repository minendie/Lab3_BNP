using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace Lab3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //Form2 form2 = new Form2();
            //form2.Show();
        }
        public void ServerThread()
        {
            if (textBox2.Text == "") {
                MessageBox.Show("Please enter port number!");
                return;
            }
            else
            {
                //int port = 12345; // Set the port number to listen on
                int port = int.Parse(textBox2.Text);
                UdpClient udpClient = new UdpClient(port);

                try
                {

                    while (true)
                    {
                        // Wait for a UDP packet to arrive
                        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                        byte[] data = udpClient.Receive(ref remoteEP);

                        // Process the received data
                        string message = System.Text.Encoding.UTF8.GetString(data);

                        string ipaddr = remoteEP.Address.ToString();

                        ListViewItem item = new ListViewItem(ipaddr);
                        item.SubItems.Add(message);
                        listView1.Items.Add(item);
                        //Console.WriteLine("Received message from {0}: {1}", remoteEP.ToString(), message);
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                finally
                {
                    udpClient.Close();
                }

            }
            
        }
        // private Thread serverThread;
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread udpServerThread = new Thread(new ThreadStart(ServerThread));
            udpServerThread.Start();
            udpServerThread.IsBackground = true;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
