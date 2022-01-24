
// PlatformNotSupportedException  exception발생 Abort() 이제 작동안한다. .NET 5.0 이상 및 .NET Core: 모든 경우에 해당

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Lesson13ThreadAbort1
    {
        static void Main(string[] args)
        {
            Thread th = new Thread(new ThreadStart(ThreadProc1));
            try
            {
                th.Start();
            }
            catch(ThreadAbortException e)
            {
                Console.WriteLine(" 예외 발 생!!! ");
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Main스레드 {0 }", Thread.CurrentThread.GetHashCode());
            Console.WriteLine(" Main 종료 ");

        }

        private static void ThreadProc1()
        {
            Console.WriteLine("ThreadProc1 스레드 {0} ", Thread.CurrentThread.GetHashCode());
            Thread th = new Thread(new ThreadStart(ThreadProc2));
            try
            {
                th.Start();

            }
            catch (PlatformNotSupportedException e)
            {
                Console.WriteLine(" 예외 발 생!!! ");
                Console.WriteLine(e.ToString());
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0} ", i * 10);
                Thread.Sleep(200);

                if (i == 3)
                {
                    Console.WriteLine("ThreadProc1 종료");

                    // <<<----- Thread abort is not supported on this platform // Unhandled exception발생 abort 이제 작동안한다. .NET 5.0 이상 및 .NET Core: 모든 경우에 해당합니다.
                    // abort 대신 CancellationToken 이나 그냥 리턴(종료)  하면 된다.
                    return;
                    // Thread.CurrentThread.Abort(); 
                }
            }

        }

        private static void ThreadProc2()
        {
            Console.WriteLine("ThreadProc2  스레드 {0 } ", Thread.CurrentThread.GetHashCode());

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", i);
                Thread.Sleep(200);
            }
            Console.WriteLine("ThreadProc2 종료 ");
        
        }
    }
}
