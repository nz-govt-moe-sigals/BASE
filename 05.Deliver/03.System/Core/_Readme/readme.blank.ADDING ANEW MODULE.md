

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


## In App.ModuleX.Infrastructure ##

Update the Constant that defines the name of the Mdoule.


namespace App.ModuleXX.Infrastructure.Constants.Module
{
    public static class Names
    {
        public const string ModuleKey = "ModuleXX";
    }
}

This name will end up being the name of the Db Schema, unless you overrride it (but why would you?):

    ...
    public const string SchemaKey = Constants.Module.Names.ModuleKey;
	...



After renaming a Module

App.ModuleXX.Application/Constants/Api/ApiControllerName.cs
* Add Controller Names.


Need to hook App.Host to App.ModuleXX.Application

* Need a Clean (as App.Host bin has copies of older dlls referencing each other differently. Have to clear out, or you'll have ghosts).


