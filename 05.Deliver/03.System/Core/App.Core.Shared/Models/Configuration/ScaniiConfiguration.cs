namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration to the 
    /// Scanii Service.
    /// </summary>
    public class ScaniiConfiguration
    {
        [Alias("App:Core:Integration:MalwareDetection:Scanii:PingAtStartup")]
        public bool PingAtStartup { get;set; }

        [Alias("App:Core:Integration:MalwareDetection:Scanii:Key")]
        public string Key { get; set; }

        [Alias("App:Core:Integration:MalwareDetection:Scanii:Secret")]
        public string Secret { get; set; }

        [Alias("App:Core:Integration:MalwareDetection:Scanii:BaseUri")]
        public string BaseUri { get; set; }
    }
}