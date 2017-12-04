IoC in this app works as follows:

When running under a webserver (IIS),
The Owin Pipeline kicks in and finds in App.Core.Infrastructure
the StructuremapMvc class that is decoreated with the Owin PreApplicationStartMethod hook attribute.

This is where it defines the Container, as well as scans assemblies for Registry's (which are more or less Configuration fragments)
which in turn scan all assemblies for matching contracts.

Pay special attention to how it scans, per module, for classes that implement contracts for defining ModelBuilder fragments, 
as well as seeding 'fragments'.

When StructureMap is initialized, it moves on and completes the other Owin Startup classes.

And then finally the starup sequence kicks in to running StructureMapWebApi (again 
based on the Owin Attribute decorations on the class), where it by default sets the
GlobalConfiguration.Configuration.DependencyResolver... 

From there on one can get to Services using DI, or ServiceLocation.

Although ServiceLocation is a mediocre pattern and should be avoided in favour of proper DI, there are still 
cases for it. When needed:

// This approach depends on the MVC framework so is not portable to assemblies below App.xxx.Application
// It also has other issues due to way the Owin pipeline does *not* rely on GlobalConfiguration
// (you need a custom one)
//var x = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ISomeService));

// Alternatively, it's better to rely on a more portable solution
// that can be used across the assemblies.
var x = ServiceLocator.Current.GetService<ISomeService>();


// In general, one should avoid dragging dependencies on 3rd party libraries to other assemblies
// more than is absolutely required. So there is an argument to wrap Microsoft's common ServiceLocator 
// with an App specific ServiceLocator, as I did with AppDependencyLocator....but where we're using 
// it (eg: App.ModuleXXX.Infrastructure), we already have a dependency on EntityFramework 
// and AutoMapper. it's frankly a bit overkill. YMMV (ie, probably a better goal is see if one can 
// refactor to rely on DI/IoC rather than ServiceLocater).

