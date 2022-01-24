using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    // 정적 변수를 두개의 스레드에서 다루는 예제 
    // 결과가 뒤죽박죽으로 나온다  1씩 증가 안함 두개의 스레드가 무작위로 Count를 증가시키기에 
    class Test
    {
        static int Count; // 공유자원 

        public void ThreadProc()
        {
            for (int i=0; i <10; i++)
            {
                Count++;
                Console.WriteLine("Thread ID : {0} result: {1}", Thread.CurrentThread.GetHashCode(), Count);
            }
        }

    }

    class Lesson14Async1bar2
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }

    }
}
