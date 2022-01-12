// Lesson9BinaryReader01.cs 클라코드와 함께 실행
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Lesson9BinaryWrite01
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("10.10.10.60"), 3000); // 현재 코드가 돌아가는 아이피 적어라 
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryWriter bw = new BinaryWriter(ns))
            {
                bool YesNo = true;
                int Number = 12;
                float Pi = 3.14f;
                string Message = "Hello World!";

                bw.Write(YesNo);
                bw.Write(Number);
                bw.Write(Pi);
                bw.Write(Message);
            }

            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
