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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCode2
{
    public partial class Form1 : Form
    {
        delegate void SetTextCallback(string text);

        private TcpListener tcpListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void AcceptClient()
        {
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    this.ListAddItem(str);
                    //크로스 스레드 작업이 잘못되었습니다. 'listBox1' 컨트롤이 자신이 만들어진 스레드가 아닌 스레드에서 액세스되었습니다 <- 아래 주석풀면 에러난다. 
                    //listBox1.Items.Add(str);
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground = true;
                th.Start();

                //Echoserver echoServer = new EchoServer();
                //Thread th =new Thread(new ThreadStart(echoServer.Process));
                //th.IsBackground = true;
                //th.Start(tcpClient);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int  i = 0; i <host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox1.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void Form1_FormClosing (object sender, FormClosingEventArgs e)
        {
            if( tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }

        private void ListAddItem(string str)
        {
            if (this.listBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ListAddItem);
                this.Invoke(d, new object[] { str });

            }
            else
            {
                this.listBox1.Items.Add(str);
            }
        }
    }

    class EchoServer
    {
        TcpClient RefClient;
        private BinaryReader br = null;
        private BinaryWriter bw = null;
        int intValue;
        float floatValue;
        string strValue;

        public EchoServer(TcpClient client)
        {
            RefClient = client;
        }

        public void Process()
        {
            NetworkStream ns = RefClient.GetStream();
            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                
                while (true)
                {
                    intValue = br.ReadInt32();
                    floatValue = br.ReadSingle();
                    strValue = br.ReadString();

                    bw.Write(intValue);
                    bw.Write(floatValue);
                    bw.Write(strValue);
                }
            }
            catch (SocketException se)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                MessageBox.Show(se.Message);
                // <<<----- Thread abort is not supported on this platform // Unhandled exception발생 abort 이제 작동안한다. .NET 5.0 이상 및 .NET Core: 모든 경우에 해당합니다.
                // abort 대신 CancellationToken 이나 그냥 리턴(종료)  하면 된다.
                return;
                //Thread.CurrentThread.Abort();
            }catch(IOException ex)
            {
                //연결이 끊어져서 읽을 수가 없을 때 처리
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                // <<<----- Thread abort is not supported on this platform // Unhandled exception발생 abort 이제 작동안한다. .NET 5.0 이상 및 .NET Core: 모든 경우에 해당합니다.
                // abort 대신 CancellationToken 이나 그냥 리턴(종료)  하면 된다.
                return;
                //Thread.CurrentThread.Abort();
            }
        }
    }
}
