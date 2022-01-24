using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }
    class Test6
    {
        ThisLock lockObject = new ThisLock();
        Mutex mut = new Mutex();
        public int Count = 0;

        public void ThreadProc()
        {
            mut.WaitOne();

            for (int i=0; i< 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID : {0}, Count: {1}", Thread.CurrentThread.GetHashCode(), Count);

            }
            mut.ReleaseMutex();
        }
    }

    class Lesson15Mutex2
    {
        static void Main(string[] args)
        {
            Test6 test = new Test6();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
