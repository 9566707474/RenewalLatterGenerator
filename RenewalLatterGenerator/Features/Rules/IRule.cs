namespace RenewalLatterGenerator.Features.Rules
{
    using RenewalLatterGenerator.Models;

    public interface IRule
    {
        CustomerProduct Apply(CustomerProduct customerProduct);
    }
}
