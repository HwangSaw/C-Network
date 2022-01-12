// 클라 코드 : Lesson8StreamRead.cs 와 함께 실행 
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Lesson8StreamWriter01
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            // 보낼 데이터들 
            bool YesNo = false;
            int Val1 = 12;
            float pi = 3.141592f;
            string Message = "Hello World!";

            // 보내기 시작 
            NetworkStream ns = tcpClient.GetStream(); // tcpClient를 통해 stream 획득
            using (StreamWriter sw  = new StreamWriter(ns)) // using 구문을 사용해서 StreamWriter.Close()자동호출되게 처리 
            {
                sw.AutoFlush = true; // StreamWriter버퍼를 비워주는 옵션 
                sw.WriteLine(YesNo);
                sw.WriteLine(Val1);
                sw.WriteLine(pi);
                sw.WriteLine(Message);
                // 하나씩WriteLine을 서버에서 보냄으로 클라에서도 대등하게 ReadLine()있을것 예상 가능 
            }

            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();

        }
    }
}
