using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadingandTPL.Deadlocks
{
    public class AccountManager
    {
        Account _fromAccount; Account _toAccount;
        double _amountToTransfer;
        public AccountManager(Account fromAccount, Account toAccount, double amountToTransfer)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amountToTransfer = amountToTransfer;
        }
        public virtual void Transfer()
        {
            #region DeadlockingCode
            lock (_fromAccount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " has acquired Lock on " + _fromAccount.ID);
                //Paramount for deadlock as both threads will sleep and resume at the same time.
                Console.WriteLine("Suspended for 1 second");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + " is back and is trying to acquire lock on " + _toAccount.ID);
                lock (_toAccount)
                {
                    Console.WriteLine("This code will not be executed");
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposit(_amountToTransfer);
                }
            }
            #endregion
        }
    }

}
