namespace App.Module1.Application.Initialization.OData.Implementations
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Module1.Infrastructure.Initialization.OData;

    /// <summary>
    /// Implementation invoked at Statup, when building 
    /// OData Models.
    /// </summary>
    public class AppModule1OdataModelBuilder : IAppModule1OdataModelBuilder
    {

        public void Initialize(object untypedHttpConfiguration)
        {
            HttpConfiguration httpConfiguration = (HttpConfiguration) untypedHttpConfiguration;

            Initialize(httpConfiguration);
        }

        public void Initialize(HttpConfiguration httpConfiguration)
        {
            // Whereas WebAPI are individual REST endpoints, OData endpoints
            // expose a model of intertwined entities. 
            // Hence these need to be defined first.
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            // Find all definition fragments, which ever assembly they were defined in:
            RegisterByReflectionTheODataModelDefinitions(builder);

            //SETUP STEP: 
            // Important: Can only be same routePrefix (eg:'api') as 
            // WebAPIs if it is registered *before* WebAPI routes...
            httpConfiguration.MapODataServiceRoute(
                routeName: Infrastructure.Constants.Module.Names.ModuleKey + "Paths",
                routePrefix: "odata/" + Infrastructure.Constants.Module.Names.ModuleKey.ToLower(),
                model: builder.GetEdmModel());
        }

        private int RegisterByReflectionTheODataModelDefinitions(ODataModelBuilder builder)
        {
            //This is a bit of a tricky part to understand.
            //Find and read up in README.STRUCTUREMAP.IDEMPOTENCY.txt

            var items = AppDependencyLocator.Current
                .GetAllInstances<IOdataModelBuilderConfigurationBase>()
                .Where(x => x is IAppModule1OdataModelBuilderConfiguration).ToArray();

            var count = items.Count();
            items.ForEach(x => x.Define(builder));

            return count;

        }

        /*
         *   NOTES:
         *  //How this works is you define an Entity, and map it to a string, that gets converted into a path.
            //So...say you enter http://localhost:9000/api/bodydtotest/
            //and because you said above that any url that starts with 'api' gets handled 
            //via odata, it then tries to find a controller called BodyDtoTestController. 
            //But even if you have a controller called BodyDtoTestController, it won't route to it,
            //until you've made a dataset named as 'bodydtotest':
            odataModelBuilder.EntitySet<BodyDto>("bodydtotest");
            //You can register a set with two different names. They both will work (as long
            //as you have two controllers: BodyDtoTestController and BodyDto2TestController
            //odataModelBuilder.EntitySet<BodyDto>("bodydtotest2");

            //It also works if you decorate the controller with [ODataRoutePrefix("bodybasic")]
            //as long as you don't forget to *also* decorate methods with [ODataRoute()]
            //as per https://stackoverflow.com/questions/29499378/odata-v4-routing-prefix
            odataModelBuilder.EntitySet<BodyDto>("bodybasic");



            //odataModelBuilder.EntitySet<FooSubItem>("foosubitem");
            odataModelBuilder.EntitySet<FooDto>("foodto");
            odataModelBuilder.EntitySet<FooDto>("fooitemdto");
            //odataModelBuilder.EntitySet<FooSubItemDto>("foo");
         */
    }
}