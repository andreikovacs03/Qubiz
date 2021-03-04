using System;
using Banking_System.Interfaces;
using Banking_System.Enums;

namespace Banking_System.Accounts
{
    class StudentAccount : BaseAccount, IAccount
    {
        public StudentAccount(string email, string address, string password, Currency currency) : base(email, address, password, currency){}

        public override void SetTransferLimit(Currency currency)
        {
            switch (currency)
            {
                case Currency.EUR:
                    TransferLimit = 2000;
                    break;
                case Currency.RON:
                    TransferLimit = 10000;
                    break;
                case Currency.USD:
                    TransferLimit = 2400;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
