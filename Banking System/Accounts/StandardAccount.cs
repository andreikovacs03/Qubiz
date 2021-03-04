using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Interfaces;
using Banking_System.Enums;

namespace Banking_System.Accounts
{
    class StandardAccount : BaseAccount, IAccount
    {
        public StandardAccount(string email, string address, string password, Currency currency) : base(email, address, password, currency){}

    }
}
