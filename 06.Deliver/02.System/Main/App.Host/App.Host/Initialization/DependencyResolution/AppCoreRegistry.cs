

//namespace App.Core.Application.Initialization.DependencyResolution
//{
//    using App.Core.Application.Initialization.OData;
//    using StructureMap;
//    using StructureMap.Graph;

//    // Each Module has its own registry for handling specific cases.
//    // The general registration of Services is handled via the Core
//    // StructureMap Registry (ie, Services, Controllers, etc.)
//    public class AppCoreRegistry : Registry
//    {
//        public AppCoreRegistry()
//        {
//            // Note that we want to register as little from here, and do it mostly
//            // from App.XXX.Infrastructure. 
//            // The only things that this Application assembly registry should do is 
//            // handle types that can't be 'seen' from below (ie, types specific to 
//            // UI, like Controllers, and OData stuff.
//            Scan(
//                assemblyScanner =>
//                {
//                    ScanForAllODataModelBuilder(assemblyScanner);
//                    ScanForAllModulesODataModelBuilderConfigurationTypes(assemblyScanner);
//                });
//        }

//        private void ScanForAllODataModelBuilder(IAssemblyScanner assemblyScanner)
//        {
//            assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilder>();
//        }

//        private void ScanForAllModulesODataModelBuilderConfigurationTypes(IAssemblyScanner assemblyScanner)
//        {
//            assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilderConfiguration>();
//        }


//    }
//}