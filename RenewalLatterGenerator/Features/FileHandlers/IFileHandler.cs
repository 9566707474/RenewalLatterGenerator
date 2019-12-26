namespace RenewalLatterGenerator.Features.FileHandlers
{
    using RenewalLatterGenerator.Models;
    using System.Collections.Generic;

    public interface IFileHandler
    {
        string Type { get; }

        ICollection<CustomerProduct> ReadFile(string filePath);
    }
}
