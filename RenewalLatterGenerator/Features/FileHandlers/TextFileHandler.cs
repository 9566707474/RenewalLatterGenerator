namespace RenewalLatterGenerator.Features.FileHandlers
{
    using System.Collections.Generic;
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Models;

    public class TextFileHandler : IFileHandler
    {
        public TextFileHandler()
        {
            Type = FileTypes.Text;
        }

        public string Type { get; private set; }
        
        public ICollection<CustomerProduct> ReadFile(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
