namespace RenewalLatterGenerator.Features.DataExtractor
{
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Infrastructure;
    using RenewalLatterGenerator.Models;
    using System.Collections.Generic;

    public class DataExtractor : IDataExtractor
    {
        private readonly IFileHandlerResolver fileHandlerResolver;

        private readonly IFileSystem fileSystem;

        public DataExtractor(IFileHandlerResolver fileHandlerResolver, IFileSystem fileSystem)
        {
            this.fileHandlerResolver = fileHandlerResolver;
            this.fileSystem = fileSystem;
        }

        public ICollection<CustomerProduct> GetCustomerProductsFromFile(string fileHandlerType, string filePath)
        {
            var fileHandler = this.fileHandlerResolver.Resolve(fileHandlerType);

            var customerProducts = fileHandler.ReadFile(filePath);

            return customerProducts;
        }
    }
}
