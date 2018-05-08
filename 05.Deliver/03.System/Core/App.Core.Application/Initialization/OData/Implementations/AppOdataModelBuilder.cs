using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Initialization.OData;
using Microsoft.OData.Edm;
using Microsoft.Web.OData.Builder;

namespace App.Core.Application.Initialization.OData.Implementations
{
    /// <summary>
    /// Implementation invoked at Statup, when building 
    /// OData Models.
    /// </summary>
    public class AppOdataModelBuilder : IOdataModelBuilder
    {
        public IEnumerable<IEdmModel> GetEdmModels(HttpConfiguration configuration)
        {
            var modelBuilder = new VersionedODataModelBuilder(configuration)
            {
                ModelBuilderFactory = () => new ODataConventionModelBuilder().EnableLowerCamelCase(),
                ModelConfigurations =
                {
                    //new ApplicationDescriptionOdataModelBuilderConfiguration(),
                    //new DataClassificationOdataModelBuilderConfiguration(),

                }
            };
            foreach (var item in RegisterByReflectionTheODataModelDefinitions())
            {
                modelBuilder.ModelConfigurations.Add(item);
            }

            return modelBuilder.GetEdmModels();
        }

        public string GetRoutePrefix()
        {
            return "core";
        }


        private IAppCoreOdataModelBuilderConfigurationBase[] RegisterByReflectionTheODataModelDefinitions()
        {
            return AppDependencyLocator.Current.GetAllInstances<IAppCoreOdataModelBuilderConfigurationBase>().ToArray();
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