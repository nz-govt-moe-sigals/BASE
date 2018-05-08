using App.Module3.Infrastructure.Services;
using App.Module3.Infrastructure.Services.Implementations.Configuration;
using App.Module3.Infrastructure.Services.Implementations.Extract;

namespace App.Module3.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.Db.Interception;
    using App.Module3.Infrastructure.Constants.Db;
    using App.Module3.Infrastructure.Db.Context;
    using App.Module3.Infrastructure.Initialization.Db;
    using StructureMap;
    using StructureMap.Graph;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppModuleInfrastructureRegistry : Registry
    {
        public AppModuleInfrastructureRegistry()
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
            assemblyScanner.AddAllTypesOf<IHasAppModule3DbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppModule3DbContextSeedInitializer>();

            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
            this.RegisterDbContextInHttpContext<AppModule3DbContext>(AppModule3DbContextNames.Module3);
            For<ExtractDocumentDbServiceConfiguration>().Use<ExtractDocumentDbServiceConfiguration>().Singleton();
        }
    }
}