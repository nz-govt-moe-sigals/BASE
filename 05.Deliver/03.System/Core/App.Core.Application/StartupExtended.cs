namespace App.Core.Application
{
    using System.Web.Mvc;
    using App.Core.Application.App_Start;
    using App.Core.Application.DependencyResolution;
    using App.Core.Application.Initialization;
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
        private readonly WebApiFilterConfig _webApiFilterConfig;
        private readonly InitializerConfig _initializerConfig;
        private readonly WebMvcConfig _webMvcConfig;

        public StartupExtended(
            ISessionOperationLogService sessionOperationLogService,
            WebMvcConfig webMvcConfig,
            WebApiFilterConfig webApiFilterConfig,
            InitializerConfig initializerConfig
        )
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._webApiFilterConfig = webApiFilterConfig;
            this._initializerConfig = initializerConfig;
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

            // Design Constraints:
            // * Startup Sequence can configure, but not access remote services:
            //   It's essential that the startup sequence does not hit the database 
            //   or any other integration service than it absolutely must. 
            //   Reasons include but are not limited to:
            //   * Slower startup(not all pages need all integration services)
            //   * You want at least some pages(eg: installation walkthroughs, 
            //     health check landing pages, etc.) to be accessible without 
            //     hitting services that might crash pages.
                
                //Enable Analytics (or not...can slow down startup):
            EnabledAnalytics.Configure(appBuilder);

            // SETUP STEP: Ensure we're using ASP.MVC v5 or later:
            var version = typeof(Controller).Assembly.GetName().Version.ToString();
            //DbContextConfig.Configure(appBuilder);
            ResponseHeaderConfig.Configure(appBuilder);
            AutoMapperConfig.Configure(appBuilder);
            DbContextConfig.Configure(appBuilder);

            // Appears correct order is to register WebMVC, then WebAPI.
            InitializeMvc(appBuilder);
            InitializeWebApi(appBuilder, this._sessionOperationLogService);

            // After routing is sorted out:
            appBuilder.UseRequestTenantMiddleware();

            // Up to this point we've not invoked external Services
            // during the startup process. Keep it that way!!!

            // TODO: Stop invoking this at startup!
            ExternalServiceInvocation(appBuilder);

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
            AuthConfig.Configure(appBuilder);

            //Invoke Service Initialization:
            this._initializerConfig.Configure(appBuilder);
        }


        private void InitializeMvc(IAppBuilder appBuilder)
        {
            this._webMvcConfig.Configure(appBuilder);
        }

        private void InitializeWebApi(IAppBuilder appBuilder,
            ISessionOperationLogService sessionOperationLogService)
        {
            // Ensure WebAPI is activated (via Microsoft.AspNet.WebApi.Owin package):
            // Not needed (also, gone in MVC 6): appBuilder.UseWebApi(httpConfiguration);
            // See: https://stackoverflow.com/a/43852361
            // Which is good, because GlobalConfiguration.Configuration seems to stops 
            // working after adding '.UseWebApi'. 
            // According to /*?*/ a common error when using OWIN in MVC is trying using
            // GlobalConfiguration.Configuration. You don't. You use a brand new one.
            // And since you're not using GlobalConfiguration.Configuration, you don't use
            // GlobalConfiguraiton.Configure(...) either. 

            var httpConfiguration = HttpConfigurationLocator.Current;
        
            //GlobalConfiguration.Configure(httpConfiguration =>
            //{ 
            StaticFileHandlingConfig.Configure(httpConfiguration);
            WebApiCorsConfig.Configure(httpConfiguration);
            WebApiJsonSerializerConfig.Configure(httpConfiguration);
            WebApiConfig.Configure(httpConfiguration);

            this._webApiFilterConfig.RegisterGlobalFilters(httpConfiguration, sessionOperationLogService);

            //Since we're not using GlobalConfiguration, we also have to do what
            // StructureMapWebApi is going to do.
            var container = StructuremapMvc.StructureMapDependencyScope.Container;
            httpConfiguration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);

            // Note that the original GlobalConfiguration.Configure(..)
            // method invokes EnsureInitialized when done, which happens 
            // to not care if it invoked multiple times:
            httpConfiguration.EnsureInitialized();
            //});


            appBuilder.UseWebApi(httpConfiguration);

            
        }
    }
}