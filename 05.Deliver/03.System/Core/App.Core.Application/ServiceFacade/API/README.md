# About #
These API Controllers only 
expose mapped DTO projections 
of CodeFirst Entities.

It's far better to show DTOs 
than Raw Application Entitie
objects derived straight from a db.

The reason is: if you are exposing
raw entities, you are exposing the 
schema of your db (insecure and dumb)
but also, you really should not make 
it easy to break every 3rd party
client every time you change the shape of
your db.

Use Mappers to map entities to DTOs and 
expose the DTOs only. 

The mapping turns out to be one place 
(and there are also other ways too)
to strip out Sensitive data -- or detokenize data too --
based on the Role of the session token the clients submitted.

## Notes ##

* Paths to these OData API Controllers are defined in 

## Resource ##