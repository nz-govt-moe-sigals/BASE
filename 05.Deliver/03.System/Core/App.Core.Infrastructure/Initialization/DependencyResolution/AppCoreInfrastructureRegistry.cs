namespace App.Core.Infrastructure.DependencyResolution
{
    using System;
    using System.Data.Entity;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Db.Interception;
    using App.Core.Infrastructure.Factories;
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Initialization.Db;
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    //SKYOUT: using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Infrastructure.Integration.Azure.Storage;
    using StructureMap;
    using StructureMap.Configuration.DSL.Expressions;
    using StructureMap.Graph;
    using StructureMap.Web.Pipeline;





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
        //    assemblyScanner.AddAllTypesOf</*SKYOUT: IOdataModelBuilderBase*/ IAppODataModelBuilder>();
        //    //Scan for OData Model Builder Configuration fragments in *all* modules.
        //    assemblyScanner.AddAllTypesOf</*SKYOUT: IOdataModelBuilderConfigurationBase */ IAppODataModelBuilderConfiguration>();
        //}




        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // Register the Db Model definitions and seeder definitions for Core:
            assemblyScanner.AddAllTypesOf<IHasAppCoreDbContextModelBuilderInitializer>();
            assemblyScanner.AddAllTypesOf<IHasAppCoreDbContextSeedInitializer>();

            this.RegisterDbContextInHttpContext<AppCoreDbContext>(AppCoreDbContextNames.Core);
        }



    }
}