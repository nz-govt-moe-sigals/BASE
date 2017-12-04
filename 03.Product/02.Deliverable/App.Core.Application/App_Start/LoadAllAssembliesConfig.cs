namespace App.Core.Application
{
    using System;
    using Owin;

    public class LoadAllAssembliesConfig
    {
        // Must be invoked before ServiceLocatorConfig is invoked.
        public static void Configure(IAppBuilder appBuilder)
        {
            AppDomain.CurrentDomain.LoadAllBinDirectoryAssemblies();
        }
    }
}