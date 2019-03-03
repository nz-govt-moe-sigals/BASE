# About #
Filters can be used to intercept calls.


## Two Types of Filters ##
Filters are one of those annoying reminders of the fact that MVC was developed
by one team, and WebAPI was developed by another team (they are 99.99% the same
bar the namespace). So you have to write one filter for MVC, and another 99.99% similar
one for WebAPI. Annoying...



## Global Application of Filters ##

Most Filters are applied globally, from within WebApiFilterConfig amd WebMvcFilterConfig.

The purpose of globally applied Filters include ensuring that:

* all SessionOperations are appropriately Authenticated and Authorized.
* all SessionOperation requests are recorded permanently, along with their outcome (HTTP response code).
* all SesionOperations are timed, so that one can determine which calls are called most frequently, and how long they are taking.
  * note that answers to which operations takes longest can be answered using Odata queries against SessionOperations.


## Order of Execution ##
The order of execution is important (especially if you want to ensure that one filter
is invoking DbContext.Commit() and saving everything. So, know that 
a) Filters run in the following sequence:
   AuthorizationFilter, ActionFilter, ResultFilter, ExceptionFilter
b) There is also an execution order you can put on MVC Filters -- but not WebAPI/OData Filters,
   which is slightly annoying :-(


## Resources ##

Regarding Authorisation:
* https://stackoverflow.com/questions/26464848/custom-authorization-in-asp-net-webapi-what-a-mess
