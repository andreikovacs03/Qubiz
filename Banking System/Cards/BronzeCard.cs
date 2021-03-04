using Banking_System.Enums;
using System;
using System.Collections.Generic;
using Banking_System.Structs;

namespace Banking_System.Cards
{
    class BronzeCard : BaseCard, ICard
    {
        protected override List<CardFeatures> Features
        {
            get => new List<CardFeatures> { CardFeatures.CustomerSupport,
                                            CardFeatures.FreeCardDelivery };
        }

        protected override decimal MonthlyPrice { get => (decimal)2.99; }

        public BronzeCard(Name holderName, CardService service, string pin) : base(holderName, service, pin) { }
    }
}
