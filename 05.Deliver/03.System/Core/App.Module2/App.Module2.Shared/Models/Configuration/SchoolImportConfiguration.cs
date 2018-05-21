namespace App.Module02.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class SchoolImportConfiguration
    {
        [Alias("App-Module02-SchoolImportSourcePath")]
        public string CsvSourcePath { get; set; }
    }
}