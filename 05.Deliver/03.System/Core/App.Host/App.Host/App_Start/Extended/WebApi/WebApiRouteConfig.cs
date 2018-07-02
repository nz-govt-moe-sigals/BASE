using System.Web.Http;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Host.Extended.WebApi.Constraints;
using Microsoft.Web.Http.Routing;

namespace App.Host.Extended.WebApi
{
    public class WebApiRouteConfig
    {
        private ITenantWebApiRouteConstraint _tenantWebApiRouteConstraint;

        public WebApiRouteConfig(ITenantWebApiRouteConstraint tenantWebApiRouteConstraint)
        {
            _tenantWebApiRouteConstraint = tenantWebApiRouteConstraint;
        }

        /// <summary>
        /// Configures the specified HTTP configuration.
        /// <para>
        /// Invoked from <see cref="WebApiConfig.Configure"/>
        /// </para>
        /// <para>
        /// Note that by default ASP.NET does not manage static files --  until (RAMMFAR)
        /// `configuration/system.webServer/modules @runAllManagedModulesForAllRequests = "false"`
        /// is set in the config file(`true` is the default in this app, but this hamper debugging
        /// of the first install.)
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        public void Configure(HttpConfiguration httpConfiguration)
        {

            // Leave existing configuration (ensure after 'config.MapODataServiceRoute')

            // ----------------------------------
            // Triple arg:

            httpConfiguration.Routes.MapHttpRoute(
            "VersionedTenantedLocaledDefaultWebApiRoute",
            "{tenant}/api/{locale}/v{apiVersion}/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional },
            constraints: new
            {
                apiVersion = new ApiVersionRouteConstraint(),
                tenant = _tenantWebApiRouteConstraint,
                locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            }
            );



            // ----------------------------------
            // Double arg:
            httpConfiguration.Routes.MapHttpRoute(
            "VersionedTenantedDefaultWebApiRoute",
            "{tenant}/api/v{apiVersion}/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional },
            constraints: new
            {
                apiVersion = new ApiVersionRouteConstraint(),
                tenant = _tenantWebApiRouteConstraint,
            }
            );

            httpConfiguration.Routes.MapHttpRoute(
            "VersionedLocaledDefaultWebApiRoute",
            "api/{locale}/v{apiVersion}/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional },
            constraints: new
            {
                apiVersion = new ApiVersionRouteConstraint(),
                locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            }
            );


            httpConfiguration.Routes.MapHttpRoute(
                "TenantedLocaledDefaultWebApiRoute",
                "{tenant}/api/{locale}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new
                {
                    tenant = _tenantWebApiRouteConstraint,
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
                }
            );
            // ----------------------------------
            // Single arg:
            httpConfiguration.Routes.MapHttpRoute(
                "TenantedDefaultWebApiRoute",
                "{tenant}/api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new
                {
                    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint))
                }
            );
            httpConfiguration.Routes.MapHttpRoute(
                "LocaledDefaultWebApiRoute",
                "api/{locale}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new
                {
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
                }
            );
            httpConfiguration.Routes.MapHttpRoute(
                "VersionedUrl",
                "api/v{apiVersion}/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { apiVersion = new ApiVersionRouteConstraint() });

            // ----------------------------------
            // No arg:
            httpConfiguration.Routes.MapHttpRoute(
                "DefaultWebApiRoute",
                "api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }





}