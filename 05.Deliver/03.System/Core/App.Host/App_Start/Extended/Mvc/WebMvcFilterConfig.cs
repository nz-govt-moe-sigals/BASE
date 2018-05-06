using System;
using System.Web.Mvc;
using App.Core.Application.ErrorHandler;
using App.Core.Application.Filters.WebMvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages;

namespace App.Host.Extended.Mvc
{
    /// <summary>
    /// An <see cref="StartupExtended"/> invoked class to configure 
    /// WebMVC Filtering. This class is injected into 
    /// <see cref="WebMvcConfig"/>.
    /// <para>
    ///     Microsoft should maybe have called this MvcFilterConfig to ensure developers
    ///     did not think they could register WebAPI Filters here.
    ///     <para>
    ///         That said, do not rename it as when you add Azure App Insights it will be looking
    ///         for a class named 'FilterConfig' in order to add its Filter.
    ///         Not sure what it does if not found.
    ///     </para>
    /// </para>
    /// <para>
    /// Note that by default ASP.NET does not manage static files --  until (RAMMFAR)
    /// `configuration/system.webServer/modules @runAllManagedModulesForAllRequests = "false"`
    /// is set in the config file(`true` is the default in this app, but this hamper debugging
    /// of the first install.)
    /// </para>
    /// </summary>
    public class WebMvcFilterConfig
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IPrincipalService _principalService;
        private readonly IConfigurationStepService _configurationStepService;
        private readonly DbContexCommenttWebMvcActionFilterAttribute _dbContexCommenttWebMvcActionFilterAttribute;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebMvcFilterConfig"/> class.
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
        /// <param name="sessionOperationLogService">The session operation log service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="configurationStepService">The configuration step service.</param>
        /// <param name="dbContexCommenttWebMvcActionFilterAttribute">The database contex commentt web MVC action filter attribute.</param>
        public WebMvcFilterConfig(ISessionOperationLogService sessionOperationLogService,
            IPrincipalService principalService,
            IConfigurationStepService configurationStepService,
            DbContexCommenttWebMvcActionFilterAttribute dbContexCommenttWebMvcActionFilterAttribute)
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._principalService = principalService;
            this._configurationStepService = configurationStepService;
            this._dbContexCommenttWebMvcActionFilterAttribute = dbContexCommenttWebMvcActionFilterAttribute;
        }

        /// <summary>
        /// <para>
        /// Invoked from <see cref="WebMvcConfig.Configure"/></para>
        /// </summary>
        /// <param name="filters"></param>
        // Register MVC (not WebAPI) filters:
        public void RegisterWebMvcGlobalFilters(GlobalFilterCollection filters)
        {
            //var usingWebActivator = false;

            //Filters are processed in a certain order (by Type, then within that by Order, if defined):

            RegisterAuthenticationFilters(filters);
            RegisterActionFilters(filters);
            RegisterResponseFilters(filters);
            RegisterExceptionFilters(filters);


            // Note that neither of the above cover all cases 
            // (eg: still static file and classic webform requests will get through without
            // more work done elsewhere (earlier pipeline interception and web server Url Redirect Rules).
        }

        private void RegisterAuthenticationFilters(GlobalFilterCollection filters)
        {
            using (var elapsedTime = new ElapsedTime())
            {
            filters.Add(new WebMvcAppAuthorizeAttribute());
                this._configurationStepService
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.Green,
                        "WebMVC Filter: Authorisation",
                        $"Global Filter installed to RBAC Authenticated Users. Took {elapsedTime.ElapsedText}");
            }

        }

        private void RegisterActionFilters(GlobalFilterCollection filters)
        {
            // IMPORTANT: Notice the Order of Execution numbers added:
            using (var elapsedTime = new ElapsedTime())
            {
                filters.Add(new MyRequireHttpsWebMvcFilterAttribute(), 1);

                this._configurationStepService
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.Green,
                        "HTTPS Required (WebMVC)",
                        $"Global Filter installed to redirect HTTP requests to HTTPS. Took {elapsedTime.ElapsedText}");
            }

            using (var elapsedTime = new ElapsedTime())
            {
                filters.Add(
                    new SessionOperationWebMvcActionFilterAttribute(this._sessionOperationLogService,
                        this._principalService), 2);

                this._configurationStepService
                    .Register(
                        ConfigurationStepType.Security,
                        ConfigurationStepStatus.Green,
                        "Operation Auditing",
                        $"Global Filter installed to Audit all operations (in a general manner). Took {elapsedTime.ElapsedText}");
            }


            using (var elapsedTime = new ElapsedTime())
            {
                // NOTICE THE HIGH NUMBER:
                filters.Add(this._dbContexCommenttWebMvcActionFilterAttribute, Int32.MaxValue);

                this._configurationStepService
                    .Register(
                        ConfigurationStepType.General,
                        ConfigurationStepStatus.White,
                        "DbContext Commit at end of commands.",
                        $"Global Filter installed to automatically commit all pending changes. Took {elapsedTime}");
            }

            //NO: More securely done within Global.asax.cs: filters.Add(new ThrottleMvcActionFilterAttribute());
        }

        private static void RegisterResponseFilters(GlobalFilterCollection filters)
        {
        }
        private static void RegisterExceptionFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AiHandleErrorAttribute());
        }

    }
}