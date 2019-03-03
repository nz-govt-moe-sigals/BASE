using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services.Configuration.Implementations.AppHostNames;

namespace App.Core.Infrastructure.DependencyResolution
{
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Context.Default;
    using App.Core.Infrastructure.Initialization.Db;
    //SKYOUT: using App.Core.Infrastructure.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;





    /// <summary>
    /// The App Core Module's StructureMap Registry.
    /// <para>
    /// Discovered by <see cref="AppAllInfrastructureRegistry"/>
    /// </para>
    /// </summary>
    /// <seealso cref="StructureMap.Registry" />
    public class AppCoreInfrastructureRegistry : Registry
    {
        public AppCoreInfrastructureRegistry()
        {
            Scan(
                assemblyScanner =>
                {
                    //Where we want to be:
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    // Specific to this Module:
                    ScanAllModulesForModuleSpecificDbContextTypes(assemblyScanner);

                });
        }


        //SKYOUT: private void ScanAllModulesForModuleSpecificODataBuilderTypes(IAssemblyScanner assemblyScanner)
        //{
        //    // Note that because we are in App.Core.Infrastructure, we can't see the
        //    // Typed version of this interface (as this assembly does not know anything 
        //    // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
        //    // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
        //    // So we search for and register the *untyped* version of the interface:

        //    //Scan for OData Model Builders in *all* modules.
        //    assemblyScanner.AddAllTypesOf<IAppODataModelBuilder>();
        //    //Scan for OData Model Builder Configuration fragments in *all* modules.
        //    assemblyScanner.AddAllTypesOf<IAppODataModelBuilderConfiguration>();
        //}




        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            assemblyScanner.AddAllTypesOf<IHasAppModuleDbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppModuleDbContextSeedInitializer>();

            this.RegisterDbContextInHttpContext<AppCoreDbContext>(AppCoreDbContextNames.Core);
            For<HostSectionConfigurationManager>().Use<HostSectionConfigurationManager>().Singleton();
        }



    }
}