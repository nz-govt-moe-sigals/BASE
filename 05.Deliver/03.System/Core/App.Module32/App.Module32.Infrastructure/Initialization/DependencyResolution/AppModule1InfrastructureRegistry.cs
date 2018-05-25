namespace App.Module1.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.Db.Interception;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Module1.Infrastructure.Constants.Db;
    using App.Module1.Infrastructure.Db.Context;
    using App.Module1.Infrastructure.Initialization.Db;
    //SKYOUT: using App.Module1.Infrastructure.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;

    /// <summary>
    /// <para>
    /// Each Module has its own registry for handling specific cases.
    /// The general registration of Services is handled via the Core
    /// StructureMap Registry (ie, Services, Controllers, etc.)    
    /// </para>
    /// <para>
    /// Discovered by <see cref="AppAllInfrastructureRegistry"/>
    /// </para>
    /// </summary>
    public class AppModule1InfrastructureRegistry : Registry
    {
        public AppModule1InfrastructureRegistry()
        {
            Scan(
                assemblyScanner =>
                {
                    ScanAllModulesForModuleSpecificDbContextTypes(assemblyScanner);
                });

        }

        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
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

