namespace App.Core.Infrastructure.Initialization.DependencyResolution
{
    using App.Core.Infrastructure.DependencyResolution;

    // This is totally a hack to do with limitations of 
    // CodeFirst for EF6. 
    // It is an alternate StructureMap initializer
    // to the Owin startup sequence, that only comes
    // into play when invoking the Powershell add-migration
    // and update-database commands.
    public class PowershellServiceLocatorConfig
    {
        /// <summary>
        ///     Whether Configure has been invoked.
        /// </summary>
        public static bool Initialized { get; private set; }

        /// <summary>
        ///     Am using the 'lite' structuremap solution
        ///     that is only activated when running under
        ///     powershell ('add-migration' and 'update-database')
        /// </summary>
        public static bool Activated { get; private set; }

        // The reason for this is that, under normal run 
        // conditions, the Exe entry point is IIS, and therefore
        // goes through OWIN, and from there finds StructureMapMvc
        // and it invokes IoC.Initialize.

        // But when running under Powershell, the entry point is some
        // Exe, that knows nothing about Owin, or even the MVC startup.
        // So it doesn't get to StructureMapMvc. 
        // Therefore the DI/IoC container is not available.
        // Therefore most of the code falls apart with the powershell
        // scripts saying it could not instantiate classes that don't 
        // have argumentless constructors.

        // The only good side is that for getting through add-migration
        // and update-database we need the IoC container, but don't need
        // any fancy scope. So it's really a couple of lines (as shown 
        // below.

        // There's one last bad news. 
        // This solution works. At least for add-database (it will 
        // find all Database Models and ModelBuilder 'fragments').
        // But the 'update-database' which invokes the seeders must
        // run on a different underlying exe that just can't find the App-Domain
        // (when using the -AppDomainBaseDirectory switch on the 
        // update-database method).
        // Hence the Switch
        public static void Initialize()
        {
            if (Initialized)
            {
                return;
            }

            if (StructureMapContainerLocator.Container != null)
            {
                return;
            }
            var container = IoC.Initialize();

            StructureMapContainerLocator.Register(() => container);
            CommonServiceLocatorInitiator.Initialize();

            Initialized = true;
        }
    }
}