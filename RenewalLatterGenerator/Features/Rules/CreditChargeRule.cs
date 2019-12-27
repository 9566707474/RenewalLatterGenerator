namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;
    using System;

    public class CreditChargeRule : IRule
    {
        public CustomerProduct Apply(CustomerProduct customerProduct)
        {
            customerProduct.CreditCharge = Math.Round((customerProduct.AnnualPremium / 100) * 5, 2);
            return customerProduct;
        }
    }
}
