# About #


## Security ##
A common strategy to ensure that all methods of all set of classes (eg: Controllers) are secured 
by default (relaxed as needed), is to use AOC to scan a namespace and Intercept class creation, wrapping the classes
with a proxy. 
That is appropriate if the security is applied on the Application Service.

If the app logic is to run outside of a web host that might be applicable. But it adds complexity.

If not needed (as is the case in this app, as far as I can tell) then one can/should use Attribute based
Security, applied here.

Hence why we're using Authorise Filters, applied globally, relaxed as needed (using AllowAnonymousAttribute).


## Resources ##

For some background, consider:
* https://stackoverflow.com/questions/26464848/custom-authorization-in-asp-net-webapi-what-a-mess
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-filters
