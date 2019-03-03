using StructureMap;

namespace App.Core.Infrastructure.Initialization.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            // SETUP STEP: Ensure you reroute to a new Registry
            // so that you don't loose your Settings, when you reinstall
            // a new version of the Nuget packages (which will overwrite
            // the DefaultRegistry...and loose all your Bindings)
            return new Container(
                c => c.AddRegistry<AppAllInfrastructureRegistry>()
            );
        }
    }
}