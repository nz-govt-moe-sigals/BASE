namespace App.Core.Application
{
    using System;
    using Owin;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to 
    /// load all Assemblies found in the system's Bin directory
    /// into the curent Domain.
    /// <para>
    /// This faciliates subsequent finding of services and 
    /// dependencies by the IoC / StructureMap.
    /// </para>
    /// </summary>
    public class LoadAllAssembliesConfig
    {
        // IMPORTANT: Must be invoked before ServiceLocatorConfig is invoked.        

        /// <summary>
        /// Configures the specified application builder.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void Configure(IAppBuilder appBuilder)
        {
            AppDomain.CurrentDomain.LoadAllBinDirectoryAssemblies();
        }
    }
}