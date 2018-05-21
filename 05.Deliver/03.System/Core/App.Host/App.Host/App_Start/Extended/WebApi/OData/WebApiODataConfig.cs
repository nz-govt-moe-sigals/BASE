using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using App.Core.Application.Initialization.OData;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace App.Host.Extended.WebApi.OData
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// the specified HTTP configuration.
    /// </summary>
    public class WebApiODataConfig
    {
        public WebApiODataConfig()
        {

        }

        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="WebApiConfig.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public void Configure(HttpConfiguration httpConfiguration)
        {
            //var queryAttribute = new EnableQueryAttribute()
            //{
            //    AllowedQueryOptions = AllowedQueryOptions.Top | AllowedQueryOptions.Skip,
            //    MaxTop = 100
            //};

            // REALLY IMPORTANT:
            EnableODataOperations(httpConfiguration);

            BuildCommonODataModel(httpConfiguration);
        }

        private int BuildCommonODataModel(HttpConfiguration httpConfiguration)
        {
            //Search for the Common base class,
            //using the untyped contract:
            var tmp = AppDependencyLocator.Current
                .GetAllInstances<IOdataModelBuilder>().ToList();
            var count = tmp.Count();
            // This builds the OData Models -- both a common one, including
            // all modules, then Module specific end points
            tmp.ForEach(x =>
            {
                Config(x, httpConfiguration);
            });

            return count;
        }


        public List<IEdmModel> Config(IOdataModelBuilder modefBuilder, HttpConfiguration configuration)
        {
            var models = modefBuilder.GetEdmModels(configuration).ToList();
            string prefix = modefBuilder.GetRoutePrefix();

            //  while you can use both, it is advised you should choose only ONE of the following; comment, uncomment, or remove as necessary
            //but who cares for advice

            // WHEN VERSIONING BY: query string, header, or media type
            configuration.MapVersionedODataRoutes("odata" + prefix, "odata/" + prefix, models, ConfigureODataServices);

            // WHEN VERSIONING BY: url segment
            configuration.MapVersionedODataRoutes("odata-bypath" + prefix, "odata/" + prefix + "/v{apiVersion}", models,
                ConfigureODataServices);

            return models;
        }

        static void ConfigureODataServices(IContainerBuilder builder)
        {
            builder.AddService(ServiceLifetime.Singleton, typeof(ODataUriResolver),
                sp => new CaseInsensitiveODataUriResolver());
        }


        private void EnableODataOperations(HttpConfiguration httpConfiguration)
        {
            EnableODataCommandsAllowed(httpConfiguration);

        }

        private void EnableODataCommandsAllowed(HttpConfiguration httpConfiguration)
        {
            using (var elapsedTime = new ElapsedTime())
            {
                // IMPORTANT:
                // ENABLE THE LIST OF Commands
                // Or you'll get HTTP 500's when you use $expand or any other command.
                // Ref: https://stackoverflow.com/questions/39515218/odata-error-the-query-specified-in-the-uri-is-not-valid-the-property-cannot-be

                // You can enable everything, as follows:
                httpConfiguration
                    .Count()
                    .Expand()
                    .Filter( /*noparam to allow for any*/)
                    .Select()
                    .MaxTop(100)
                    .OrderBy()
                    .AddODataQueryFilter();

                //Beyond the above global operation controls, you can then limit 
                // specific entities to something else in their individual
                // IOdataModelBuilderConfigurationBase instance, as follows:
                //builder.EntityType<DB.Project>().Filter("ProjectID");
                // but be forewarned that when you do that you have to re-apply
                // the other operations you want to allow (ie, the above does 
                // not inherit, as far as I can tell).


                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.White,
                        "OData Operations",
                        $"Permissions granted for Filter, OrderBy, Expand, Select. Took {elapsedTime.ElapsedText}");

            }
        }
    }
}