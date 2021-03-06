using App.Core.Application.Initialization;
using App.Core.Infrastructure.Initialization.DependencyResolution;
using App.Host.Extended;
using App.Host.Extended.Mvc;
using App.Host.Extended.WebApi;
using App.Host.Middleware;

namespace App.Host
{
    using System.Web.Mvc;
    using App.Core.Infrastructure.Services;
    using Owin;

    /// <summary>
    /// <see cref="StartupExtended"/>
    /// is a DependencyInjectable equivalent to
    /// the default <see cref="Startup"/>.
    /// <para>
    /// Invoked from the more prosaic 
    /// <see cref="Startup.Configuration"/>
    /// after DependencyInjection has been initialized.
    /// </para>
    /// </summary>
    public class StartupExtended
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly InitializerConfig _initializerConfig;
        private readonly WebApiConfig _webApiConfig;
        private readonly AuthConfig _authConfig;
        private readonly WebMvcConfig _webMvcConfig;

        public StartupExtended(
            ISessionOperationLogService sessionOperationLogService,
            WebMvcConfig webMvcConfig,
            InitializerConfig initializerConfig,
            WebApiConfig webApiConfig,
            AuthConfig authConfig
        )
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._initializerConfig = initializerConfig;
            this._webApiConfig = webApiConfig;
            this._authConfig = authConfig;
            this._webMvcConfig = webMvcConfig;
        }

        /// <summary>
        /// Configures the specified application builder.
        /// <para>
        /// Invoked from <see cref="Startup"/>.
        /// </para>
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public void Configure(IAppBuilder appBuilder) {


            // var token = new msiTokenRetrievalFromDev().DoAsync().Result;

            // Design Constraints:
            // * Startup Sequence can configure, but not access remote services:
            //   It's essential that the startup sequence does not hit the database 
            //   or any other integration service than it absolutely must. 
            //   Reasons include but are not limited to:
            //   * Slower startup(not all pages need all integration services)
            //   * You want at least some pages(eg: installation walkthroughs, 
            //     health check landing pages, etc.) to be accessible without 
            //     hitting services that might crash pages.

            // Enable Analytics (or not...can slow down startup):
            // And note that this will be the first call to Azure (for KeyStore service):
            // Can easily take 5 to 13 seconds.
            AppDependencyLocator.Current.GetInstance<EnabledAnalytics>().Configure(appBuilder);

            // SETUP STEP: Ensure we're using ASP.MVC v5 or later:
            var version = typeof(Controller).Assembly.GetName().Version.ToString();
            //DbContextConfig.Configure(appBuilder);
            AppDependencyLocator.Current.GetInstance<ResponseHeaderConfig>().Configure(appBuilder);
            AppDependencyLocator.Current.GetInstance<AutoMapperConfig>().Configure(appBuilder);
            AppDependencyLocator.Current.GetInstance<DbContextConfig>().Configure(appBuilder);




            // Appears correct order is to register WebMVC, then WebAPI.
            InitializeMvc(appBuilder);
            InitializeWebApi(appBuilder);



            // After routing is sorted out, invoke our extension method
            // to attach custom OWIN Middleware.
            // One of the Midddlewares (ie Modules) 
            // that this will attached is one that 
            // Sets the Tenancy.
            appBuilder.UseRequestTenantMiddleware();

            // Up to this point we've not invoked external Services
            // during the startup process. Keep it that way!!!

            // TODO: Stop invoking this at startup!
            ExternalServiceInvocation(appBuilder);

            // Ensure WebAPI is activated (via Microsoft.AspNet.WebApi.Owin package):
            // Not needed (also, gone in MVC 6): appBuilder.UseWebApi(httpConfiguration);
            // See: https://stackoverflow.com/a/43852361
            // Which is good, because GlobalConfiguration.Configuration seems to stops 
            // working after adding '.UseWebApi'. 
            appBuilder.UseWebApi(HttpConfigurationLocator.Current);
        }


        // TODO: Stop invoking this at startup!
        void ExternalServiceInvocation(IAppBuilder appBuilder)
        {
            // This is the type of shit that should *not* be invoked 
            // during startup, and wait till a page that needs it
            // invokes it.
            // Faster startup, and no yellow screen that can't be easily diagnosed.

            // This kind of stuff feels useful when developing, but always comes 
            // back to bite you.

            //TODO: This triggers requests to a remote server during bootstrap...
            // contrary to design principles, and should be
            // moved to later
            _authConfig.Configure(appBuilder);

            //Invoke Service Initialization:
            this._initializerConfig.Configure(appBuilder);
        }


        private void InitializeMvc(IAppBuilder appBuilder)
        {
            this._webMvcConfig.Configure(appBuilder);
        }

        private void InitializeWebApi(IAppBuilder appBuilder)
        {
            _webApiConfig.Configure(appBuilder);            
        }
    }
}