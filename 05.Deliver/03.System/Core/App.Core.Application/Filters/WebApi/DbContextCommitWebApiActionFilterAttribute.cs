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
                if (ShouldSave(dbContext, actionExecutedContext))
                {
                    PreprocessModelsBeforeSaving(dbContext);
                    dbContext.SaveChanges();
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }

        //dont want it to try save if there is an exception unless it is core
        //because core does some sort of save every time?
        private bool ShouldSave(DbContext dbContext, HttpActionExecutedContext actionExecutedContext)
        {
            return dbContext.ChangeTracker.HasChanges() &&
                   (actionExecutedContext.Exception == null || dbContext.GetType() == typeof(App.Core.Infrastructure.Db.Context.AppCoreDbContext));
        }

        private void PreprocessModelsBeforeSaving(DbContext dbContext)
        {
            // Complete models (eg: fill in CurrentUser, CreateDateTimeUtc, fields, etc.)
            // CHANGED:
            // See DbContext, where we are overridding SaveEvent so same purpose.
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