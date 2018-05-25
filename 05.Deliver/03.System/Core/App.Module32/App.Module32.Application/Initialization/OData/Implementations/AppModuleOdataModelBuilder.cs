using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using App.Core.Application.Initialization.OData;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using Microsoft.OData.Edm;
using Microsoft.Web.OData.Builder;

namespace App.Module32.Application.Initialization.OData.Implementations
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


        private IAppModuleOdataModelBuilderConfiguration[] RegisterByReflectionTheODataModelDefinitions()
        {
            return AppDependencyLocator.Current.GetAllInstances<IAppModuleOdataModelBuilderConfiguration>().ToArray();
        }

    }
}

