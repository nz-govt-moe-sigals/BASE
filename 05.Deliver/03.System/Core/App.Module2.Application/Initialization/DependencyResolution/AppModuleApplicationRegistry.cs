namespace App.Module2.Application.Initialization.DependencyResolution
{
    using App.Module2.Application.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;

    /// <summary>
    /// A StructureMap registry for finding services specific to this assembly.
    /// <para>
    /// Each Module has its two Registries. One at the Application layer
    /// (registering API Controllers), one at the Infrastructure level
    /// (registering Services).
    /// </para>
    /// <para>
    /// Discovered - using Reflection - by 
    /// <see cref="AppAllInfrastructureRegistry"/>
    /// within App.Core.Infrastructure, 
    /// which was directly invoked by the Host's 
    /// startup sequence.
    /// </para>
    /// </summary>
    public class AppModuleApplicationRegistry : Registry
    {
        public AppModuleApplicationRegistry()
        {
            //Scan(
            //    assemblyScanner =>
            //    {
            //        ScanThisModulesForODataModelBuilderTypes(assemblyScanner);
            //    });

        }


        private void ScanThisModulesForODataModelBuilderTypes(IAssemblyScanner assemblyScanner)
        {
            // Note that because we are in App.Core.Infrastructure, we can't see the
            // Typed version of this interface (as this assembly does not know anything 
            // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
            // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
            // So we search for and register the *untyped* version of the interface:

            //Scan for OData Model Builders in *this* modules.
           // assemblyScanner.AddAllTypesOf<IAppModule2OdataModelBuilder>();
            //Scan for OData Model Builder Configuration fragments in *this* modules.
            assemblyScanner.AddAllTypesOf<IAppModule2OdataModelBuilderConfiguration>();
        }

    }
}