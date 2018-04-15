# About #

This folder contains the MVC Controllers backing the Views.

Note: for the WebAPI Controllers, refer to the ServiceFacade folder.

## MVC Views versus SPA ##

THere is no question that you 


## Roles versus Scopes ##

We'll often use the term Roles -- but technically, we're talking about OIDC Scopes.


## Security by Attributes ##

Authorization of requests to MVC Controller Actions is controlled via Attributes.

This Attribute is applied *Globally* from within  WebMvcFilterConfig, in order
to ensure that if a developer ever did forget about security (and they always do)
the method is *by default* secured to only allow Authenticated users.

Even then, it's never sufficient to just be authenticated. Every Operation MUST
be assigned to a role (whether it be Roles.User or more is not the point) before 
it can used. 

The reasons for this is that it is too easy to make the mistake of applying the Attribute,
without a clear understanding of whom should be able to use it, and walk away.
This invariably leads to some form of data leakage. It's best to be *specific* as to 
what roles can access an Operation.