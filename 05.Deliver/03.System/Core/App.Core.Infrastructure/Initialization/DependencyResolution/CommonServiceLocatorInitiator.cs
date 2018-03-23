namespace App.Core.Infrastructure.DependencyResolution
{
    using System.Diagnostics;
    using App.Core.Infrastructure.Factories;
    using Microsoft.Practices.ServiceLocation;

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

            Debug.WriteLine("ServiceLocator Configuration Summary");
            Debug.WriteLine("====================================");
            Debug.WriteLine(container.WhatDidIScan());
        }
    }
}