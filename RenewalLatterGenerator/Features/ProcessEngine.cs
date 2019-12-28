namespace RenewalLatterGenerator.Features
{
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Features.DataExtractor;
    using RenewalLatterGenerator.Features.OutputFileHandler;
    using RenewalLatterGenerator.Features.Rules;
    using RenewalLatterGenerator.Models;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    public class ProcessEngine : IProcessEngine
    {
        private readonly IFileSystem fileSystem;

        private readonly IConfigurationManagerFacade ConfigurationManagerFacade;

        private readonly IDataExtractor dataExtractor;

        public ProcessEngine(IConfigurationManagerFacade ConfigurationManagerFacade, IFileSystem fileSystem, IDataExtractor dataExtractor)
        {
            this.fileSystem = fileSystem;
            this.ConfigurationManagerFacade = ConfigurationManagerFacade;
            this.dataExtractor = dataExtractor;
        }

        public void Start()
        {
            var files = fileSystem.GetFiles(ConfigurationManagerFacade.InputFileLocation, ConfigurationManagerFacade.InputFilePattern);

            foreach (var item in files)
            {
                var fileType = fileSystem.GetFileType(item);
                var customerProducts = dataExtractor.GetCustomerProductsFromFile(fileType, item);

                var templatePath = GetExecutionPath() + Constants.OutputTemplatePath;

                OutputTemplate.Load = this.fileSystem.ReadAllText(templatePath);

                var customerProductList = ApplyPaymentCalculationRules(customerProducts);

                WriteOutput(customerProductList);
            }
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
                generateOutputFile.Add(new GenerateOutputFile() { CustomerProduct = item, FileSystem = fileSystem, FilePath = ConfigurationManagerFacade.OutputFileLocation });
            }

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(generateOutputFile, parallelOptions, task =>
            {
                task.Start();
            });
        }

        private static string GetExecutionPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

    }
}
