namespace App.Core.Application
{
    using System.Web.Mvc;
    using App.Core.Application.App_Start;
    using App.Core.Application.DependencyResolution;
    using App.Core.Application.Initialization;
    using App.Core.Infrastructure.Services;
    using Owin;

    public class Startup
    {
        // The OWIN middleware will invoke this method when the app starts
        // because it's called Configuration, within a class called Startup
        // within the Assembly's default namespace.
        // Or you can use [assembly: OwinStartup(typeof(StartupDemo.TestStartup))]
        // within AssemblyInfo.cs
        // See: https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-startup-class-detection
        // IMPORTANT: Also, requires  Microsoft.Owin.Host.SystemWeb.dll or else won't be invoked.
        public void Configuration(IAppBuilder appBuilder)
        {
            //Sometimes Required: LoadAllAssembliesConfig.Configure(appBuilder);

            // SETUP STEP: Initialize Common ServiceLocator, early (after ensuring it will find all assemblies):
            ServiceLocatorConfig.Configure(appBuilder);

            // Use Service Locator to build injection right from the start:
            AppDependencyLocator.Current.GetInstance<ExtendedStartup>().Configure(appBuilder);

        }
    }

    public class ExtendedStartup
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly WebApiFilterConfig _webApiFilterConfig;
        private readonly WebMvcConfig _webMvcConfig;

        public ExtendedStartup(
            ISessionOperationLogService sessionOperationLogService,
            WebMvcConfig webMvcConfig,
            WebApiFilterConfig webApiFilterConfig 
            )
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._webApiFilterConfig = webApiFilterConfig;
            this._webMvcConfig = webMvcConfig;
        }

        public void Configure(IAppBuilder appBuilder) { 

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

            //This triggers requests to a remote server:
            AuthConfig.Configure(appBuilder);
        }

        public void InitializeMvc(IAppBuilder appBuilder)
        {
            _webMvcConfig.Configure(appBuilder);
        }

        public void InitializeWebApi(IAppBuilder appBuilder,
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

            _webApiFilterConfig.RegisterGlobalFilters(httpConfiguration, sessionOperationLogService);

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