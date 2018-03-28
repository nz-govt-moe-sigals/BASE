# About #
Filters can be used to intercept calls.


Filters are one of those annoying reminders of the fact that MVC was developed
by one team, and WebAPI was developed by another team (they are 99.99% the same
bar the namespace). So you have to write one filter for MVC, and another 99.99% similar
one for WebAPI. Annoying...


The order of execution is important (especially if you want to ensure that one filter
is invoking DbContext.Commit() and saving everything. So, know that 
a) Filters run in the following sequence:
   AuthorizationFilter, ActionFilter, ResultFilter, ExceptionFilter
b) There is also an execution order you can put on MVC Filters -- but not WebAPI/OData Filters,
   which is slightly annoying :-(
