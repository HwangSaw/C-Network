using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server
{
    // 다수의 스레드가 하나의 객체를 사용하는 경우
    class ThisLock
    {
        public void IncreaseCount(ref int count)
        {
            count++;
        }
    }

    class Test3
    {
        ThisLock lockObject = new ThisLock();
        int Count = 0;


        public void ThreadProc()
        {
            // [ 케이스 1]  Count 가 뒤죽박죽 증가된다. 
            /*
            for (int i = 0; i < 3; i++)
            {
                lockObject.IncreaseCount(ref Count);
                Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
            }
            */

            // [ 케이스 2]  Count 가 차례로 증가된다. 
            ///*ThisLock 말고  object로 크리티컬섹션(==임계영역, 경계영역)을 만들어도 아래코드돌린것과 결과 동일. 
            lock (lockObject)
            {
                for (int i = 0; i < 3; i++)
                {
                    lockObject.IncreaseCount(ref Count);
                    Console.WriteLine("Thread ID:{0} Count:{1}", Thread.CurrentThread.GetHashCode(), Count);
                }
            }
            //*/

        }
    }
    class Lesson14Async3
    {
        static void Main(string[] args)
        {
            Test3 test = new Test3();
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
