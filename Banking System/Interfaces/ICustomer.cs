using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Structs;

namespace Banking_System.Interfaces
{
    interface ICustomer
    {
        void AddAccount(IAccount account);
        IAccount SelectAccount(int number);
        Name Name { get; }
    }
}
