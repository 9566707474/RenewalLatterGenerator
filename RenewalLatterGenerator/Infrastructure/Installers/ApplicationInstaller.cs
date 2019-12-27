namespace RenewalLatterGenerator.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using RenewalLatterGenerator.Features;
    using RenewalLatterGenerator.Features.DataExtractor;
    using RenewalLatterGenerator.Features.FileHandlers;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ApplicationInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProcessEngine>().ImplementedBy<ProcessEngine>(),
            Component.For<IDataExtractor>().ImplementedBy<DataExtractor>(),
            Component.For<IFileHandlerResolver>().ImplementedBy<FileHandlerResolver>(),
            Classes.FromThisAssembly().IncludeNonPublicTypes().BasedOn<IFileHandler>()
           .WithService.FromInterface());

            var collectionResolver = new CollectionResolver(container.Kernel);
            container.Kernel.Resolver.AddSubResolver(collectionResolver);

        }
    }
}
