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

        public SessionOperationWebApiActionFilterAttribute(IPrincipalService principalService, ISessionOperationLogService sessionOperationLogService)
        {
            this._principalService = principalService;
            this._sessionOperationLogService = sessionOperationLogService;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            var sessionOperationLog = _sessionOperationLogService.Current;

            sessionOperationLog.BeginDateTimeUtc = DateTime.UtcNow;
            sessionOperationLog.ClientIp = actionContext.Request.RemoteIPChain();
            sessionOperationLog.OwnerFK = this._principalService.CurrentSessionIdentifier;
            sessionOperationLog.Url = actionContext.Request.RequestUri.OriginalString;
            sessionOperationLog.ControllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            sessionOperationLog.ActionName = actionContext.ActionDescriptor.ActionName;
            sessionOperationLog.ActionArguments = JsonConvert.SerializeObject(actionContext.ActionArguments,
                Formatting.Indented, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

            //No need to start tracking, and it is allready automatically committed when gotten.


            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var sessionOperationLog = this._sessionOperationLogService.Current;

            sessionOperationLog.EndDateTimeUtc = DateTime.UtcNow;
            sessionOperationLog.Duration =
                sessionOperationLog.EndDateTimeUtc.Subtract(sessionOperationLog.BeginDateTimeUtc);
            if (actionExecutedContext.Response != null)
            {
                sessionOperationLog.ResponseCode = ((int) actionExecutedContext.Response.StatusCode).ToString();
            }
            else
            {
                sessionOperationLog.ResponseCode = "-1";
            }
        }
    }
}