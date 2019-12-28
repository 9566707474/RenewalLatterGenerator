namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;
    using System;

    /// <summary>
    /// Used to apply InitialMonthlyPaymentAmountRule
    /// </summary>
    public class InitialMonthlyPaymentAmountRule : IRule
    {
        /// <summary>
        /// Apply Initial Monthly Payment Amount Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
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
