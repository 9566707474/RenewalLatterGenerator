namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;

    /// <summary>
    /// Used to calculate the total premium amount
    /// </summary>
    public class TotalPremiumRule : IRule
    {
        /// <summary>
        /// Apply Total Premium Rule
        /// </summary>
        /// <param name="customerProduct">customer product</param>
        /// <returns>customer product</returns>
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.AnnualPremium == null || customerProduct?.CreditCharge == null)
            {
                throw new RuleException("Customer product annual premium or credit charge not found");
            }

            customerProduct.TotalPremium = customerProduct.AnnualPremium + customerProduct.CreditCharge;
            return customerProduct;
        }
    }
}
