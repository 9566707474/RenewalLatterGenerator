namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;
    using System;

    /// <summary>
    /// Used to calculate the other monthly payments amount
    /// </summary>
    public class OtherMonthlyPaymentsAmountRule : IRule
    {
        /// <summary>
        /// Apply Other Monthly Payments Amount Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AverageMonthlyPremium == null)
            {
                throw new RuleException("Customer product average monthly premium not found");
            }

            customerProduct.OtherMonthlyPayments = Math.Round(customerProduct.AverageMonthlyPremium, 2);
            return customerProduct;
        }
    }
}
