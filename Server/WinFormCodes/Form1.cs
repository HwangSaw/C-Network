using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCodes
{
    public partial class Form1 : Form
    {

        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private BinaryWriter bw = null;
        private BinaryReader br = null;
        private NetworkStream ns = null;

        private int intValue = 0;
        private float floatValue = 0.0f ;
        private string strValue = string.Empty;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("보냈습니다");
        }

        // 모든 객체를 모두 해제하는 함수 
        private void AllClose()
        {
            if (bw != null)
            {
                bw.Close(); bw = null;
            }
            if (br != null)
            {
                br.Close(); br = null;
            }
            if (ns != null)
            {
                ns.Close(); ns = null;
            }
            if (tcpClient != null )
            {
                tcpClient.Close(); tcpClient = null;
            }
        }

        private int DataReceive()
        {
            intValue = br.ReadInt32();
            if (intValue == -1)
                return -1;

            floatValue = br.ReadSingle();
            strValue = br.ReadString();
            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
            return 0;
        }

        // "송수신 시작" 버튼 클릯 ㅣ
        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (tcpClient.Connected)
                {
                    if (DataReceive() == -1)
                        break;
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            // 현재 아이피 주소를 아래 코드로 획득 가능 
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for(int  i =0; i < host.AddressList.Length; i++)
            {
                if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox1.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        // "접속 시작" 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient(); 
            if(tcpClient.Connected)
            {
                textBox2.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            }

            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);

        }
    }
}
