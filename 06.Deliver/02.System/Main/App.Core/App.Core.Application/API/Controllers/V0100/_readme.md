# About #

This folder contains the API Controllers backing the Views.

Note: for the WebMVC Controllers, refer to the Presentation/Controllers folder.

## Roles versus Scopes ##

We'll often use the term Roles -- but technically, we're talking about OIDC Scopes.

## Security by Attributes ##

Authorization of requests to API Controller Actions is controlled via Attributes.

This Attribute is applied *Globally* from within  `WebApiFilterConfig`, in order
to ensure that if a developer ever did forget about security (and they always do)
the method is *by default* secured to only allow Authenticated users.

Even then, it's never sufficient to just be authenticated. Every Operation MUST
be assigned to a role (whether it be Roles.User or more is not the point) before 
it can used. 

The reasons for this is that it is too easy to make the mistake of applying the Attribute,
without a clear understanding of whom should be able to use it, and walk away.
This invariably leads to some form of data leakage. It's best to be *specific* as to 
what roles can access an Operation.