
### Conventions ###
The need to version APIs is a key consideration when developing mappings between
Entity Models and DTO/Message Models.
How to organise them is the question...
For now we're  going with the concept of Folders per version variants...let's see if that's ok.


### Constraints ###
Object Maps (ie whether by AutoMapper or other) must not be placed in Shared 
as it they need a dependency on Infrastructure (the Dependency needs
to be the other way around, with Infrastructrure depending on Shared).

