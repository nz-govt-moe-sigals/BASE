using System.Web.Http;
using App.Host.Extended.WebApi.Constraints;
using Microsoft.Web.Http.Routing;

namespace App.Host.Extended.WebApi
{
    public class WebApiRouteConfig
    {

        public WebApiRouteConfig()
        {
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
            /*
            // Leave existing configuration (ensure after 'config.MapODataServiceRoute')
            httpConfiguration.Routes.MapHttpRoute(
                "TenantedLocaledDefaultWebApiRoute",
                "api/{tenant}/{locale}/{controller}/{id}",
                new {id = RouteParameter.Optional},
                new
                {
                    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint)),
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
                }
            );
            httpConfiguration.Routes.MapHttpRoute(
                "TenantedDefaultWebApiRoute",
                "api/{tenant}/{controller}/{id}",
                new {id = RouteParameter.Optional},
                new
                {
                    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint))
                }
            );
            httpConfiguration.Routes.MapHttpRoute(
                "LocaledDefaultWebApiRoute",
                "api/{locale}/{controller}/{id}",
                new {id = RouteParameter.Optional},
                new
                {
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
                }
            );
            */

            httpConfiguration.Routes.MapHttpRoute(
                "VersionedUrl",
                "api/v{apiVersion}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { apiVersion = new ApiVersionRouteConstraint() });

            httpConfiguration.Routes.MapHttpRoute(
                "DefaultWebApiRoute",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }





}