// 서버 코드 : Lesson8StreamWriter01.cs 와 함께 실행
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientCode
{
    class Lesson8StreamRead
    {
        static void Main(string[] args)
        {
            char[] buffer = new char[100];
            TcpClient tcpClient = new TcpClient("10.10.10.60", 3000); // 어차피 자기 자신의 아이피를 적을거라서  loclahost적음 ipconfig해서 ip4 보고  적어도 동일 
            NetworkStream ns = tcpClient.GetStream();// 
            using (StreamReader sr = new StreamReader(ns))
            {
                string str = sr.ReadLine();
                Console.WriteLine(str);  // yesNo
                str = sr.ReadLine();
                Console.WriteLine(str); // 12  , int.Parse(str) 을 통해서 int형변환해서 사용할수 있다. 
                str = sr.ReadLine();
                Console.WriteLine(str); //3.141592f
                str = sr.ReadLine();
                Console.WriteLine(str); // hello World!
            }

            ns.Close();
            tcpClient.Close();
        }
    }
}
