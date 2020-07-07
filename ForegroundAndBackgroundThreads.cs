using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingandTPL
{
    public class ForegroundAndBackgroundThreads
    {
        public ForegroundAndBackgroundThreads()
        {
            //If we don't create a new ThreadStart Delegate then .NET Core does it automatically for us.
            Thread t = new Thread(Function1);
            Console.WriteLine(t.IsThreadPoolThread);
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Exited Main Function");
        }
        static void Function1()
        {
            Console.WriteLine("Entered Function1");
            Console.ReadLine();
            Console.WriteLine("Exited Function1");
        }
    }

}
