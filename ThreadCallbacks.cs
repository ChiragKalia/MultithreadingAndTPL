using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingandTPL
{
    public delegate void SumOfNumbersCallback(int sum);
    public class ThreadCallbacks
    {
        public ThreadCallbacks()
        {
            Console.WriteLine("Please enter target number");
            object o = Console.ReadLine();
            int sum;
            if(Int32.TryParse(o.ToString(), out sum)){
                SumOfNumbersCallback callback = new SumOfNumbersCallback(PrintSumOfNumbers);
                Number n = new Number(sum, callback);
                Thread t = new Thread(n.CalculateSumOfNumbers);
                t.Start();
            }
        }
        /// <summary>
        /// Callback function
        /// </summary>
        /// <param name="sum">The sum of numbers passed</param>
        public static void PrintSumOfNumbers(int sum)
        {
            Console.WriteLine("Sum of numbers is: "+ sum);
        }
    }
    class Number
    {
        int _target;
        SumOfNumbersCallback _callback;
        public Number(int target, SumOfNumbersCallback callback)
        {
            _target = target;
            _callback = callback;
        }
        public void CalculateSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                sum += i;
            }
            if (_callback != null)
            {
                _callback(sum);
            }
        }    
    }
}
