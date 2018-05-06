# About #

This is Server Code. As such, does not contain any Client code. 
The Client code, developed using Angular, is kept in a separate 
repository.

The reasons include:

* Allows to outsource the front end development to a different, 
  user interface specialised interface, bound only to the contracts
  of the services provided by this code base.
* Front end development changes at a higher pace than server code.
  Whereas the APIs will use the same technology for years, 
  and the functionality will remain consistent for a long time once 
  the original churn is over, the front end development technologies
  change at a much faster clip. It's best to be able to leave the 
  server code running, while cutting a new interface as needed.