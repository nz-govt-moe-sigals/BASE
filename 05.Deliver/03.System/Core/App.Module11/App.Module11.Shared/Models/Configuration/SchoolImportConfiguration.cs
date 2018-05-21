namespace App.Module11.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class SchoolImportConfiguration
    {
        [Alias("App.Module11-SchoolImportSourcePath")]
        public string CsvSourcePath { get; set; }
    }
}





