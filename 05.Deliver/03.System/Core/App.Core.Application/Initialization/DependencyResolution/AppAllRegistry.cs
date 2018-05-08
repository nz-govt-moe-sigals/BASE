

namespace App.Core.Application.Initialization.DependencyResolution
{
    using App.Core.Application.Initialization.OData;
    using App.Core.Infrastructure.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppAllRegistry : Registry
    {
        public AppAllRegistry()
        {


            // Note that we want to register as little from here, and do it mostly
            // from App.XXX.Infrastructure. 
            // The only things that this Application assembly registry should do is 
            // handle types that can't be 'seen' from below (ie, types specific to 
            // UI, like Controllers, and OData stuff.


            // Scan for AllApp 
            Scan(
                assemblyScanner =>
                {
                    //Where we want to be: everywhere. Or else it will 
                    //miss all the other Odata controllers.
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    //Scan all assemblies first:
                    ScanAllModulesForAllModulesDataBuilderTypes(assemblyScanner);

                });

        }


        private void ScanAllModulesForAllModulesDataBuilderTypes(IAssemblyScanner assemblyScanner)
        {
            //TODO: Mystery...when we move the scanning to this assembly (Core.Application)
            // It no longer sees everything.
            //return;

            // Note that because we are in App.Core.Infrastructure, we can't see the
            // Typed version of this interface (as this assembly does not know anything 
            // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
            // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
            // So we search for and register the *untyped* version of the interface:

            //Scan for OData Model Builders in *all* modules.
            assemblyScanner.AddAllTypesOf<IAppOdataModelBuilder>();
            //Scan for OData Model Builder Configuration fragments in *all* modules.
            assemblyScanner.AddAllTypesOf<IAppOdataModelBuilderConfiguration>(); 
            assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilderConfigurationBase>();
        }


        private void ScanForAllModulesODataBuilderTypes(IAssemblyScanner assemblyScanner)
        {
            // Note that because we are in App.Core.Infrastructure, we can't see the
            // Typed version of this interface (as this assembly does not know anything 
            // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
            // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
            // So we search for and register the *untyped* version of the interface:

            //Scan for OData Model Builders in *all* modules.
            assemblyScanner.AddAllTypesOf<IOdataModelBuilderConfigurationBaseStub>();
            //Scan for OData Model Builder Configuration fragments in *all* modules.
            assemblyScanner.AddAllTypesOf<IOdataModelBuilderStub>();
        }





    }
}