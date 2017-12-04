Tip: 
Make sure you've read App.Core.Application/Db/README.txt for a general 
idea of how DbContexts, Migrations, Seeding work when combined with IoC/DI.

Tip:
Make sure you've read Db/Migrations/README.txt for Powershell Snippets
to help creating Migrations for a specific DbContext.


How DbContexts and Migrations Work (when using an IoC Container)
================================================================ 
A key concept of implementing Domain Driven Design (DDD) in a Modular manner is the 
term Bounded Concepts: in other words, distinct DbContexts containing discrete Domains
of functionality (Core, Module1, Module2) clearly separated from other Domains/DbContexts
(think Separation of Concerns) -- as oppossed to a single DbContext with every single 
model in there, all mapped to the dbo.xxx schema (fine for small apps, a mess in larger
more apps).

So:
* Multiple DbContexts, all sharing the same ConnectionString, each with different DbSets
(no overlapping) using Ignore<> when needed to stop Models being in two DbContexts.
* Each DbContext gets its own
  * Set of DbModelBuilder fragments (one for each table/model)
  * Set of Db Seeder fragments (one for each table/model)

If you were using Hard wiring, rather than using IoC, to pull everything together it would
be more or less simplly:

public class MyDbContext {
  void MyDbContext("MyAppSettingsConnectionStringName") {...}
  protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    modelBuilder.HasDefaultSchema("MySchemaName");
    AppCoreModelBuilderOrchestrator.Initialize(modelBuilder);
  }
  private void MakeSomeTable (DbModelBuilder) {}
     var order = 1;
    modelBuilder.Entity<DataToken>().HasKey(x => x.Id);
	...etc...
  }
}

It's pretty straight forward. But when you want to achieve a more Loosely Coupled, High Cohesion target
type of coding, you rely on DI, relying on ServiceLocator:


public class MyDbContext {
  void MyDbContext("MyAppSettingsConnectionStringName") {...}
  protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    modelBuilder.HasDefaultSchema("MySchemaName");
	// Use the Service Locator to find all implementations
	// of this Module's DbContext's Model definitions, no matter what
	// assembly there were defined in, and then invoke Define on each one.
    AppDependencyLocator.Current
	  .GetAllInstances<IHasAppCoreDbContextModelBuilderInitializer>()
      .ForEach(x => x.Define(modelBuilder));
  }
}

Aside: 
Why bother? Loose Coupling. Mockable, Testable. SoC.
It also ensures Convention (meeting Contract) over Configururation (hard coding the reference).
In other words, it's a way of meeting ISO-25010 Maintainability, Testability, and Modularity targets.
The cost to you is: get used to using IoC/DI 'magic'...which the more you practice it the more
transparent it becomes, and easier to use. There's a reason to consider using it if Robert C. Martin
recommends the approach (see his book "Clean Code").

The downside, is you have to figure out how to register those 'fragments'.

Notice how the startup happens:

* Owin invokes Startup/StructureMapMvc.cs
* Which creates a Container.
* and teaches it to Scan All Assemblies.
* and teaches it took for other Repositories
* So it looks in App.ModuleXXX.Infrastructure and finds App.ModuleXXX.Initiation.Implementations.ModuleXXXXRepository.
* Where it finds the equivalent of:


   public class AppModule1Registry : Registry {
        public AppModule1Registry() {
            Scan( scan => scan.AddAllTypesOf(typeof(IHasAppModule1DbContextModuleBuilderInitializer));
            Scan( scan => scan.AddAllTypesOf(typeof(IHasAppModule1DbContextSeedInitializer));
        });
	    ...
        }

Which is registering the AppDbContext within the underlying Container. 
Once that was done, the following line in the DbContext could work:


.GetAllInstances<IHasAppCoreDbContextModelBuilderInitializer>()
      .ForEach(x => x.Define(modelBuilder));