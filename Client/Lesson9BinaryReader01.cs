// Lesson9BinaryWrite01.cs 서버코드와 함께 실행 
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace ClientCode
{
    class Lesson9BinaryReader01
    {
        static void Main(string[] args)
        {
            bool YesNo;
            int Number;
            float Pi;
            string Message;

            TcpClient tcpClient = new TcpClient("10.10.10.60", 3000);
            NetworkStream ns = tcpClient.GetStream();
            using (BinaryReader br = new BinaryReader(ns))
            {
                YesNo = br.ReadBoolean();
                Number = br.ReadInt32();
                Pi = br.ReadSingle();
                Message = br.ReadString();

            }

            ns.Close();
            tcpClient.Close();

            Console.WriteLine(YesNo);
            Console.WriteLine(Number);
            Console.WriteLine(Pi);
            Console.WriteLine(Message);
        }
    }
}
