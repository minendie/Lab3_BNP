using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //InitializeComponent();

            InitializeComponent();
            //Form3 form = new Form3();
            //form.Show();
            textBox1.Text = "127.0.0.1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text =="" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter IP address and port!");
                return;
            }
            else
            {
                UdpClient udp = new UdpClient();
                string message = richTextBox1.Text;
                Byte[] sendbyte = Encoding.UTF8.GetBytes(message);
                udp.Send(sendbyte, sendbyte.Length, textBox1.Text, int.Parse(textBox2.Text));
                richTextBox1.Clear();
                richTextBox1.Focus();
            }
            

        }
    }
}
