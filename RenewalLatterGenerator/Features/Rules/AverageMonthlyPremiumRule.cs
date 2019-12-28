namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;

    public class AverageMonthlyPremiumRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            if (customerProduct?.TotalPremium == null)
            {
                throw new RuleException("Customer product total premium not found");
            }
            customerProduct.AverageMonthlyPremium = customerProduct.TotalPremium / 12;
            return customerProduct;
        }
    }
}
