namespace RenewalLatterGenerator.Common
{
    public interface IFileSystem
    {
        string ReadAllText(string filePath);

        bool FileExists(string filePath);

        void CreateFile(string filePath);

        void WriteAllText(string filePath, string content);
    }
}
