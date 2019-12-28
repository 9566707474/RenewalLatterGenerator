namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;
    using System;

    /// <summary>
    /// Used to credit charge rule
    /// </summary>
    public class CreditChargeRule : IRule
    {
        /// <summary>
        /// Apply Credit Charge Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AnnualPremium == null)
            {
                throw new RuleException("Customer product annual premium not found");
            }
            customerProduct.CreditCharge = Math.Round((customerProduct.AnnualPremium / 100) * 5, 2);
            return customerProduct;
        }
    }
}
