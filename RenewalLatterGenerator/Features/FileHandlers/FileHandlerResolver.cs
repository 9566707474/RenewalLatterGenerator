namespace RenewalLatterGenerator.Features.FileHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FileHandlerResolver : IFileHandlerResolver
    {
        private readonly IEnumerable<IFileHandler> fileHandler;

        public FileHandlerResolver(IEnumerable<IFileHandler> fileHandler)
        {
            this.fileHandler = fileHandler;
        }

        public IFileHandler Resolve(string fileType)
        {
            var fileHandler = this.fileHandler.FirstOrDefault(item => item.Type == fileType);

            if (fileHandler == null)
            {
                throw new ArgumentException("File handler not found", fileType);
            }
            return fileHandler;
        }
    }
}
