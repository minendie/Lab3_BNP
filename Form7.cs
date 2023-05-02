using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace Lab3
{
    public partial class Form7 : Form
    {
        TcpClient tcpClient = new TcpClient();
        NetworkStream netStream;
        public Form7()
        {
            InitializeComponent();
            //Form2 form = new Form2();
            //form.Show();
            ///tb.Text = "127.0.0.1";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipendpoint = new IPEndPoint(ipaddress, 8080);
            tcpClient.Connect(ipendpoint);
            netStream = tcpClient.GetStream();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("Hello server\n");
            netStream.Write(data, 0, data.Length);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("quit\n");
            netStream.Write(data,0,data.Length);
            netStream.Close();
            tcpClient.Close();
        }
    }
}
