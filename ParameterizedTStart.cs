using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace MultiThreadingandTPL
{
    public class ParameterizedTStart
    {
        public ParameterizedTStart()
        {
            Console.WriteLine("Enter Target Number");
            //If we want our input to be type safe, We can do that by encapsulating
            //the Print numbers method and by expecting integer in the constructor.
            object target = Console.ReadLine();
            //ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart( PrintNumbers);
            //The Complier translates to the above line.
            Thread t1 = new Thread(PrintNumbers); 
            t1.Start(target);
        }
        public static void PrintNumbers(object target)
        {
            int t;
            if(Int32.TryParse(target.ToString(), out t))
            {
                for (int i = 1; i <= t; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
