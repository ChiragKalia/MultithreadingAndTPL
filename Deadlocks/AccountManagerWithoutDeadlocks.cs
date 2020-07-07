using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace MultiThreadingandTPL.Deadlocks
{
    public class AccountManagerWithoutDeadlocks : AccountManager
    {
        Account _fromAccount; Account _toAccount;
        double _amountToTransfer;
        public AccountManagerWithoutDeadlocks(Account fromAccount, Account toAccount, double amountToTransfer) : base(fromAccount, toAccount, amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }
        public override void Transfer()
        {
            Object _lock1, _lock2;
            if (_fromAccount.ID > _toAccount.ID)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock1 = _toAccount;
                _lock2 = _fromAccount;
            }
            #region DeadlockingCodeResolved
            //Using the System.Diagnostics namespace, We can get a stopwatch and count how much time it took to execute this block of code/
            Stopwatch s = new Stopwatch();
            s.Start();
            Thread.Sleep(1000);
            lock (_lock1)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " has acquired Lock on " + ((Account)_lock1).ID);
                //Paramount for deadlock as both threads sleep and resume at the same time.
                //Console.WriteLine("Suspended for 1 second");
                //Thread.Sleep(1000);
                lock (_lock2)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " has acquired Lock on " + ((Account)_lock2).ID);
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);
                }
            }
            s.Stop();
            Console.WriteLine("Total Elapsed Time for Thread {0} is: {1} ", Thread.CurrentThread.Name, s.Elapsed);
            #endregion
        }
    }
}
