namespace RenewalLatterGenerator.Features.FileHandlers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using RenewalLatterGenerator.Models;

    public class CsvFileHandler : IFileHandler
    {
        private const char Delimiter = ',';

        public CsvFileHandler()
        {
            Type = "Csv";
        }

        public string Type { get; private set; }

        public ICollection<CustomerProduct> ReadFile(string filePath)
        {
            var customerProducts = new List<CustomerProduct>();

            Parallel.ForEach(File.ReadLines(filePath), line =>
            {
                customerProducts.Add(GetCustomerProductFromLine(line));
            });

            return customerProducts;
        }

        private CustomerProduct GetCustomerProductFromLine(string line)
        {
            var attributes = line.Split(Delimiter);

            if (attributes != null && attributes.Length == 7)
            {
                return new CustomerProduct()
                {
                    Id = Convert.ToInt64(attributes[0]),
                    Title = attributes[1],
                    FirstName = attributes[2],
                    Surname = attributes[3],
                    ProductName = attributes[4],
                    PayoutAmount = Convert.ToDouble(attributes[5]),
                    AnnualPremium = Convert.ToDouble(attributes[6]),
                };
            }

            return null;
        }
    }
}
