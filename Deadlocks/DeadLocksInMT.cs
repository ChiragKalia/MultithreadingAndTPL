using MultiThreadingandTPL.Deadlocks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingandTPL
{
    public class DeadLocksInMT
    {

        /// <summary>
        ///Deadlocks occur when we have multiple threads trying to access shared resources or 
        ///shared block of code. In the Transfer method, I have provided one such implementation.
        /// </summary>
        public DeadLocksInMT()
        {
            Console.WriteLine("Main Started");
            Account fromAccount = new Account(1, 150);
            Account toAccount = new Account(2, 50);
            AccountManager managerA = new AccountManager(fromAccount, toAccount, 50);
            Thread t1 = new Thread(managerA.Transfer); t1.Name = "thread 1";
            t1.Start();

            AccountManager managerB = new AccountManager(toAccount, fromAccount, 50);
            Thread t2 = new Thread(managerB.Transfer); t2.Name = "thread 2";
            t2.Start();

            t1.Join(); t2.Join();

            Console.WriteLine("Main Thread Exiting");
        }
    }

}
