So when adding structure map to the project <c ref="App.Core.Application.App_Start.StructuremapWebApi">
using the following line of code 
HttpConfigurationLocator.Current.DependencyResolver = new StructureMapWebApiDependencyResolver(container);

obviously if you remove this line then Structuremap will no longer dependcy inject! 


it seems to remove(clear etc... , behavioural not actual?) the IApiexplorer from the definition despite it being defined before
structuremap being assigned. this can be seen in https://localhost:44311/documentation, where there are no routes defined. 

I think Swagger uses IApiexplorer to determine the URLs to show on the webpage. 

Now originally After adding this library into the code base it resolved the strucuturemap issue and got it working once again.
https://github.com/rbeauchamp/Swashbuckle.OData


However then APIversioning was introduced and the above library does not appear to function with it :(
the code base worked and has working samples to show that it working with odata, 
https://github.com/Microsoft/aspnet-api-versioning

Essentailly after banging my head against a brick wall, I could not find it,
The below hints at a fix but doesn't show working
"needed to create a registry for IApiExplorers." Within Strucuturemap create a registry for them? perhaps?
https://github.com/domaindrivendev/Swashbuckle/issues/737



