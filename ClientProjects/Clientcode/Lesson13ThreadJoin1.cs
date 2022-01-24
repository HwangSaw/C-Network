using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Lesson13ThreadJoin1
    {
        static void Func1()
        {
            for (int i =0; i< 30; i++)
            {
                Console.WriteLine("{0}", i);
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(Func1));
            th.Start();
            th.Join(); // 조인을 쓰게되면 30 까지 찍고 주스레드가 실행된다. 
            Console.WriteLine(" Main 종료 ");

        }
    }
}
