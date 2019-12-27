namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;

    public class AverageMonthlyPremiumRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            customerProduct.AverageMonthlyPremium = customerProduct.TotalPremium / 12;
            return customerProduct;
        }
    }
}
