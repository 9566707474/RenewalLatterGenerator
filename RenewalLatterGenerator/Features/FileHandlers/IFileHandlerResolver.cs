namespace RenewalLatterGenerator.Features.FileHandlers
{
    public interface IFileHandlerResolver
    {
        IFileHandler Resolve(string fileHandlerType);
    }
}
