namespace App.Core.Application.Extended
{
    using System.Web.Http;
    using System.Web.Http.Filters;
    using App.Core.Application.Filters.WebApi;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// WebApi Filters.
    /// <para>
    /// Note that by default ASP.NET does not manage static files --  until (RAMMFAR)
    /// `configuration/system.webServer/modules @runAllManagedModulesForAllRequests = "false"`
    /// is set in the config file(`true` is the default in this app, but this hamper debugging
    /// of the first install.)
    /// </para>
    /// </summary>
    public class WebApiFilterConfig
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IPrincipalService _principalService;
        private readonly IConfigurationStepService _configurationStepService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiFilterConfig"/> class.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="sessionOperationLogService">The session operation log service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="configurationStepService">The configuration step service.</param>
        public WebApiFilterConfig(
            ISessionOperationLogService sessionOperationLogService, 
            IPrincipalService principalService, 
            IConfigurationStepService configurationStepService)
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._principalService = principalService;
            this._configurationStepService = configurationStepService;
        }

        /// <summary>
        /// Registers the global WebApi filters.
        /// <para>
        /// Invoked from <see cref="StartupExtended.Configure"/>.
        /// </para>
        /// </summary>
        /// <param name="httpConfiguration">The HTTP configuration.</param>
        /// <param name="sessionOperationLogService">The session operation log service.</param>
        public void RegisterGlobalFilters(HttpConfiguration httpConfiguration,
            ISessionOperationLogService sessionOperationLogService)
        {
            // Since WebAPI pipeline is totally separate from WebMVC, the registrarion
            // of the WebAPI interception is done in a different way.
            // WebAPI Controllers are registered using HttpConfiguration:

            var filters = httpConfiguration.Filters;

            //Filters are processed in a certain order (by Type, then within that by Order, if defined):

            RegisterAuthenticationFilters(filters);
            RegisterActionFilters(filters);
            RegisterResponseFilters(filters);
            RegisterExceptionFilters(filters);

            //NO: More securely done within Global.asax.cs: filters.Add(new ThrottleWebApiActionFilterAttribute());
        }



        void RegisterAuthenticationFilters(HttpFilterCollection filters)
        {
        }

        void RegisterActionFilters(HttpFilterCollection filters)
        {
            using (var elapsedTime = new ElapsedTime())
            {

                // A difference between MVC and WebAPI Filters is that you cannot specify order
                // But inspecting the framework's code it *appears* to be run in the order they 
                // are added.

                filters.Add(
                    new SessionOperationWebApiActionFilterAttribute(
                        this._principalService,
                        this._sessionOperationLogService
                    ));


                // Apply a custom Filter to intercept WebAPI requests and return errors (no redirection).
                filters.Add(new RequireHttpsWebApiFilterAttribute());
                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.Green,
                        "HTTPS Required (WebAPI)",
                        "WebAPI Filter installed to redirect HTTP requests to HTTPS.");


                // LAST!!!!
                filters.Add(new DbContextCommitWebApiActionFilterAttribute(this._sessionOperationLogService));

                AppDependencyLocator.Current.GetInstance<IConfigurationStepService>()
                    .Register(
                        ConfigurationStepType.General,
                        ConfigurationStepStatus.White,
                        "DbContext Commit at end of commands.",
                        $"WebApi Filter installed to automatically commit all pending changes. Took {elapsedTime.ElapsedText}");
            }
        }

        private static void RegisterResponseFilters(HttpFilterCollection filters)
        {
        }

        private static void RegisterExceptionFilters(HttpFilterCollection filters)
        {
        }
    }

}