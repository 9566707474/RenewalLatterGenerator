namespace RenewalLatterGenerator.Features.DataExtractor
{
    using RenewalLatterGenerator.Models;
    using System.Collections.Generic;

    public interface IDataExtractor
    {
        ICollection<CustomerProduct> GetCustomerProductsFromFile(string fileHandlerType, string filePath);
    }
}
