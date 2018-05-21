# About #

These are Base Controllers for the whole System (not just specific to a single Module).

Each Module (including this one) implements an abstract Base Controller based on these Controllers, 
adding to it the Module's specific DbContext.

Advantages:
* These base controllers handle security in a generic way, ensuring that that there is a common approach.
* These base controllers ensure that the same services are injected and available everywhere 
  (notably IDiagnosticsTracingService and IPrincipalService) so that every developer has the tools to 
  keep their code maintainable and secure.
  * Note that even if developers skimp on either, there are global filters doing both tasks in a generic
    approach.
* Disadvantages:
  * Inheritence is almost an anti-pattern, and I'm not keen on every controller having such strong dependencies.