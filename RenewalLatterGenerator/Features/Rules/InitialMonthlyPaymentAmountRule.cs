namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;
    using System;

    public class InitialMonthlyPaymentAmountRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AverageMonthlyPremium == null)
            {
                throw new RuleException("Customer product average monthly premium not found");
            }
            var amount = customerProduct.AverageMonthlyPremium - Math.Round(customerProduct.AverageMonthlyPremium, 2);

            customerProduct.InitialMonthlyPayment = Math.Round((amount * 12) + customerProduct.AverageMonthlyPremium, 2);

            return customerProduct;
        }
    }
}
