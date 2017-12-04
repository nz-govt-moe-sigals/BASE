Search is something Elegant -- that is usually botched.

Systems can offer one of two search solutions that are better than 
specific Search Forms (eg: Contact Search Form...which suck).

All end users know how to search using Google. 
Which works by searches across Projections (ie, google 
owned indexed summary records) of the target 
Resource (the actual webpage on a public site)

This can be emulated by either integrating Lucene.NET (tricky...)
using an Enterprise wide Search Service (lots of security implications),
using an external Search Service (extra integration costs versus productivity gains)
or starting off with low cost built-in search providers.

Which is what is demonstrated here:

Each Module has one or more SearchProvder implementations (implementing ISearchProvider)
which do the work of taking the provided search term, and searching their individual
tables for values that match, and returning them as neutral projection models, of type
SearchResultItem.
