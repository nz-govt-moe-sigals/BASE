using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using App.Core.Application.Initialization.OData;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Module31.Application.Constants.Api;
using Microsoft.OData.Edm;
using Microsoft.Web.OData.Builder;

namespace App.Module31.Application.Initialization.OData.Implementations
{


    /// <summary>
    /// Implementation invoked at Statup, when building 
    /// OData Models.
    /// </summary>
    public class AppModuleOdataModelBuilder : IOdataModelBuilder, IHasModuleSpecificIdentifier
    {

        public IEnumerable<IEdmModel> GetEdmModels(HttpConfiguration configuration)
        {
            var modelBuilder = new VersionedODataModelBuilder(configuration)
            {
                ModelBuilderFactory = () => new ODataConventionModelBuilder(),
                ModelConfigurations =
                {
                    //new WardODataModelBuilderConfiguration(),
                    //new UrbanAreaODataModelBuilderConfiguration(),
                    //new AreaUnitODataModelBuilderConfiguration(),
                    //new TerritorialAuthorityODataModelBuilderConfiguration()
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
            return ApiControllerNames.PathRoot.ToLower();
        }


        private IAppModuleOdataModelBuilderConfiguration[] RegisterByReflectionTheODataModelDefinitions()
        {
            return AppDependencyLocator.Current.GetAllInstances<IAppModuleOdataModelBuilderConfiguration>().ToArray();
        }
    }
}




