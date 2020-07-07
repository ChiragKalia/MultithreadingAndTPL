using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingandTPL
{
    public class ImportanceOfLocking
    {
        public ImportanceOfLocking()
        {
            Maths maths = new Maths();
            Thread t1 = new Thread(maths.Divide);
            t1.Start();
            maths.Divide();
        }
    }
    class Maths
    {
        public int Num1;
        public int Num2;
        public void Divide()
        {
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                lock (this)
                {
                    Num1 = r.Next(1, 2);
                    Num2 = r.Next(1, 2);
                    int result = Num1 / Num2;
                    Num1 = 0;
                    Num2 = 0;
                }
            }
        }
    }

}
