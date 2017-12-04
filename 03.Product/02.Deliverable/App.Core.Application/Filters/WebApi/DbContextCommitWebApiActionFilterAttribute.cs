namespace App.Core.Application.Filters.WebApi
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http.Filters;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DbContextCommitWebApiActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;

        public DbContextCommitWebApiActionFilterAttribute(ISessionOperationLogService sessionOperationLogService)
        {
            this._sessionOperationLogService = sessionOperationLogService;
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


            // Get Current DbContext
            foreach (DbContext dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
            {
                var shouldSave = dbContext.ChangeTracker.HasChanges();
                if (shouldSave)
                {
                    PreprocessModelsBeforeSaving(dbContext);
                    dbContext.SaveChanges();
                    var check = true;
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }

        private void PreprocessModelsBeforeSaving(DbContext dbContext)
        {
            // Complete models (eg: fill in CurrentUser, CreateDateTimeUtc, fields, etc.)
        }

        private void HackSessionLog(HttpActionExecutedContext actionExecutedContext)
        {
            
            var sessionOperationLog = _sessionOperationLogService.Current;
            

            sessionOperationLog.EndDateTimeUtc = DateTimeOffset.UtcNow;
            sessionOperationLog.Duration =
                sessionOperationLog.EndDateTimeUtc.Subtract(sessionOperationLog.BeginDateTimeUtc);
            sessionOperationLog.ResponseCode = HttpContext.Current.Response.StatusCode.ToString();
        }
    }
}