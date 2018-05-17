
[EnableQuery()] applies everything at the end on the OBJECT TYPE you are returning]

When manually applying the ODataQueryOptions 
- ensure that you remove the [EnableQuery()], if applied you will double apply any parameters, see also: http://www.lucidmotions.net/webapi-odata-v4-and-double-applied-skip/
- Have written a [EnableQueryExtended()] this removed the second skip so will apply parameters on the end


IF you are taking control of creating your object type because it is far too difficult to map then you must:
 - use ODataQueryOptions<objectype> 
 - use [EnableQueryExtended()] To allow for Expand and Select on the final object, this will allow for Expand and Select, this also stops the aforementioned $skip
 
 -- TODO figure out






useful link

https://www.jauernig-it.de/intercepting-and-post-processing-odata-queries-on-the-server/