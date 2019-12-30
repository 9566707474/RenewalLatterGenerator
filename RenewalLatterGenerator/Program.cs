namespace RenewalLatterGenerator
{
    using Castle.Windsor;
    using RenewalLatterGenerator.Features;
    using RenewalLatterGenerator.Infrastructure;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = new WindsorContainer();
            WindsorConfig.Install(container);

            var processEngine = container.Resolve<IProcessEngine>();
            processEngine.Start();
        }
    }
}
