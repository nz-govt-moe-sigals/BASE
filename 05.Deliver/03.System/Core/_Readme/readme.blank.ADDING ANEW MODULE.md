

## In Web.Config ##


* ADD a new one DbInitializer (replacing XX) where expected:

      <context type="App.ModuleXX.Infrastructure.Db.Context.AppModuleXXDbContext, App.ModuleXX.Infrastructure">
        <databaseInitializer type="App.ModuleXX.Infrastructure.Db.Context.AppModuleXXDatabaseInitializer, App.ModuleXX.Infrastructure"/>
      </context>



## In App.ModuleX.Shared ##

* Rename the Module specific interface:

    IHasModuleXX.

This cascades through and makes unique to the Module at least the following key components:

* App.ModuleXX.Infrastructure:
  * AppModuleXXDatabaseInitializer (which CodeFirst relies upon, and WebConfig is referencing above)
* App.ModuleXX.Application
  * the base OData Controller.