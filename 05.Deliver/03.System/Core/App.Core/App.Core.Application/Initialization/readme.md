# About #

The Shell's Startup sequence ends up invoking
the Core Module's AppAllInfruastructureRegistry.cs (within
App.Core.Infrastructure/Initialization/DependencyResolution).

Among other tasks, the Registry is configured to scan the 
Bin directory for all other Registries. 

This means it finds -- by Reflection -- at least two Registries per Module:

* App.ModuleX.Application (doesn't do anything at present)
* App.ModuleX.Infrastructure (used to register Module specific Services, Factories, etc.)
etc.

The order in which they are invoked is not important -- they're just registering
Instance Types against Contract Types.

Within Core there's also two more Registries:

* App.Core.Application/.../AppAllApplicationRegistry (used to register *all* API Controllers)
* App.Core.Infrastructure/.../AppAllInfrastructureRegistry (used to register common Services, Factories, etc.)


## Tips ##

Registrys have their own tricks of the trade.

* By default a Registry seems to scan only assemblies it knows about. So if you want to scan all assemblies,
make sure to configure it first: `assemblyScanner.AssembliesFromApplicationBaseDirectory();`
* If a class inherits from IFoo which inherits from IBoo, you won't be able to invoke it using IBoo, unless you register it under IBoo.


