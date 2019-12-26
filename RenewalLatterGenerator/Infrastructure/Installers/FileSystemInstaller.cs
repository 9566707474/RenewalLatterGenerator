namespace RenewalLatterGenerator.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using RenewalLatterGenerator.Common;

    public class FileSystemInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFileSystem>()
                .ImplementedBy<FileSystem>());
        }
    }
}
