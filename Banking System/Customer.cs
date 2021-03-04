using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Interfaces;
using Banking_System.Structs;

namespace Banking_System
{
    class Customer : ICustomer
    {
        public Name Name { get; set; }
        List<IAccount> Accounts = new List<IAccount>();

        public Customer(Name name, IAccount account)
        {
            Name = name;
            Accounts.Add(account);
        }

        public void AddAccount(IAccount account) => Accounts.Add(account);

        public IAccount SelectAccount(int number)
        {
            if (number > Accounts.Count)
                throw new Exception($"Account number {number} doesn't exist.");

            return Accounts[number];
        }
    }
}
