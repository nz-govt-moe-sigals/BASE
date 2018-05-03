namespace App.Core.Application
{
    using System;
    using System.Diagnostics;
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
            using (var elapsedTime = new ElapsedTime())
            {
                AppDomain.CurrentDomain.LoadAllBinDirectoryAssemblies();

                // Can't write it out to IConfigurationStepService
                // as IoC is not yet up and running.
                Trace.TraceInformation($"All Assemblies in Bin Directory loaded. Time: {elapsedTime.ElapsedText}.");

            }

        }
    }
}