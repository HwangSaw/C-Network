using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormClient1
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient = null;
        NetworkStream ns;
        BinaryReader br;
        BinaryWriter bw;
        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // "접속" 버튼 
        private void button1_Click(object sender, EventArgs e) 
        {
            tcpClient = new TcpClient(textBox1.Text, 3000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("서버 접속 성공");
            }
            else
            {
                MessageBox.Show("서버 접속 실패");

            }
        }

        // "전송 및 수신" 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(textBox2.Text));
            bw.Write(float.Parse(textBox3.Text));
            bw.Write(textBox4.Text);

            // read 함수 호출시 대기상태 서버가 보내준 (서버에서 write해준데이터)를 읽는다.
            intValue = br.ReadInt32();
            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            String str = intValue + "/ " + floatValue + "/ " + strValue;
            MessageBox.Show(str);
        }



        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            if (null != bw)
            {
                bw.Write(-1);
                bw.Close();
            }
            if (null != br)
            {
                br.Close();
            }
            if (null != ns)
            {
                ns.Close();
            }
            if( null != tcpClient)
            {
                tcpClient.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
