namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class ScaniiConfiguration
    {
        [Alias("Scanii:Key")]
        public string Key { get; set; }

        [Alias("Scanii:Secret")]
        public string Secret { get; set; }

        [Alias("Scanii:BaseUri")]
        public string BaseUri { get; set; }
    }
}