/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{

    class Test
    {
        public void Print()
        {
            Console.WriteLine("Test!");
        }
    }
    class Lesson12Thread2
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th = new Thread(new ThreadStart(test.Print));
            th.Start();
        }
    }
}

*/

/*
// 멀티 스레드 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode    
{
    class Lesson12Thread2
    {
        static void Func1()
        {
            Console.WriteLine("스레드1 호출");
        }

        static void Func2()
        {
            Console.WriteLine("스레드2 호출");
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            th1.Start();
            th2.Start();
            Console.WriteLine("메인 종료");
            Console.ReadLine();
        }
    }
}

*/

/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Test
    {
        public void Print()
        {
            Console.WriteLine("스레드 호출");
        }
    }

    class Lesson12Thread2
    {
        static void Main(string[] args)
        {
            Test test1 = new Test();
            Test test2 = new Test();

            Thread th1 = new Thread(new ThreadStart(test1.Print));
            Thread th2 = new Thread(new ThreadStart(test2.Print));
            th1.Start();
            th2.Start();
            Console.ReadLine();
        }
    }
}
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCode
{
    class Lesson12Thread2
    {
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(" 스레드 1 호출 {0}", i);
        }

        static void Func2()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(" 스레드 2 호출 {0}", i);
        }

        static void Main(string[] args)
        {  
            Thread th1 = new Thread(new ThreadStart(Func1));
            Thread th2 = new Thread(new ThreadStart(Func2));
            th1.Start();
            th2.Start();
            Console.WriteLine("메인 종료");
            Console.ReadLine();
        }
    }
}