/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            string Address = Console.ReadLine();
            IPAddress IP = IPAddress.Parse(Address);
            Console.WriteLine("Ip : {0}", IP.ToString());
        }
    }
}
*/

/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] IP = Dns.GetHostAddresses("www.naver.com");
            foreach (IPAddress HostIP in IP)
            {
                Console.WriteLine("{0}  ", HostIP);
            }
        }
    }
}
*/

/*
// "네트워크 클래스 (2/5)" 강의 예제 1 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");

            foreach(IPAddress ip in HostInfo.AddressList)
            {
                Console.WriteLine("{0}", ip);
            }

            Console.WriteLine("{0}", HostInfo.HostName);
        }
    }
}
*/

/*

// "네트워크 클래스 (2/5)" 강의 예제 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace IPAddress01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress IPInfo = IPAddress.Parse("127.0.0.1");
            int Port = 13;
            IPEndPoint EndPointInfo = new IPEndPoint(IPInfo, Port);
            Console.WriteLine("ip: {0} port : {1}", EndPointInfo.Address, EndPointInfo.Port);
            Console.WriteLine(EndPointInfo.ToString());
            Console.ReadKey();
        }
    }
}
*/

/*
// "네트워크 클래스 (3/5)" 강의 예제 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpListener01
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 13);
            Console.WriteLine("{0}", tcpListener.LocalEndpoint.ToString());
            Console.ReadKey();
        }
    }
}
*/

// "네트워크 클래스 (3/5)" 강의 예제 2
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace AcceptTcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("10.10.10.60"), 7);  // 앞의 ip는 코드실행하는 컴퓨터의 ip주소로 설정한다. 
            tcpListener.Start();
            Console.WriteLine(" 대기 상태 시작 ");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            Console.WriteLine("대기 상태 종료"); // 연결완료상태라고 보면된다. 연결이 돼야 대기상태가 종료됨으로  
            tcpListener.Stop();
        }
    }
}
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("10.10.10.60", 7);// 앞의 ip는 코드실행하는 컴퓨터의 ip주소로 설정한다. ipconfig 쳐서 ip4 적기 
            if (tcpClient.Connected)
                Console.WriteLine("서버 연결 성공");
            else
                Console.WriteLine("서버 연결 실패");

            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
