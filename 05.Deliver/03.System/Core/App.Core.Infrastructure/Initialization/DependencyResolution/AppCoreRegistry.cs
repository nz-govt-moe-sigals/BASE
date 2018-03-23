namespace App.Core.Infrastructure.DependencyResolution
{
    using System;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Interception;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Infrastructure.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;

    // The App Core Module's StructureMap Registry.
    // Invoked via StructuremapMvc which is invoked
    // during startup.
    public class AppCoreRegistry : Registry
    {
        public AppCoreRegistry()
        {
            Scan(
                assemblyScanner =>
                {
                    //Where we want to be:
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    //This ensures it looks for additional Registries beyond this
                    // Core one. In other words, it will scan all known assemblies 
                    // (as per first line) for Module specific Registries. Such 
                    // as AppModule1Registry.
                    assemblyScanner.LookForRegistries();

                    // Common across all Modules:
                    ScanForAllModulesAutoMapperInitializers(assemblyScanner);
                    ScanForAllModulesOIDCFullyQualifiesScopes(assemblyScanner);
                    ScanForAllModulesODataBuilderTypes(assemblyScanner);
                    ScanForAllModulesDbContextTypes(assemblyScanner);

                    // Specific to this Module:
                    ScanForThisModulesDbContextTypes(assemblyScanner);

                    // Scan across all known assemblies for Services, Factories, etc.
                    // That meet ISomething => Something naming convention:
                    assemblyScanner.WithDefaultConventions();

                    // As well as the default scanner, find any custom scanners 
                    // (eg: our custom MVC5 Controller scanner) and use them as well :
                    AppDomain.CurrentDomain
                        .InvokeImplementing<ICustomRegistrationConvention>(assemblyScanner.With);
                });
        }

        private void ScanForAllModulesAutoMapperInitializers(IAssemblyScanner assemblyScanner)
        {
            // Register all Automapper Instances, which ever assembly they are in :
            assemblyScanner.AddAllTypesOf<IHasAutomapperInitializer>();
        }

        private void ScanForAllModulesOIDCFullyQualifiesScopes(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IHasOidcScopeInitializer>();
        }
        private void ScanForAllModulesDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
        }




        private void ScanForAllModulesODataBuilderTypes(IAssemblyScanner assemblyScanner)
        {
            // Note that because we are in App.Core.Infrastructure, we can't see the
            // Typed version of this interface (as this assembly does not know anything 
            // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
            // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
            // So we search for and register the *untyped* version of the interface:

            //Scan for OData Model Builders in *all* modules.
            assemblyScanner.AddAllTypesOf<IOdataModelBuilderBase>();
            //Scan for OData Model Builder Configuration fragments in *all* modules.
            assemblyScanner.AddAllTypesOf<IOdataModelBuilderConfigurationBase>();
        }



        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanForThisModulesDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            assemblyScanner.AddAllTypesOf<IHasAppCoreDbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppCoreDbContextSeedInitializer>();

            this.RegisterDbContextInHttpContext<AppCoreDbContext>(AppCoreDbContextNames.Core);
        }



    }
}