FYI:
Object Maps (ie whether by AutoMapper or other) must not be placed in Shared 
as it they need a dependency on Infrastructure (the Dependency needs
to be the other way around, with Infrastructrure depending on Shared)