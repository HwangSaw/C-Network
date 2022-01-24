using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    // lock 과 동일하게  private object obj = new  object()를 사용하여 동기화를 하는 예시이다. 
    class Test4
    {
        int Count;
        object obj = new object();
        public void IncreaseCount()
        {
            Monitor.Enter(obj);
            for (int i =0; i <5; i++)
            {
                Count++;
                Console.WriteLine("Thread ID: {0} count : {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            Monitor.Exit(obj);
        }
    }

    class Lesson15Async1
    {
        static void Main(string[] args)
        {
            Test4 test = new Test4();
            Thread th1 = new Thread(new ThreadStart(test.IncreaseCount));
            Thread th2 = new Thread(new ThreadStart(test.IncreaseCount));
            th1.Start();
            th2.Start();

        }
    }
}
