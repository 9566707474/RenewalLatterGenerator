namespace RenewalLatterGenerator.Features.Rules
{
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
            customerProduct.TotalPremium = customerProduct.AnnualPremium + customerProduct.CreditCharge;
            return customerProduct;
        }
    }
}
