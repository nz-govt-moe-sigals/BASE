using System.Web.Http;
using System.Web.OData.Extensions;
using App.Core.Application.Initialization;
using App.Core.Infrastructure.Services;
using Owin;

namespace App.Host.Extended.WebApi
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// WebApi.
    /// </summary>
    public class WebApiConfig
    {
        private readonly WebApiRouteConfig _webApiRouteConfig;
        private readonly ITenantService _tenantService;
        private readonly WebApiFilterConfig _filterConfig;

        public WebApiConfig(WebApiRouteConfig webApiRouteConfig, WebApiFilterConfig filterConfig, ITenantService tenantService)
        {
            this._webApiRouteConfig = webApiRouteConfig;
            this._tenantService = tenantService;
            _filterConfig = filterConfig;
        }
        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public void Configure(IAppBuilder appBuilder)
        {
            // VERSIONING:
            // https://github.com/Microsoft/aspnet-api-versioning/wiki/API-Versioning-with-OData
            // httpConfiguration.AddApiVersioning();

            // According to /*?*/ a common error when using OWIN in MVC is trying using
            // GlobalConfiguration.Configuration. You don't. You use a brand new one.
            // And since you're not using GlobalConfiguration.Configuration, you don't use
            // GlobalConfiguraiton.Configure(...) either. 
            // Get alternate singleton:
            var httpConfiguration = HttpConfigurationLocator.Current;

            //GlobalConfiguration.Configure(httpConfiguration =>
            //{ 
            StaticFileHandlingConfig.Configure(httpConfiguration);
            WebApiCorsConfig.Configure(httpConfiguration);
            WebApiJsonSerializerConfig.Configure(httpConfiguration);
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

            _filterConfig.RegisterGlobalFilters(httpConfiguration);

            // Ensure WebAPI is activated (via Microsoft.AspNet.WebApi.Owin package):
            // Not needed (also, gone in MVC 6): appBuilder.UseWebApi(httpConfiguration);
            // See: https://stackoverflow.com/a/43852361
            // Which is good, because GlobalConfiguration.Configuration seems to stops 
            // working after adding '.UseWebApi'. 
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}