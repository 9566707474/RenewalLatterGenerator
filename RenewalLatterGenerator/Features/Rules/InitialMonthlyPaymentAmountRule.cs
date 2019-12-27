namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;
    using System;

    public class InitialMonthlyPaymentAmountRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            var amount = customerProduct.AverageMonthlyPremium - Math.Round(customerProduct.AverageMonthlyPremium, 2);

            customerProduct.InitialMonthlyPayment = Math.Round((amount * 12) + customerProduct.AverageMonthlyPremium, 2);

            return customerProduct;
        }
    }
}
