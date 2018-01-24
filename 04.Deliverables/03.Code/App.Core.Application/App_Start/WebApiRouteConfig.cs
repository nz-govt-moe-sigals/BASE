namespace App.Core.Application
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using App.Core.Infrastructure.Services;

    public static class WebApiRouteConfig
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
            httpConfiguration.Routes.MapHttpRoute(
                "DefaultWebApiRoute",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }

    public class TenantWebApiRouteConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var tenantName = values[parameterName].ToString().ToLowerInvariant();
            var tenantService = AppDependencyLocator.Current.GetInstance<ITenantService>();

            //(ITenantService)GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //    typeof(ITenantService));

            var result = tenantService.IsValidTenantKey(tenantName);
#if DEBUG
            if (result)
            {
                //Makes it breakpointable.
                return true;
            }
#endif
            return result;
        }
    }


    public class LocaleWebApiRouteConstraint : IHttpRouteConstraint
    {
        private readonly ILocalisationService _localisationService;

        public LocaleWebApiRouteConstraint(ILocalisationService localisationService)
        {
            this._localisationService = localisationService;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            var locale = values[parameterName].ToString();

            //ILocalisationService localisationService =
            //    (ILocalisationService)GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //        typeof(ILocalisationService));

            var result = this._localisationService.IsValidCultureInfoName(locale);
#if DEBUG
            if (result)
            {
                //Makes it breakpointable.
                return true;
            }
#endif
            return result;
        }
    }
}