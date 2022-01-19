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
    class Lesson12Thread1
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Thread th = new Thread(new ThreadStart(test.Print));
            th.Start();
        }
    }
}
