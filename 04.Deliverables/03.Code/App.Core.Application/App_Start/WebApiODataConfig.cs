namespace App.Core.Application.App_Start
{
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using System.Web.OData.Query;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    public class WebApiODataConfig
    {
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            // SETUP STEP: 
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
                "DefaultODataApiPaths",
                "odata",
                builder.GetEdmModel());

            var queryAttribute = new EnableQueryAttribute()
            {
                AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Skip,
                MaxTop = 100
            };

            // REALLY IMPORTANT:
            EnableODataOperations(httpConfiguration);

        }

        private static void EnableODataOperations(HttpConfiguration httpConfiguration)
        {
            // IMPORTANT:
            // ENABLE THE LIST OF Commands
            // Or you'll get HTTP 500's when you use $expand or any other command.
            // Ref: https://stackoverflow.com/questions/39515218/odata-error-the-query-specified-in-the-uri-is-not-valid-the-property-cannot-be

            // You can enable everything, as follows:
            httpConfiguration.Count().Expand().Filter().Select().MaxTop(100).OrderBy().AddODataQueryFilter();
            // You can then limit specific entities to something else in their individual
            // IOdataModelBuilderConfigurationBase instance, as follows:
            //
            //builder.EntityType<DB.Project>().Filter("ProjectID");

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.White,
                    "OData Operations",
                    "Permissions granted for Filter, OrderBy, Expand, Select.");

        }

        private static void RegisterByReflectionTheODataModelDefinitions(ODataModelBuilder builder)
        {
            // HACK: Notice we are refering to the non-generic base instance (which 
            // accepts an Object argument) because the contract has to be defined in
            // App.Core.Infrastructure for App.ModuleXXX.Application to be able to reference
            // it. But in each Module, the base non-generic contract is enherited by a *Typed*
            // generic contract, (<IOdataModelBuilderConfiguration<T>) specicic to 
            // the App.ModuleXXX.Application.
            AppDependencyLocator.Current
                .GetAllInstances<IOdataModelBuilderConfigurationBase>()
                .ForEach(x => x.Define(builder));
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