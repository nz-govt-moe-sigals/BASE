namespace App.Module02.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.Db.Interception;
    using App.Module02.Infrastructure.Constants.Db;
    using App.Module02.Infrastructure.Db.Context;
    using App.Module02.Infrastructure.Initialization.Db;
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
    /// <seealso cref="StructureMap.Registry" />
    public class AppModuleInfrastructureRegistry : Registry
    {
        public AppModuleInfrastructureRegistry()
        {
            Scan(
                assemblyScanner =>
                {
                    //Where we want to be:
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    ScanAllModulesForModuleSpecificDbContextTypes(assemblyScanner);
                });

        }

        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            assemblyScanner.AddAllTypesOf<IHasAppModuleDbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppModuleDbContextSeedInitializer>();

            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
            this.RegisterDbContextInHttpContext<AppModuleDbContext>(AppModuleDbContextNames.Default);
        }
    }
}

