﻿namespace App.Core.Application
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using App.Core.Infrastructure.Services;

    public class WebMvcRouteConfig
    {


        /// <summary>
        /// Registers the web MVC routes.
        /// <para>
        /// Invoked from <see cref="WebMvcConfig.Configure"/>.
        /// </para>
        ///  </summary>
        public static void RegisterWebMvcRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Routes are evaluated in the order they are listed. 
            // MVC Controllers are mapped using '.MapRoute' and WebAPI Controllers using '.MapHttpRoute'.
            routes.MapRoute(
                "TenantedLangedDefaultWebMvcRoute",
                "{tenant}/{locale}/{controller}/{action}/{id}",
                new
                {
                    controller = "About",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new
                {
                    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantRouteConstraint)),
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleRouteConstraint))
                }
            );

            routes.MapRoute(
                "TenantedDefaultWebMvcRoute",
                "{tenant}/{controller}/{action}/{id}",
                new
                {
                    controller = "About",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new
                {
                    tenant = AppDependencyLocator.Current.GetInstance(typeof(TenantRouteConstraint))
                }
            );

            routes.MapRoute(
                "LocaledDefaultWebMvcRoute",
                "{locale}/{controller}/{action}/{id}",
                new
                {
                    controller = "About",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new
                {
                    locale = AppDependencyLocator.Current.GetInstance(typeof(LocaleRouteConstraint))
                }
            );


            routes.MapRoute(
                "DefaultWebMvcRoute",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "About",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                new { }
            );
        }
    }


    public class TenantRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
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

    public class LocaleRouteConstraint : IRouteConstraint
    {
        private readonly ILocalisationService _localisationService;

        public LocaleRouteConstraint(ILocalisationService localisationService)
        {
            this._localisationService = localisationService;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
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

            //string url = httpContext.Request.RawUrl;


            //if (localisationService.ThreadCultureSet)
            //{
            //    return true;
            //}


            //if (locale == "--")
            //{
            //    // Not defined in route, so fall back to 
            //    // Principal Claimed Preferred language,
            //    // TODO:
            //    IPrincipalService principalService =
            //        (IPrincipalService) GlobalConfiguration.Configuration.DependencyResolver.GetService(
            //            typeof(IPrincipalService));

            //    // See if it's defined in the user's Claims, and if not defined, the browser's defined preference:
            //    // Note that the browser stores the locale codes as a scored array:
            //    // [0]: "en-US"
            //    // [1]: "en;q=0.8"
            //    // [2]: "da;q=0.6"
            //    // [3]: "sv;q=0.4"
            //    locale = principalService.ClaimPreferredCultureCode ??
            //           httpContext.Request.UserLanguages?.FirstOrDefault()?.Split(';')[0] ?? "en";
            //}


            //localisationService.SetThreadCulture(locale);

            //return true;
        }
    }
}