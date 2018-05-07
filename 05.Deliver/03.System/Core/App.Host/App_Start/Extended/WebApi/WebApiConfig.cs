using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.OData.Extensions;
using App.Core.Application.Initialization;
using App.Core.Infrastructure.Services;
using App.Host.Extended.WebApi.OData;
using App.Host.Extended.WebApi.Swagger;
using Microsoft.Web.Http.Routing;
using Newtonsoft.Json.Serialization;
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
        private readonly WebApiODataConfig _webApiODataConfig;

        public WebApiConfig(WebApiRouteConfig webApiRouteConfig, WebApiFilterConfig filterConfig, WebApiODataConfig webApiODataConfig, ITenantService tenantService)
        {
            this._webApiRouteConfig = webApiRouteConfig;
            this._tenantService = tenantService;
            _filterConfig = filterConfig;
            _webApiODataConfig = webApiODataConfig;
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

            httpConfiguration.AddApiVersioning(
                o =>
                {
                    o.ReportApiVersions = true;
                    o.AssumeDefaultVersionWhenUnspecified = true;
                });

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
            var constraintResolver = new DefaultInlineConstraintResolver() { ConstraintMap = { ["apiVersion"] = typeof(ApiVersionRouteConstraint) } };
            httpConfiguration.MapHttpAttributeRoutes(constraintResolver);


            // OData route registration must be before WebAPI routing:
            _webApiODataConfig.Configure(httpConfiguration);

            _webApiRouteConfig.Configure(httpConfiguration);

            _filterConfig.RegisterGlobalFilters(httpConfiguration);


            // After WebApi is sorted out:
            // Note that *usually* swagger is invoked because the SwaggerClass is decorated 
            // with [assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
            // But that calls it too early. and Swagger's list of APIs ends up empty
            // See: https://stackoverflow.com/questions/31840165/swashbuckle-5-cant-find-my-apicontrollers
            SwaggerConfig.Register();
        }
    }
}