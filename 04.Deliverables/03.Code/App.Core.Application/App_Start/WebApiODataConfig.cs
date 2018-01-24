namespace App.Core.Application.App_Start
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using System.Web.OData.Extensions;
    using System.Web.OData.Query;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    public class WebApiODataConfig
    {
        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="WebApiConfig.Configure"/>
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public static void Configure(HttpConfiguration httpConfiguration)
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

        private static int BuildCommonODataModel(HttpConfiguration httpConfiguration)
        {
            var tmp = AppDependencyLocator.Current
                .GetAllInstances<IOdataModelBuilderBase>();
            var count = tmp.Count();
            // This builds the OData Models -- both a common one, including
            // all modules, then Module specific end points
            tmp.ForEach(x => x.Initialize(httpConfiguration));

            return count;
        }



        private static void EnableODataOperations(HttpConfiguration httpConfiguration)
        {
            EnableODataCommandsAllowed(httpConfiguration);

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.White,
                    "OData Operations",
                    "Permissions granted for Filter, OrderBy, Expand, Select.");
        }

        private static void EnableODataCommandsAllowed(HttpConfiguration httpConfiguration)
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
        }

    }
}