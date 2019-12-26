namespace RenewalLatterGenerator
{
    using Castle.Windsor;
    using RenewalLatterGenerator.Features.DataExtractor;
    using RenewalLatterGenerator.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            WindsorConfig.Install(container);

            var dataExtractor = container.Resolve<IDataExtractor>();
            var value = dataExtractor.GetCustomerProductsFromFile("Csv", @"C:\Loga\Loga\doc\ConsumerCodeTest\Customer.csv");

        }
    }
}
