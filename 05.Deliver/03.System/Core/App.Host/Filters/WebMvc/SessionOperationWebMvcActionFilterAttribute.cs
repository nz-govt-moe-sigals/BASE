using App.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Core.Application.Filters.WebMvc
{
    using System;
    using System.Web.Mvc;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using Newtonsoft.Json;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SessionOperationWebMvcActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IPrincipalService _principalService;

        public SessionOperationWebMvcActionFilterAttribute(ISessionOperationLogService sessionOperationLogService, IPrincipalService principalService )
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._principalService = principalService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Filters are shared across requests, so save variables within the Request context to  pass between methods:

            var sessionOperationLog = this._sessionOperationLogService.Current;

            sessionOperationLog.BeginDateTimeUtc = DateTime.UtcNow;
            sessionOperationLog.OwnerFK = this._principalService.CurrentSessionIdentifier;
            sessionOperationLog.ClientIp = filterContext.RequestContext.HttpContext.Request.RemoteIPChain();
            sessionOperationLog.Url = filterContext.RequestContext.HttpContext.Request.RawUrl;
            sessionOperationLog.ControllerName =
                filterContext.ActionDescriptor.ControllerDescriptor
                    .ControllerName; //filterContext.RouteData.Values["controller"] as string;
            sessionOperationLog.ActionName =
                filterContext.ActionDescriptor.ActionName; //filterContext.RouteData.Values["action"] as string;
            sessionOperationLog.ResponseCode = "-1";
            try
            {
                sessionOperationLog.ActionArguments = JsonConvert.SerializeObject(filterContext.ActionParameters,
                    Formatting.Indented,
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            }
            catch
            {
                sessionOperationLog.ActionArguments = "ERROR";
            }

            
            //PS: No need to AddOnCommit the entity, as it's already been done by the original Current property...

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            var sessionOperationLog = this._sessionOperationLogService.Current;

 

            sessionOperationLog.EndDateTimeUtc = DateTimeOffset.UtcNow;
            sessionOperationLog.Duration =
                sessionOperationLog.EndDateTimeUtc.Subtract(sessionOperationLog.BeginDateTimeUtc);
            sessionOperationLog.ResponseCode = filterContext.HttpContext.Response.StatusCode.ToString();

            var msg = "Ivoked:";

            Log(msg);
        }

        private static void Log(string msg)
        {
            var diagnosticsTracingService =
                AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>();
            diagnosticsTracingService.Trace(TraceLevel.Info, msg);
        }
    }
}