using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking_System.Interfaces;
using Banking_System.Enums;

namespace Banking_System
{
    class BaseAccount : IAccount
    {
        public decimal Balance { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Password { get; set; }
        string IBAN { get; set; }
        Currency Currency { get; set; }
        protected decimal WithdrawLimit { get; set; }
        protected decimal TransferLimit { get; set; }
        List<ICard> Cards = new List<ICard>();

        public BaseAccount(string email, string address, string password, Currency currency)
        {
            Balance = 0;
            Email = email;
            Address = address;
            Password = password;
            Currency = currency;
            IBAN = GenerateIBAN();
            SetTransferLimit(currency);
        }

        public void AddCard(ICard card) => Cards.Add(card);

        public virtual void SetTransferLimit(Currency currency)
        {
            switch (currency)
            {
                case Currency.EUR:
                    TransferLimit = 1000;
                    break;
                case Currency.RON:
                    TransferLimit = 5000;
                    break;
                case Currency.USD:
                    TransferLimit = 1200;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public virtual void SetWithdrawLimit(decimal amount) => WithdrawLimit = amount;

        public string GenerateIBAN()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string result = "RO";

            for (int i = 1; i <= 34; i++)
                result += chars[new Random().Next(chars.Length)];

            return result;
        }

        public ICard SelectCard(int number)
        {
            if (number > Cards.Count)
                throw new Exception($"Account number {number} doesn't exist.");

            return Cards[number];
        }

        public void Deposit(decimal amount) => Balance += amount;

        public void Withdraw(decimal amount) => Balance -= amount;

        public void Transfer(decimal amount, IAccount transferAccount)
        {
            Withdraw(amount);
            transferAccount.Deposit(amount);
        }
    }
}
