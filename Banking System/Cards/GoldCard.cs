using System;
using Banking_System.Enums;
using System.Collections.Generic;
using Banking_System.Structs;

namespace Banking_System.Cards
{
    class GoldCard : BaseCard, ICard
    {
        protected override List<CardFeatures> Features
        {
            get => new List<CardFeatures> { CardFeatures.CustomerSupport,
                                            CardFeatures.FreeCardDelivery,
                                            CardFeatures.NoATMFee,
                                            CardFeatures.CustomisableCards,
                                            CardFeatures.PremiumCustomerSupport,
                                            CardFeatures.InternationalPayments };
        }

        protected override decimal MonthlyPrice { get => (decimal)12.99; }

        public GoldCard(Name holderName, CardService service, string pin) : base(holderName, service, pin) { }
    }
}
