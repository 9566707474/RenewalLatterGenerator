namespace RenewalLatterGenerator.Features.DataExtractor
{
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Infrastructure;
    using RenewalLatterGenerator.Models;
    using System;
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

            OutputTemplate.Load = this.fileSystem.ReadAllText(@"C:\Loga\Loga\doc\ConsumerCodeTest\RenewalLatterGenerator\RenewalLatterGenerator\App_Data\InvitationTemplate.txt");

            WriteOutput(customerProducts);

            Console.WriteLine(customerProducts);

            return customerProducts;
        }

        private void WriteOutput(ICollection<CustomerProduct> customerProducts)
        {
            foreach (var item in customerProducts)
            {
                var outputFile = @"C:\Test\" + item.Id + item.FirstName + ".txt";

                var invitationTemplate = OutputTemplate.Get;

                foreach (var keyValue in OutputMapping.Columns)
                {
                    invitationTemplate = invitationTemplate.Replace(keyValue.Key, GetPropertyValue(item, keyValue.Value).ToString());
                }

                this.fileSystem.WriteAllText(outputFile, invitationTemplate);
            }

        }

        private static object GetPropertyValue(object source, string propertyName)
        {
            var propertyInfo = source.GetType().GetProperty(propertyName);
            return propertyInfo.GetValue(source, null);
        }

    }
}
