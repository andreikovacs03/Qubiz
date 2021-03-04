using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Enums;
using Banking_System.Interfaces;

namespace Banking_System.Accounts
{
    class EnterpriseAccount : BaseAccount, IAccount
    {
        public EnterpriseAccount(string email, string address, string password, Currency currency) : base(email, address, password, currency){}

        public override void SetTransferLimit(Currency currency)
        {
            switch (currency)
            {
                case Currency.EUR:
                    TransferLimit = 10000;
                    break;
                case Currency.RON:
                    TransferLimit = 50000;
                    break;
                case Currency.USD:
                    TransferLimit = 12000;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
