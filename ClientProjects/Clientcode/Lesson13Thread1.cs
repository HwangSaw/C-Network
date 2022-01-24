using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Lesson13Thread1
    {
        static void Func()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("{0} ", i++);
                Thread.Sleep(300);

            }
        }

        static void Main(string[] args)
        {
            /*
            Thread th = new Thread(new ThreadStart(Func));
            th.Start();
            Console.WriteLine(" Main 종료 "); 
            // 메인스레드가 종료 후에도 th 스레드가 계속해서 돌고있다.
            // 즉 th 는 포그라운드 스레드인다.
            */

            Thread th = new Thread(new ThreadStart(Func));
            th.IsBackground = true;
            th.Start();
            Console.WriteLine(" Main 종료 ");
            // 메인스레드 종료 후에 th 스레드가 바로 종료된다.
            // th는 백그라운드 스레드이기 때문이다. 
        }
    }
}
