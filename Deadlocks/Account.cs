using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadingandTPL.Deadlocks
{
    public class Account
    {
        double _balance; int _id;
        public int ID
        {
            get { return _id; }
        }
        public Account(int id, double balance)
        {
            _id = id;
            _balance = balance;
        }
        public void Deposit(double amount)
        {
            this._balance += amount;
        }
        public void Withdraw(double amount)
        {
            this._balance -= amount;
        }
    }
}
