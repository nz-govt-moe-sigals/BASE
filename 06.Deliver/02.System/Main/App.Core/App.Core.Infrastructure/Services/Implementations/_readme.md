# About #

This namespace is for the *Implementations* of the *Contracts* 
for Infrastructure Services, defined in the folder above.

ie, this is where the actual code goes.

If you want a description of what Infrastructure Services are
refer to the readme.md in the folder above.


## Conventions ##



### Constructors and Dependency Injection ###

Your code MUST not new Services anywhere in the code:


    void Foo() {
	    // Awsomely wrong way to code!
	    new BarService().DoSomething()
    }

Instead, inject the dependency's contract in:

    // Follow DependencyInjection principles. Much better:
    class FooService(){
      IBarService _barService;
      FooService(IBarService barService){_barService = barService;}

      void Foo(){ _barService.DoSomething();}
    }


### Class Naming ###

The service locator (in this case StructureMap)
automatically finds paired classes, that both have the same suffix.

It will match:

* interface ISomeService
* class SomeService

It will not match:

* interface ISomeService
* class MyService

or

* interface ISomeService
* class Myservice

So watch your spelling and Case.


