namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;
    using System;

    public class OtherMonthlyPaymentsAmountRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            customerProduct.OtherMonthlyPayments = Math.Round(customerProduct.AverageMonthlyPremium, 2);
            return customerProduct;
        }
    }
}
