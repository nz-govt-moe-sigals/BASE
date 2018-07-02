using System.Web.Mvc;
using System.Web.Routing;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Core.Infrastructure.Services;
using App.Host.Extended.Mvc.Constraints;

namespace App.Host.Extended.Mvc
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// the registration of web MVC routes.
    /// <para>
    /// Note that by default ASP.NET does not manage static files --  until (RAMMFAR)
    /// `configuration/system.webServer/modules @runAllManagedModulesForAllRequests = "false"`
    /// is set in the config file(`true` is the default in this app, but this hamper debugging
    /// of the first install.)
    /// </para>
    ///  </summary>
    public class WebMvcRouteConfig
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly ITenantRouteConstraint _tenantRouteConstraint;

        public WebMvcRouteConfig(IDiagnosticsTracingService diagnosticsTracingService,
            ITenantRouteConstraint tenantRouteConstraint)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            _tenantRouteConstraint = tenantRouteConstraint;
        }

        /// <summary>
        /// Registers the web MVC routes.
        /// <para>
        /// Invoked from <see cref="WebMvcConfig.Configure"/>.
        /// </para>
        /// <para>
        /// Note that by default ASP.NET does not manage static files --  until (RAMMFAR)
        /// `configuration/system.webServer/modules @runAllManagedModulesForAllRequests = "false"`
        /// is set in the config file(`true` is the default in this app, but this hamper debugging
        /// of the first install.)
        /// </para>
        /// </summary>
        /// <param name="routes">The routes.</param>
        public void RegisterWebMvcRoutes(RouteCollection routes)
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
                    tenant = _tenantRouteConstraint,
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
                    tenant = _tenantRouteConstraint
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


}