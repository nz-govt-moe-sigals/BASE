using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services;
using App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using App.Core.Infrastructure.Services.Implementations;
using App.Core.Infrastructure.Services.Implementations.AzureServices;
using StructureMap.Web;

namespace App.Core.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.Cache;
    using App.Core.Infrastructure.Db.Interception;
    using App.Core.Infrastructure.DependencyResolution;
    using App.Core.Infrastructure.Initialization.Authentication;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Infrastructure.Integration.Azure.Storage;
    using StructureMap;
    using StructureMap.Configuration.DSL.Expressions;
    using StructureMap.Graph;
    using StructureMap.Web.Pipeline;

    public class AppAllInfrastructureRegistry : Registry
    {
        public AppAllInfrastructureRegistry()
        {
            Scan(
                assemblyScanner =>
                {

                    //Where we want to be:
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    //This ensures it looks for additional Registries beyond this
                    // Core one. In other words, it will scan all known assemblies 
                    // (as per first line) for Module specific Registries. Such 
                    // as AppModuleRegistry.
                    assemblyScanner.LookForRegistries();

                    ScanAllModulesForAllModulesAutoMapperInitializers(assemblyScanner);
                    ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(assemblyScanner);

                    ScanAllModulesForAllModulesPrecommitStrategies(assemblyScanner);

                    ScanAllModulesAndRegisterNamedInstancesOfStorageAccountContexts(assemblyScanner);

                    ScanAllModulesAndRegisterNamedInstancesOfNamedCacheInitializers(assemblyScanner);
                    InfrastructureCoreMappings(assemblyScanner);
                    // Scan across all known assemblies for Services, Factories, etc.
                    // That meet ISomething => Something naming convention:
                    assemblyScanner.WithDefaultConventions();

                    // As well as the default scanner, find any custom scanners 
                    // (eg: our custom MVC5 Controller scanner) and use them as well :
                    AppDomain.CurrentDomain
                        .InvokeImplementing<ICustomRegistrationConvention>(assemblyScanner.With);
                }
            );


        }

        private void InfrastructureCoreMappings(IAssemblyScanner assemblyScanner)
        {
            For<IAzureRedisConnection>().Use<AzureRedisConnection>().Singleton();
            For<AzureRedisCacheServiceConfiguration>().Use<AzureRedisCacheServiceConfiguration>().Singleton();
            For<ISessionManagmentService>().Use<SessionManagmentService>().Singleton();
        }


        private void ScanAllModulesForAllModulesAutoMapperInitializers(IAssemblyScanner assemblyScanner)
        {
            // Register all Automapper Instances, which ever assembly they are in :
            assemblyScanner.AddAllTypesOf<IHasAutomapperInitializer>();
        }

        private void ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IHasOidcScopeInitializer>();
        }


        private void ScanAllModulesForAllModulesPrecommitStrategies(IAssemblyScanner assemblyScanner)
        {
            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
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


        private void ScanAllModulesAndRegisterNamedInstancesOfStorageAccountContexts(IAssemblyScanner assemblyScanner)
        {
            var types = AppDomain.CurrentDomain.GetInstantiableTypesImplementing<IAzureStorageBlobContext>();
            foreach (Type t in types)
            {
                string name = t.GetName(false);

                if (name == null)
                {
                    throw new Exception("Coding error: StorageAccountContexts need to be Named, using a KeyAttribute.");
                }

                //Register it under IAzureStorageBlobContext context, but named:

                new CreatePluginFamilyExpression<IAzureStorageBlobContext>(this,
                        new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped()
                    .Use(y => (IAzureStorageBlobContext)AppDependencyLocator.Current.GetInstance(t)).Named(name);
            }
        }


        private void ScanAllModulesAndRegisterNamedInstancesOfNamedCacheInitializers(IAssemblyScanner assemblyScanner)
        {

            var types = AppDomain.CurrentDomain.GetInstantiableTypesImplementing<IAppCoreCacheItem>();

            foreach (Type t in types)
            {
                //Get the item's KeyAttribute:
                string name = t.GetName(false);

                if (name == null)
                {
                    throw new DevelopmentException($"Implementations of IAppCoreCacheItem (ie {t.Name}) need to be Named, using a KeyAttribute.");
                }

                new CreatePluginFamilyExpression<IAppCoreCacheItem>(this,
                                    new StructureMap.Pipeline.SingletonLifecycle())
                                    .Use(y => (IAppCoreCacheItem)AppDependencyLocator.Current.GetInstance(t)).Named(name);
            }
        }



    }
}
