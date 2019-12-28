namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Exceptions;
    using RenewalLatterGenerator.Models;
    using System;

    public class CreditChargeRule : IRule
    {
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
