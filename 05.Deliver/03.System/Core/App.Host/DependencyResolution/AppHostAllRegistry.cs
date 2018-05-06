namespace App.Core.Application.Initialization.DependencyResolution
{
    using App.Core.Application.Initialization.OData;
    using StructureMap;
    using StructureMap.Graph;

    // Each Module has its own registry for handling specific cases.
    // The general registration of Services is handled via the Core
    // StructureMap Registry (ie, Services, Controllers, etc.)
    public class AppHostAllRegistry : Registry
    {
        public AppHostAllRegistry()
        {
            //Scan(
            //    assemblyScanner =>
            //    {
            //        //ScanThisModulesForODataModelBuilderTypes(assemblyScanner);
            //    });

        }


        //private void ScanThisModulesForODataModelBuilderTypes(IAssemblyScanner assemblyScanner)
        //{
        //    //Scan for OData Model Builders in *this* modules.
        //    assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilder>();
        //    //Scan for OData Model Builder Configuration fragments in *this* modules.
        //    assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilderConfiguration>();
        //}

    }
}