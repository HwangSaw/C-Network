using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Lesson13CurrentThread1
    {
        static void ThreadProc()
        {
            Console.WriteLine("스레드 id : {0} ", Thread.CurrentThread.GetHashCode());
        }

        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc));
            th.Start();
            Console.WriteLine(" Main 스레드 id : {0}", Thread.CurrentThread.GetHashCode());
        }
    }
}
