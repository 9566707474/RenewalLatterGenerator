namespace RenewalLatterGenerator.Features.DataExtractor
{
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Features.OutputFileHandler;
    using RenewalLatterGenerator.Features.Rules;
    using RenewalLatterGenerator.Infrastructure;
    using RenewalLatterGenerator.Models;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

            var customerProductList = ApplyPaymentCalculationRules(customerProducts);

            WriteOutput(customerProductList);

            return customerProducts;
        }

        private ICollection<CustomerProduct> ApplyPaymentCalculationRules(ICollection<CustomerProduct> customerProducts)
        {
            var payments = new ConcurrentBag<Payments>();
            foreach (var item in customerProducts)
            {
                payments.Add(new Payments(item));
            }

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(payments, parallelOptions, task =>
            {
                task.Calculate();
            });

            return payments.Select(p => p.CustomerProduct).ToList();
        }

        private void WriteOutput(ICollection<CustomerProduct> customerProducts)
        {
            var generateOutputFile = new ConcurrentBag<GenerateOutputFile>();
            foreach (var item in customerProducts)
            {
                generateOutputFile.Add(new GenerateOutputFile() { CustomerProduct = item, FileSystem = fileSystem });
            }

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(generateOutputFile, parallelOptions, task =>
            {
                task.Start();
            });
        }
    }
}
