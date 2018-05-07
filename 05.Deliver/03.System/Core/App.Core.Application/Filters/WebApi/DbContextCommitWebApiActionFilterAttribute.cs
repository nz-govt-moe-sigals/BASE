namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Web;
    using System.Web.Http.Filters;
    using App.Core.Infrastructure;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DbContextCommitWebApiActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IContextService _contextService;

        public DbContextCommitWebApiActionFilterAttribute(IDiagnosticsTracingService diagnosticsTracingService, ISessionOperationLogService sessionOperationLogService, IContextService contextService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._sessionOperationLogService = sessionOperationLogService;
            this._contextService = contextService;
        }

        /// <summary>
        ///     Occurs after the action method is invoked.
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // Notes:
            // Being a System.Web.Http.Filters based, this Filter will only work for WebAPI/OData 
            // controller calls -- you need another filter based on the Mvc namespaces, in order 
            // to handle the MVC Controllers.
            // 
            // In case you are wondering -- don't need to override the async version
            // of this method (OnActionExecuted) as it will be invoking this method anyway.

            HackSessionLog(actionExecutedContext);
            
            TOMOVE.DoWork(actionExecutedContext.Exception);


            base.OnActionExecuted(actionExecutedContext);

            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Request End.");
            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"--------------------------------------------------");
        }



        private void HackSessionLog(HttpActionExecutedContext actionExecutedContext)
        {

            SessionOperation sessionOperation  = _sessionOperationLogService.Current;
            

            sessionOperation.EndDateTimeUtc = DateTimeOffset.UtcNow;
            sessionOperation.Duration =
                sessionOperation.EndDateTimeUtc.Subtract(sessionOperation.BeginDateTimeUtc);
            sessionOperation.ResponseCode = HttpContext.Current.Response.StatusCode.ToString();
        }
    }
}