using System;
using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using Newtonsoft.Json;

namespace App.Host.Filters.WebMvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SessionOperationWebMvcActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IPrincipalService _principalService;
        private readonly ISessionManagmentService _sessionManagmentService;

        public SessionOperationWebMvcActionFilterAttribute(IDiagnosticsTracingService diagnosticsTracingService, ISessionManagmentService sessionManagmentService,
            ISessionOperationLogService sessionOperationLogService, IPrincipalService principalService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._sessionOperationLogService = sessionOperationLogService;
            this._principalService = principalService;
            _sessionManagmentService = sessionManagmentService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Filters are shared across requests, so save variables within the Request context to  pass between methods:

            SessionOperation sessionOperation = _sessionOperationLogService.Current;
            //sessionOperation.SessionFK = this._principalService.CurrentSessionIdentifier;
            sessionOperation.BeginDateTimeUtc = DateTime.UtcNow;
            sessionOperation.ClientIp = filterContext.RequestContext.HttpContext.Request.RemoteIPChain();
            sessionOperation.Url = filterContext.RequestContext.HttpContext.Request.RawUrl;
            sessionOperation.ControllerName =
                filterContext.ActionDescriptor.ControllerDescriptor
                    .ControllerName; //filterContext.RouteData.Values["controller"] as string;
            sessionOperation.ActionName =
                filterContext.ActionDescriptor.ActionName; //filterContext.RouteData.Values["action"] as string;
            sessionOperation.ResponseCode = "-1";
            try
            {
                sessionOperation.ActionArguments = JsonConvert.SerializeObject(filterContext.ActionParameters,
                    Formatting.Indented,
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            }
            catch
            {
                sessionOperation.ActionArguments = "ERROR";
            }

            
            //PS: No need to AddOnCommit the entity, as it's already been done by the original Current property...

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            SessionOperation sessionOperation = _sessionOperationLogService.Current;
           
            //Record the HTTP response code (should be 200 everytime, right?)
            sessionOperation.ResponseCode = filterContext.HttpContext.Response.StatusCode.ToString();

            //Record end, and duration:
            sessionOperation.EndDateTimeUtc = DateTimeOffset.UtcNow;

            sessionOperation.Duration =
                sessionOperation.EndDateTimeUtc.Subtract(sessionOperation.BeginDateTimeUtc);


            _sessionManagmentService.SaveSessionOperationAsync(sessionOperation, _principalService);

            //if (sessionOperation.Duration.TotalMilliseconds > 2000)
            //{
            // this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Operation took too long: {sessionOperation.Duration}");   
            //}


            //var msg = "Invoked:";

            //Log(msg);
        }

        //private static void Log(string msg)
        //{
        //    var diagnosticsTracingService =
        //        AppDependencyLocator.Current.GetInstance<IDiagnosticsTracingService>();
        //    diagnosticsTracingService.Trace(TraceLevel.Info, msg);
        //}
    }
}