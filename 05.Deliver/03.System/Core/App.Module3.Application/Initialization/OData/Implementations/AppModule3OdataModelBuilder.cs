using System.Collections.Generic;
using App.Core.Application.Initialization.OData;
using Microsoft.OData.Edm;
using Microsoft.Web.OData.Builder;

namespace App.Module3.Application.Initialization.OData.Implementations
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Module3.Application.Constants.Api;
    using App.Module3.Application.Initialization.OData;

    /// <summary>
    /// Implementation invoked at Statup, when building 
    /// OData Models.
    /// </summary>
    public class AppModule3OdataModelBuilder : IOdataModelBuilder
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
            return Infrastructure.Constants.Module.Names.ModuleKey.ToLower();
        }


        private IAppModule3OdataModelBuilderConfiguration[] RegisterByReflectionTheODataModelDefinitions()
        {
            return AppDependencyLocator.Current.GetAllInstances<IOdataModelBuilderConfigurationBaseStub>().OfType<IAppModule3OdataModelBuilderConfiguration>().ToArray();
        }
    }
}