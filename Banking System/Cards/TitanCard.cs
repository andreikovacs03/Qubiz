using Banking_System.Enums;
using System.Collections.Generic;
using Banking_System.Structs;

namespace Banking_System.Cards
{
    class TitanCard : BaseCard, ICard
    {
        protected override List<CardFeatures> Features
        {
            get => new List<CardFeatures> { CardFeatures.CustomerSupport,
                                            CardFeatures.FreeCardDelivery,
                                            CardFeatures.NoATMFee,
                                            CardFeatures.CustomisableCards,
                                            CardFeatures.PremiumCustomerSupport,
                                            CardFeatures.InternationalPayments,
                                            CardFeatures.ReturnProtection,
                                            CardFeatures.NoExchangeFee };
        }
        protected override decimal MonthlyPrice { get => (decimal)18.99; }

        public TitanCard(Name holderName, CardService service, string pin) : base(holderName, service, pin) { }

    }
}
