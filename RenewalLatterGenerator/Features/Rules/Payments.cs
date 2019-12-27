namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;
    using System.Collections.Generic;

    public class Payments
    {
        public CustomerProduct CustomerProduct { get; set; }

        private ICollection<IRule> _rules = new List<IRule>();

        public Payments(CustomerProduct customerProduct)
        {
            CustomerProduct = customerProduct;
            _rules.Add(new CreditChargeRule());
            _rules.Add(new TotalPremiumRule());
            _rules.Add(new AverageMonthlyPremiumRule());
            _rules.Add(new InitialMonthlyPaymentAmountRule());
            _rules.Add(new OtherMonthlyPaymentsAmountRule());
        }

        public void Calculate()
        {
            foreach (var rule in _rules)
            {
                CustomerProduct = rule.Apply(CustomerProduct);
            }
        }
    }
}
