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

    class Test5
    {
        ThisLock lockObject = new ThisLock();
        public int Count = 0;

        public void ThreadProc()
        {
            Monitor.Enter(lockObject);
            for (int i= 0; i < 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID: {0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(lockObject);
        }
    }

    class Lesson15Async2
    {
        static void Main(string[] args)
        {
            Test5 test = new Test5();
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(test.ThreadProc));
            }

            for (int i = 0; i < 3; i++)
            {
                threads[i].Start();
            }
        }
    }
}
