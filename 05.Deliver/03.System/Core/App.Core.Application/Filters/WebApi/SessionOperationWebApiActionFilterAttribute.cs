namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using Newtonsoft.Json;

    /// <summary>
    ///     Example Filter will intercept all MVC (not WebAPI) actions, and creates a SessionObject record
    /// that will be later saved by an Filter that runs later.
    /// <para>
    /// Filters run in the following sequence:
    /// AuthorizationFilter, ActionFilter, ResponseFilter, ExceptionFilter
    /// </para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SessionOperationWebApiActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IPrincipalService _principalService;
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IContextService _contextService;

        public SessionOperationWebApiActionFilterAttribute(IPrincipalService principalService, ISessionOperationLogService sessionOperationLogService, IDiagnosticsTracingService diagnosticsTracingService, IContextService contextService)
        {
            this._principalService = principalService;
            this._sessionOperationLogService = sessionOperationLogService;
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._contextService = contextService;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"--------------------------------------------------");
            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Request Start....");

            SessionOperation sessionOperationLog = _sessionOperationLogService.Current;
            
            sessionOperationLog.BeginDateTimeUtc = DateTime.UtcNow;
            sessionOperationLog.ClientIp = actionContext.Request.RemoteIPChain();
            sessionOperationLog.OwnerFK = this._principalService.CurrentSessionIdentifier;
            sessionOperationLog.Url = actionContext.Request.RequestUri.OriginalString;
            sessionOperationLog.ControllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            sessionOperationLog.ActionName = actionContext.ActionDescriptor.ActionName;
            sessionOperationLog.ActionArguments = "{}"; //todo: FIX this up
            /*
            sessionOperationLog.ActionArguments = JsonConvert.SerializeObject(actionContext.ActionArguments,
                Formatting.Indented, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
                */ // When using ODataQueryOptions this throws an outofmemoryException
            sessionOperationLog.ResponseCode = "-1";

            //No need to start tracking, and it is allready automatically committed when gotten.


            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            SessionOperation sessionOperation = _sessionOperationLogService.Current;

            sessionOperation.EndDateTimeUtc = DateTime.UtcNow;
            sessionOperation.Duration =
                sessionOperation.EndDateTimeUtc.Subtract(sessionOperation.BeginDateTimeUtc);


            if (actionExecutedContext.Response != null)
            {
                sessionOperation.ResponseCode = ((int) actionExecutedContext.Response.StatusCode).ToString();
            }
            else
            {
                sessionOperation.ResponseCode = "-1";
            }
            if (sessionOperation.Duration.TotalMilliseconds > 2000)
            {
                this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Operation took too long: {sessionOperation.Duration}");
            }
        }
    }
}