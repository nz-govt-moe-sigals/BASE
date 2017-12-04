namespace App.Core.Infrastructure.DependencyResolution
{
    using System;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Interception;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Authentication;
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
                scan =>
                {
                    //Where we want to be:
                    scan.AssembliesFromApplicationBaseDirectory();

                    //This ensures it looks for additional Registries beyond this
                    // Core one. In other words, it will scan all known assemblies 
                    // (as per first line) for Module specific Registries. Such 
                    // as AppModule1Registry.
                    scan.LookForRegistries();

                    // Scan across all known assemblies for Automapper related maps:
                    ScanAndPrepareAutoMapper(scan);

                    //Scan across Modules for OIDC Scope Definitions.
                    ScanForOIDCFullyQualifiedScopes(scan);

                    // Scan across all known assemblies for DbContext related model definitions
                    // And seeding definitions, and define the DbContext lifespan:
                    ScanAndPrepareDbContextForThisModule(scan);

                    ScanForODataModelBuilderFragments(scan);

                    // Scan across all known assemblies for Services, Factories, etc.
                    // That meet ISomething => Something naming convention:
                    scan.WithDefaultConventions();
                    // As well as the default scanner, find any custom scanners 
                    // (eg: our custom MVC5 Controller scanner) and use them as well :
                    AppDomain.CurrentDomain
                        .InvokeImplementing<ICustomRegistrationConvention>(scan.With);
                });
        }

        private void ScanAndPrepareAutoMapper(IAssemblyScanner scan)
        {
            // Register all Automapper Instances, which ever assembly they are in :
            scan.AddAllTypesOf<IHasAutomapperInitializer>();


            // This makes it relatively easy to instantiate and invoke a set of them using container:

            // AppServiceLocation
            //  .ServiceLocator.Current
            //  .GetAllInstances<IHasAutomapperInitializer>()
            //  .ForEach(x => x.Initialize(null));
        }

        private void ScanForOIDCFullyQualifiedScopes(IAssemblyScanner scan)
        {
            scan.AddAllTypesOf<IHasOidcScopeInitializer>();
        }

        private void ScanAndPrepareDbContextForThisModule(IAssemblyScanner scan)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            AppCoreServiceLocatorInitializer.ScanForCoreInitializers()
                .ForEach(x => scan.AddAllTypesOf(x));

            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            scan.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();

            // This makes it relatively easy to instantiate and invoke a set of them using container:
            //  AppServiceLocator.Current
            //  .GetAllInstances<IHasAppCoreDbContextModelBuilderInitializer>()
            //  .ForEach(x => x.Initialize(null));


            this.RegisterDbContextInHttpContext<AppCoreDbContext>(AppCoreDbContextNames.Core);
            //For<AppCoreDbContext>()
            //    //.Transient
            //    //.ChildContainerSingletonLifecycle
            //    //.UniquePerRequestLifecycle
            //    .HttpContextLifecycle
            //    //.UniquePerRequestLifecycle
            //    //.LifecycleIs(new ChildContainerSingletonLifecycle())
            //    //.LifecycleIs(new UniquePerRequestLifecycle())
            //    .Use(y => new AppCoreDbContext());
        }

        private void ScanForODataModelBuilderFragments(IAssemblyScanner scan)
        {
            scan.AddAllTypesOf<IOdataModelBuilderConfigurationBase>();
        }

    }
}