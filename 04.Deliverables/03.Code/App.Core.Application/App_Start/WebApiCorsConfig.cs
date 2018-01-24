namespace App.Core.Application
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    public class WebApiCorsConfig
    {
        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            // SETUP STEP: Enable CORS via Microsoft.AspNet.WebApi.Cors package.
            // As per https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
            httpConfiguration.EnableCors(new EnableCorsAttribute("*", "*", "*", "*"));
            // Note that the above can be locked down by decorating WebAPI and OData Controller
            // classes and Actions with Attributes similar to:
            // [EnableCors(origins: "http://localhost:5901,http://localhost:8768", headers: "*", methods: "post,get")]

            AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                .Register(
                    ConfigurationStepType.Security,
                    ConfigurationStepStatus.White,
                    "CORS Enabled",
                    "* For Origins, Headers, Actions, ExposedHeaders");

        }
    }
}