// 클라코드 :  Lesson8EchoClient2.cs  와 함께 실행
// 에코서버의 가장 기본적인 형태 
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    class Lesson8EchoServer2
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), );
            tcpListener.Start();
            byte[] Buffer = new byte[1024];
            int TotalByteCount = 0, ReadByteCount = 0;

            Console.WriteLine("서버");

            TcpClient tcpClient = tcpListener.AcceptTcpClient(); // 대기 상태 
            NetworkStream ns = tcpClient.GetStream(); // 연결 수락상태 

            while(true) // 무한루프 
            {
                ReadByteCount = ns.Read(Buffer, 0, Buffer.Length); // Read 후 대기 , 
                if (ReadByteCount == 0) // 0이 넘어오면 모든 데이터를 다 읽어서 더이상 읽을 내용이 없다. 
                    break; // 그러므로 반복문 종료 

                TotalByteCount += ReadByteCount;
                ns.Write(Buffer, 0, ReadByteCount); // 에코서버니깐 받은 만큼 클라이언트로 보낸다. 
                Console.Write(Encoding.ASCII.GetString(Buffer)); // 보낸걸 console로 출력 
            }

            // 네트워크 관련 스트림 및 클래스를 종료 
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
