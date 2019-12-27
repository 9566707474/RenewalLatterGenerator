namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;

    public class TotalPremiumRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            customerProduct.TotalPremium = customerProduct.AnnualPremium + customerProduct.CreditCharge;
            return customerProduct;
        }
    }
}
