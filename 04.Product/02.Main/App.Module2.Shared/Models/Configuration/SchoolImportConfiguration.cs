namespace App.Module2.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class SchoolImportConfiguration
    {
        [Alias("SchoolImportSourcePath")]
        public string CsvSourcePath { get; set; }
    }
}