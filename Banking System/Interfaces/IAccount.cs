using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Enums;

namespace Banking_System.Interfaces
{
    interface IAccount
    {
        //void Deposit(decimal amount);
        //void Withdraw(decimal amount);
        //void Transfer(decimal amount, IAccount acc1, IAccount acc2);
        void SetTransferLimit(Currency currency);
        void SetWithdrawLimit(decimal amount);
        void AddCard(ICard card);
        ICard SelectCard(int number);
        void Withdraw(decimal amount);
        void Deposit(decimal amount);
        void Transfer(decimal amount, IAccount transferAccount);
        decimal Balance { get; }
    }
}
