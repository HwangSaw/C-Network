// 서버 코드 :Lesson8EchoServer2.cs 와 함께 실행 
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientCode
{
    class Lesson8EchoClient2
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            Byte[] Buffer = new byte[1024];
            byte[] SendMessage = Encoding.ASCII.GetBytes("Hello world!");
            ns.Write(SendMessage, 0, SendMessage.Length);
            int TotalCount = 0, ReadCount = 0;

            while( TotalCount < SendMessage.Length)
            {
                ReadCount = ns.Read(Buffer, 0, Buffer.Length);
                TotalCount += ReadCount;

                string RecvMessage = Encoding.ASCII.GetString(Buffer);
                Console.Write(RecvMessage);
            }

            Console.WriteLine("받은 문자열 바이트 수 : {0}", TotalCount);
            ns.Close();
            tcpClient.Close();
        }
    }
}
