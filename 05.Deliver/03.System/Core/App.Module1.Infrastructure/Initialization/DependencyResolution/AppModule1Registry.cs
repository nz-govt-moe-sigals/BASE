namespace App.Module1.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.Db.Interception;
    using App.Module1.Infrastructure.Constants.Db;
    using App.Module1.Infrastructure.Db.Context;
    using App.Module1.Infrastructure.Initialization.Db;
    using StructureMap;
    using StructureMap.Graph;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppModule1Registry : Registry
    {
        public AppModule1Registry()
        {
            Scan(
                assemblyScanner =>
                {
                    ScanForThisModulesDbContextTypes(assemblyScanner);
                });

        }

        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanForThisModulesDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            assemblyScanner.AddAllTypesOf<IHasAppModule1DbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppModule1DbContextSeedInitializer>();

            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
            this.RegisterDbContextInHttpContext<AppModule1DbContext>(AppModule1DbContextNames.Module1);
        }
    }
}