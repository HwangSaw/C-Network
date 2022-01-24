using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    class Lesson15Mutex1
    {
        static Mutex mut = new Mutex();
        static int Count;

        static void ThreadProc()
        {
            mut.WaitOne();
            for (int i= 0; i< 5; i++)
            {
                Count++;
                Console.WriteLine("Thread ID: {0} Count : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            mut.ReleaseMutex();
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(ThreadProc));
            Thread th2 = new Thread(new ThreadStart(ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
