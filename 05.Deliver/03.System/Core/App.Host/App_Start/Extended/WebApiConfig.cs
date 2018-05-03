namespace App.Core.Application.Extended
{
    using System.Web.Http;
    using System.Web.OData.Extensions;
    using App.Core.Application.App_Start;
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// WebApi.
    /// </summary>
    public class WebApiConfig
    {
        private readonly WebApiRouteConfig _webApiRouteConfig;
        private readonly ITenantService _tenantService;

        public WebApiConfig(WebApiRouteConfig webApiRouteConfig, ITenantService tenantService)
        {
            this._webApiRouteConfig = webApiRouteConfig;
            this._tenantService = tenantService;
        }
        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public void Configure(HttpConfiguration httpConfiguration)
        {
            // VERSIONING:
            // https://github.com/Microsoft/aspnet-api-versioning/wiki/API-Versioning-with-OData
            // httpConfiguration.AddApiVersioning();

            // Note:
            // WebAPI enablement is done after WebMvc routes and filters 
            // are sorted out.
            httpConfiguration.EnableDependencyInjection();
            //NO: httpConfiguration.DependencyResolver = new DependencyResolver();

            // Leave existing configuration for Web API routes
            // By default one can register 'global' routes to handle
            // API calls. But you can augment these 'global' route rules
            // with Attribute based rules if MapHttpAttributeRoutes 
            // is enabled (eg, by decorating an Action with
            // [Route("api/department/{id}/employees")], or
            // [Route("api/department/{id:int:min(1):max(2):maxlength(1)}/employees")] 
            // Observations:
            // MapHttpAttributeRoutes is invoked *before* 
            // defining WebAPI routes. 
            // And also before OData is configured, 
            // or else EnsureInitialized gets unhappy:
            httpConfiguration.MapHttpAttributeRoutes();


            // OData route registration must be before WebAPI routing:
            WebApiODataConfig.Configure(httpConfiguration);

            _webApiRouteConfig.Configure(httpConfiguration);
        }
    }
}