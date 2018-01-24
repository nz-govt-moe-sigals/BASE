namespace App.Core.Application
{
    using App.Core.Application.App_Start;
    using Owin;

    public class Startup
    {
        // The OWIN middleware will invoke this method when the app starts
        // because it's called Configuration, within a class called Startup
        // within the Assembly's default namespace.
        // Or you can use [assembly: OwinStartup(typeof(StartupDemo.TestStartup))]
        // within AssemblyInfo.cs
        // See: https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-startup-class-detection
        // IMPORTANT: Also, requires  Microsoft.Owin.Host.SystemWeb.dll or else won't be invoked.
        public void Configuration(IAppBuilder appBuilder)
        {
            //Sometimes Required: LoadAllAssembliesConfig.Configure(appBuilder);

            // SETUP STEP: Initialize Common ServiceLocator, early (after ensuring it will find all assemblies):
            ServiceLocatorConfig.Configure(appBuilder);

            // Now that we have Service Location,
            // Use Service Locator to build injection right from the start:
            AppDependencyLocator.Current.GetInstance<StartupExtended>().Configure(appBuilder);

        }
    }
}