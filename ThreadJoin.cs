using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace MultiThreadingandTPL
{
    public class ThreadJoin
    {
        public ThreadJoin()
        {
            Console.WriteLine("Main Thread Started");
            Thread t1 = new Thread(Function1);
            Thread t2 = new Thread(Function2);
            t1.Start();
            t2.Start();
            //Specify timeout if not completed within specified milliseconds
            if (t1.Join(1000))
            {
                Console.WriteLine("Function1 completed");
            }
            else
            {
                Console.WriteLine("Function1 not completed");
            }
            Console.WriteLine("Exiting Main Thread");
        }
        public static void Function1()
        {
            Console.WriteLine("Function One Started");
            Thread.Sleep(3000);
            Console.WriteLine("Exiting Function One");
        }
        public static void Function2()
        {
            Console.WriteLine("Function Two Started");
        }

    }

}
