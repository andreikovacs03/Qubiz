using System;
using System.Collections.Generic;
using Banking_System.Enums;
using Banking_System.Structs;

namespace Banking_System.Cards
{
    class SilverCard : BaseCard, ICard
    {
        protected override List<CardFeatures> Features
        {
            get => new List<CardFeatures> { CardFeatures.CustomerSupport,
                                            CardFeatures.FreeCardDelivery,
                                            CardFeatures.NoATMFee,
                                            CardFeatures.CustomisableCards };
        }

        protected override decimal MonthlyPrice { get => (decimal)6.99; }

        public SilverCard(Name holderName, CardService service, string pin) : base(holderName, service, pin) { }
    }
}
