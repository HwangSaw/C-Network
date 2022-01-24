using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

// 다수의 스레드가하나의 변수( 현재 코드에서는 Count) 를 사용하는 경우 크리티컬 섹션을 통한 동기화 예제 
namespace Server
{
    class Test1
    {
        static object obj = new object();
        static int Count;
        public void ThreadProc()
        {
            lock (obj)// obj 는 크리티컬섹션에 들어가기위한 임시 변수일뿐이다 
            {
                // 크리티컬 섹션 ( == 임계영역 == 경계 영역 ) 
                for ( int i = 0; i< 10; i++)
                {
                    Count++;
                    Console.WriteLine("Thread ID {0} result {1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
        }
    }
    class Lesson14Async2
    {
        static void Main(string[] args)
        {
            Test1 test = new Test1();
            Thread th1 = new Thread(new ThreadStart(test.ThreadProc));
            Thread th2 = new Thread(new ThreadStart(test.ThreadProc));
            th1.Start();
            th2.Start();
        }
    }
}
