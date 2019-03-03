# About #

The 'system.json' and 'app.base.core.parameters.json' file were originally obtained from the 
infrastructure specialists.


## Process ##

The infrastructure specialists provide two templates:

* demo.app.01.json
* demo.app.o1.parameters.json

The files are renamed as per your projects needs. In this case:

* system.json
* system.parameters.json

You leave system.json alone.
You edit system.parameters.json as required for your needs.
You source control both, so that your build server can reference them.

## Updates ##

The infrastructure specialists may release updates of the central scripts.
In theory the changes should be backward compatible in that you can drop in the 
new demo.app.01.json file, rename it, all will - in theory - still work. 

As for the parameters.json file - edit the parameters file as needed to
 take advantage of new parameter options. Watch out for removing trailing 
 commas (it must always remain valid json).
