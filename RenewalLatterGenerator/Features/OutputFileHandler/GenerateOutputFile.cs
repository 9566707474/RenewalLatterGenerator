namespace RenewalLatterGenerator.Features.OutputFileHandler
{
    using RenewalLatterGenerator.Common;
    using RenewalLatterGenerator.Models;

    public class GenerateOutputFile
    {
        public CustomerProduct CustomerProduct { get; set; }

        public IFileSystem FileSystem { get; set; }

        public string FilePath { get; set; }

        public void Start()
        {
            FilePath = @"C:\Test\" + CustomerProduct.Id + "_" + CustomerProduct.FirstName + ".txt";

            var invitationTemplate = OutputTemplate.Get;

            foreach (var keyValue in OutputMapping.Columns)
            {
                invitationTemplate = invitationTemplate.Replace(keyValue.Key, GetPropertyValue(CustomerProduct, keyValue.Value).ToString());
            }

            FileSystem.WriteAllText(FilePath, invitationTemplate);
        }

        private static object GetPropertyValue(object source, string propertyName)
        {
            var propertyInfo = source.GetType().GetProperty(propertyName);
            return propertyInfo.GetValue(source, null);
        }
    }
}
