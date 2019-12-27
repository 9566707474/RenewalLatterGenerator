namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;
    using System.Collections.Generic;

    public class Payments
    {
        public CustomerProduct CustomerProduct { get; set; }

        private ICollection<IRule> rules = new List<IRule>();

        public Payments(CustomerProduct customerProduct)
        {
            CustomerProduct = customerProduct;
            rules.Add(new CreditChargeRule());
            rules.Add(new TotalPremiumRule());
            rules.Add(new AverageMonthlyPremiumRule());
            rules.Add(new InitialMonthlyPaymentAmountRule());
            rules.Add(new OtherMonthlyPaymentsAmountRule());
        }

        public void Calculate()
        {
            foreach (var rule in rules)
            {
                CustomerProduct = rule.Apply(CustomerProduct);
            }
        }
    }
}
