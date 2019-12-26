namespace RenewalLatterGenerator.Infrastructure
{
    using RenewalLatterGenerator.Features.FileHandlers;

    public interface IFileHandlerResolver
    {
        IFileHandler Resolve(string fileHandlerType);
    }
}
