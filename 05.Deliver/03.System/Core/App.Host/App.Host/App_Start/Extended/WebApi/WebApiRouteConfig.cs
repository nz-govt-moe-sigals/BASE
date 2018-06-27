using System.Web.Http;
using App.Core.Infrastructure.Initialization.DependencyResolution;
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

            // Leave existing configuration (ensure after 'config.MapODataServiceRoute')

            // ----------------------------------
            // Triple arg:

            //httpConfiguration.Routes.MapHttpRoute(
            //"VersionedTenantedLocaledDefaultWebApiRoute",
            //"api/v{apiVersion}/{tenant}/{locale}/{controller}/{id}",
            //defaults: new { id = RouteParameter.Optional },
            //constraints: new
            //{
            //    apiVersion = new ApiVersionRouteConstraint(),
            //    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint)),
            //    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            //}
            //);



            //// ----------------------------------
            //// Double arg:
            //httpConfiguration.Routes.MapHttpRoute(
            //"VersionedTenantedDefaultWebApiRoute",
            //"api/v{apiVersion}/{tenant}/{controller}/{id}",
            //defaults: new { id = RouteParameter.Optional },
            //constraints: new
            //{
            //    apiVersion = new ApiVersionRouteConstraint(),
            //    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint)),
            //}
            //);

            //httpConfiguration.Routes.MapHttpRoute(
            //"VersionedLocaledDefaultWebApiRoute",
            //"api/v{apiVersion}/{locale}/{controller}/{id}",
            //defaults: new { id = RouteParameter.Optional },
            //constraints: new
            //{
            //    apiVersion = new ApiVersionRouteConstraint(),
            //    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            //}
            //);


            //httpConfiguration.Routes.MapHttpRoute(
            //    "TenantedLocaledDefaultWebApiRoute",
            //    "api/{tenant}/{locale}/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: new
            //    {
            //        tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint)),
            //        locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            //    }
            //);
            //// ----------------------------------
            //// Single arg:
            //httpConfiguration.Routes.MapHttpRoute(
            //    "TenantedDefaultWebApiRoute",
            //    "api/{tenant}/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: new
            //    {
            //        tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantWebApiRouteConstraint))
            //    }
            //);
            //httpConfiguration.Routes.MapHttpRoute(
            //    "LocaledDefaultWebApiRoute",
            //    "api/{locale}/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional },
            //    constraints: new
            //    {
            //        locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleWebApiRouteConstraint))
            //    }
            //);
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