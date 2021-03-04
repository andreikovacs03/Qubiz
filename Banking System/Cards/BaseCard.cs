using System;
using Banking_System.Enums;
using System.Collections.Generic;
using Banking_System.Structs;

namespace Banking_System
{
    class BaseCard : ICard
    {
        string CardNumber { get; }
        string CVV { get; }
        string PIN { get; set; }
        DateTime ExpirationDate { get; }
        Name HolderName { get; }
        CardService Service { get; }
        virtual protected List<CardFeatures> Features { get;}
        virtual protected decimal MonthlyPrice { get;  }

        public BaseCard(Name holderName, CardService service, string pin)
        {
            CardNumber = GenerateCardNumber();
            CVV = GenerateCVV();
            ExpirationDate = GenerateExpirationDate();
            HolderName = holderName;
            Service = service;
            PIN = pin;
        }

        public string GenerateCardNumber()
        {
            string result = "";
            var rnd = new Random();

            for (int i = 1; i <= 16; i++)
                result += rnd.Next(10);

            return result;
        }

        public string GenerateCVV()
        {
            string result = "";
            var rnd = new Random();

            for (int i = 1; i <= 3; i++)
                result += rnd.Next(10);

            return result;
        }

        DateTime GenerateExpirationDate() => DateTime.Now.AddYears(4);

        public void ChangePin(string pin) => PIN = pin;



        public bool CheckPin(string pin) => pin == PIN;
    }
}
