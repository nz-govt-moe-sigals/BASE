# About #

This Namespace is for the Contracts (not the Implementations) of Infrastructure Services.

Infrastructure Services
* know nothing about the Business Domain (see Domain Services)
* provide single concern classes of methodsto manage a single underlying or external service.
* They are *only* used  by Application Services. 
* They are *never* invoked directly by Business Services.
* A key objective is to isolate the logic specific to you this system 
  (ie, the ApplicationServices + DomainServices) from the technology needed to
  automate the Business Logic. 
  * This can lead to little classes like DiagnosticsService which provides a single Trace
    method, just so that all the rest of the code uses a class that belongs to a service
	it has in its code base -- rather than a direct dependency on a vendor product (Log4Net, etc.)
	This makes it easier to later swap out the vendor library for another, and only have 
	a single place to update code (in the Implementation of the service's contract).
  * It also has the advantage of simplifying the use of external services. In other words
    The developer who creates AzureStorageService has to know about how storage works, but
	can keep the logic contained in the service...and all the other developers on the project
	only need to ask for a file, or save a file, using the service -- and never know anything
	about *how* it is saved. Decreases development costs and makes for less frustrated development
	teams (eg: one side feeling that the newbies are not good enough cause they know nothing about
	XYZ...and the newbies feeling the oldies made 'too complicated to understand' code and spend
	time trying to 'simplify' it to the point they do understand it...which wastes time/cost
	to sooner or later get back to the initial place.
  * Small classes that confuse new comers include:
    * UniversalDateTime:
	  * Q: why do you have a class just for dates?! 
	  * A: so I can mock changes of dates (eg: 29/2/yyyy and 31/12/yyyy) to test logic of reports
	       etc. at the end of the year.
		   It's also so I can scan the code for DateTime.Now during automated code reviews, 
		   and reject the work as the developer doesn't understand the important of global datetime
		   when hosting on international cloud services. Or working with mobile devices.
	* ContextService:
	  * Q: You spent time wrapping HttpContext?!
	  * A: Yes. So the HttpContext can be mocked for unit-testing.
	* RepositoryService:
	  * Q: Why can't I use EntityFramework directly?
	  * A: I'm sure you know everything about EF...but in general, team members don't...and will
	       Commit() at the end of their work...causing tons of issues for everyone else. You want
		   to Commit as few times as possible. ie. Once. At the end of Request.
		   You also want to be able to swap out to other ORMs (eg: Sqlite) during Testing.
		   You might want to switch off of EF completly, without disrupting the code. So let
		   everyone rely on a RepositoryService...and not directly on a vendor product for such
		   a critical process.
	* PrincipalService:
	  * Q: What about Thread.Principal?
	  * A: Again...Most intermediate, even senior devs, don't fully get identity...make it simple
	       by isolating identity work to classes, keep it DRY, rather than have tons of places
		   in the code where you extract a Principal, check its Claims...etc. That's rubbish
		   just waiting for bugs.
		   YOu also -- as with all services -- want to be able to mock the whole service
		   when unit testing. 
	* LocalisationService:
	  * Q: Isn't Localisation built into the framework?
	  * A: Not evenly (changes with every UI Framwork). Localisation is hard science. 
	       Microsoft has stabbed at this several times, but I think they always start by tring
		   to solve it for the server side generated UI...and it keeps on coming short for modern
		   development (ie SPAs, with client side generated UI).
		   So we're solving for the SPA and REST side first.
    * There are plenty of other small services...but that actually IS THE OBJECTIVE:
	  * Making small specialised classes, doing one thing, well, isolating complexity to one place in the app
	  * so that all the other parts of the code can just use the services
	  * without knowing how it is done, getting on with their own concerns.
	  * ie, less bugs in the end, and more maintainable. 
	  * Also more modifiable (only one place to update code)


