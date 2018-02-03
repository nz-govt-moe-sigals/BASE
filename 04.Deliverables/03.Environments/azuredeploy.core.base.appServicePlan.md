# Synopsis #

App Services are deployed within a target App Service Plan -- which is a Server Rack sizing/location definition.
It controls billing.


## Key Issues ##

* Does not invoke child resources.
* Inputs/outputs:
  * Inputs:
    * Location. Note that the Location is where the ASP definition is saved. Does not define where it's servers are saved.
    * SKU



## Resources ##

* https://docs.microsoft.com/en-us/azure/templates/microsoft.web/serverfarms