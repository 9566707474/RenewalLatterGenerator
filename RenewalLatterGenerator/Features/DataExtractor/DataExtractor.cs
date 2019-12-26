namespace RenewalLatterGenerator.Features.DataExtractor
{
    using RenewalLatterGenerator.Infrastructure;
    using RenewalLatterGenerator.Models;
    using System;
    using System.Collections.Generic;

    public class DataExtractor : IDataExtractor
    {
        private readonly IFileHandlerResolver fileHandlerResolver;

        public DataExtractor(IFileHandlerResolver fileHandlerResolver)
        {
            this.fileHandlerResolver = fileHandlerResolver;
        }

        public ICollection<CustomerProduct> GetCustomerProductsFromFile(string fileHandlerType, string filePath)
        {
            var fileHandler = this.fileHandlerResolver.Resolve(fileHandlerType);

            var customerProducts = fileHandler.ReadFile(filePath);

            Console.WriteLine(customerProducts);

            return customerProducts;
        }
    }
}
