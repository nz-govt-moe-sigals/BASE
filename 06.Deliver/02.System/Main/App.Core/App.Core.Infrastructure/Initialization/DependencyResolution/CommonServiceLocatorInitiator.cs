using System.Diagnostics;
using App.Core.Infrastructure.Factories;
using App.Core.Infrastructure.Services;
using Microsoft.Practices.ServiceLocation;

namespace App.Core.Infrastructure.Initialization.DependencyResolution
{
    using TraceLevel = Shared.Models.Entities.TraceLevel;

    // Initiliazes Microsoft's Common ServiceLocator.
    // Invoked during App Startup phase, after StructureMapMvc, 
    // but also when invoking 'add-migration' from the Powershell
    // command line.
    public static class CommonServiceLocatorInitiator
    {
        public static void Initialize()
        {
            // This works because MVC invoked StructuremapMvc.Start, 
            // which invoked StructureMapDependencyScopeFactory to create
            // a container at startup.
            // The trouble with it is that StructuremapMvc.StructureMapDependencyScope
            // is highly dependent on Http context, hence must remain in App.Application
            // and cannot be moved down to a more generally available App.Infrastrucute
            // so that other modules can get to it.
            // The trick is to Add a line to StructuremapMvc (since it is decorated with
            // "Start" and will be invoked by MVC before we get to this) to cache the container
            // in an App specific Static property that this class can get to.

            var container = StructureMapContainerLocator.Container;
            var locator = new StructureMapServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            string whatDidIScan = container.WhatDidIScan();

            // Write to debug so it shows on Console while developing:
            Debug.WriteLine("ServiceLocator Configuration Summary");
            Debug.WriteLine("====================================");
            Debug.WriteLine(whatDidIScan);


            // But I think (todo) the above is to another channel.
            // So write it to the trace so that it ends in diagnostics logs:
            var diagnosticsTracingService = AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>();
            diagnosticsTracingService.Trace(TraceLevel.Verbose, "ServiceLocator Configuration Summary");
            diagnosticsTracingService.Trace(TraceLevel.Verbose, "====================================");
            diagnosticsTracingService.Trace(TraceLevel.Verbose, whatDidIScan);

        }
    }
}