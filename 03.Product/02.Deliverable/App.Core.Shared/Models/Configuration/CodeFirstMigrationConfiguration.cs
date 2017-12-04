namespace App.Core.Shared.Models.Configuration
{
    using App.Core.Shared.Attributes;

    public class CodeFirstMigrationConfiguration
    {
        [Alias("CodeFirst:AttachDebuggerToPSSeeding")]
        public bool CodeFirstAttachDebugger { get; set; }


        [Alias("CodeFirst:SeedIncludeDemoEntries")]
        public bool CodeFirstSeedDemoStuff { get; set; }

    }
}