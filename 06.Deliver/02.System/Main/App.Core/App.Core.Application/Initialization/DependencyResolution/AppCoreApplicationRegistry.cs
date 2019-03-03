

using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Core.Application.Initialization.DependencyResolution
{
    using App.Core.Application.Initialization.OData;
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

    public class AppCoreApplicationRegistry : Registry
    {
        public AppCoreApplicationRegistry()
        {
            // Note that we want to register as little from here, and do it mostly
            // from App.XXX.Infrastructure. 
            // The only things that this Application assembly registry should do is 
            // handle types that can't be 'seen' from below (ie, types specific to 
            // UI, like Controllers, and OData stuff.


            // Scan for this Module Only:
            Scan(
                assemblyScanner =>
                {
                    assemblyScanner.AssembliesFromApplicationBaseDirectory();

                    ScanAllModulesForModuleSpecificODataModelBuilderConfigurationTypes(assemblyScanner);
                });
        }



        private void ScanAllModulesForModuleSpecificODataModelBuilderConfigurationTypes(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilderConfiguration>();
        }


    }
}