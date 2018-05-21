
Appears that StructureMap is Idempotent in that if it registeres InstanceTypeA
against InterfaceTypeA, you can't *also* register it under InterfaceTypeB. 

Ref:
http://structuremap.github.io/the-container/forwarding-requests-for-a-type-to-another-type/
https://stackoverflow.com/questions/2363458/structuremap-singleton-usage-a-class-implementing-two-interface/2366838#2366838

That has taken me by surprise -- and has led to less than stellar hacks to get around it.

It's why the following *module-specific* classes inherit from a *module-specific* *typed* interface
that inherit from a *module-specific* *un-typed* interface that inherits from a *global* *un-typed* 
interface (ugh!)

The reasoning is as follows:

* All Modules have a Reference to App.Core.Interface, where the *global*, *untyped* interface is defined.
   * ie, all other assemblies can reference it, including:
     * their App.XXX.Application where Module-specific OData ModelBuiler classes are defined, and
	 * their App.XXXInfrastructure where Module-specific DbContext model builder classes are defined,
   * In the case of working with OData (as oppossed to DbContext) the interface has to define an 
     untyped argument (eg: Initialize(object foo)) because its in the Infrastructure assembly, which is 'too low
	 in the stack', and the assembly has no referenceds to assemblies that are about UX/Controllers/Apis/OData 
	 (WARNING: and MUST remain ignorant of theses concerns, so don't add a ref just for this!!!)
   * Due to it's location in App.Core.Infrastructure, these base classes can be referenced at startup from the 
     App.Core.Infrastructure.Initialization.DependencyResolution AppCoreRegistry (ie, they're basically right
	 beside each other), so it's trivial to 

	 assemblyScanner.AddAllTypesOf<IOdataModelBuilderBase>();

   * The net result is that if if you want to register all the implementations of the contract needed for
     making one big OData model, all you have to do is something akin to:
	 assemblyScanner => assemblyScanner.

	 assemblyScanner.AddAllTypesOf<IOdataModelBuilderBase>();

There are two downsides to the above:

* in the case of OData classes, they're untyped.  which is a bit of bug waiting to happen (typing rules...).
* the pattern is fine if you wanto make one big model combining elements across Modules.
    You may want this. You may not.

What's needed is some Modulespecific typing:

* IODataModelBuilderBase <- common untyped base
  * App.ModuleX.Infrastructure.IAppMoudleXModelBuilderBase <- a module specific untyped base.
    * App.ModuleX.Application.IAppModuleXModelBuilder <- a module specific *typed* inteface, as it's now in 
	  in an Application assembly that does know about OData...
	  * Finally, you're instance.

Messy...But should work if you

a) 	 assemblyScanner.AddAllTypesOf<IOdataModelBuilderBase>();
b) 	 In each module do:
     assemblyScanner.AddAllTypesOf<IAppModuleXModelBuilderBase>();


It should work...but doesn't. Due to StructureMap's idempotency.
Since you registered one first, you'll get back:
AppDependencyLocator.Current.GetInstances<IOdataModelBuilderBase>().Count() ...some number larger than zero...good.
AppDependencyLocator.Current.GetInstances<IAppModuleXModelBuilderBase>().Count() ...zero! (what?!?).


So you can go ahead and Fiddle around StructureMap's For statement:

For<IAppModuleXModelBuilderBase>().Use(ctx => ctx.GetInstance<IOdataModelBuilderBase>());

But that's just for one type...I still haven't figured out how to to do the same gracefully for all implementations.

So...for now...I'm doing

var tx = AppDependencyLocator.Current
  .GetAllInstances<IOdataModelBuilderConfigurationBase>()
  .Where(x=>x is IAppModuleODataModelBuilderConfiguration);
var c3 = tx.Count(); //Yay (Finally)

It's a bit of a mind-mess. But I'm open to better solutions.
