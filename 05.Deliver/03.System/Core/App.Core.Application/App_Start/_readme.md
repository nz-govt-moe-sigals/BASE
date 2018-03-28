# About #

ASP.MVC apps are bootstrapped from the root directory's Startup.cs.

Which in turn invokes:

* ServiceLocatorConfig in this App_Start directory

and when Service Location is initialized, invokes

* StartupExtended.cs in the root directory. 

That's where the 'real' startup begins, as we now have Dependency Injection to work with
and things get simpler.

# Design Considerations #

* Startup Sequence can configure, but not access remote services:
  It's essential that the startup sequence does not hit the database 
  or any other integration service than it absolutely must. 
  Reasons include but are not limited to: 
  * Slower startup(not all pages need all integration services)
  * You want at least some pages(eg: installation walkthroughs, 
    health check landing pages, etc.) to be accessible without 
    hitting services that might crash pages.

# Routing of Static Resources #

By default ASP.NET does not manage static files -- until (RAMMFAR) 
`configuration/system.webServer/modules@runAllManagedModulesForAllRequests="false"`
is set in the config file (`true` is the default in this app, but this hamper debugging 
of the first install.)

