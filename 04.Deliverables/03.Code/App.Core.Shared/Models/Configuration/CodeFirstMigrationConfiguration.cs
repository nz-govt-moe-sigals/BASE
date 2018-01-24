namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the configuration of 
    /// EF CodeFirst.
    /// </summary>
    public class CodeFirstMigrationConfiguration
    {
        [Alias("App:Core:CodeFirst:AttachDebuggerToPSSeeding")]
        public bool CodeFirstAttachDebugger { get; set; }


        [Alias("App:Core:CodeFirst:SeedIncludeDemoEntries")]
        public bool CodeFirstSeedDemoStuff { get; set; }

    }
}