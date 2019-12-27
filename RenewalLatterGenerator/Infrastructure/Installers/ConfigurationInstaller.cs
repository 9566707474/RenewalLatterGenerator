namespace RenewalLatterGenerator.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using RenewalLatterGenerator.Common;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ConfigurationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IConfigurationManagerFacade>()
               .ImplementedBy<ConfigurationManagerFacade>().LifestyleSingleton());
        }
    }
}
