namespace App.Core.Application.Filters.WebMvc
{
    using System;
    using System.Data.Entity;
    using System.Web.Mvc;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     An Filter for MVC Controllers (not WebAPI)
    ///     that will ensure that the DbContext is committed at the end of the request --
    ///     but only if there is something to commit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DbContexCommenttWebMvcActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;

        public DbContexCommenttWebMvcActionFilterAttribute(ISessionOperationLogService sessionOperationLogService)
        {
            this._sessionOperationLogService = sessionOperationLogService;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            HackSessionLog(filterContext);

            //Get Current DbContext
            foreach (DbContext dbContext in AppDependencyLocator.Current.GetAllInstances<DbContext>())
            {
                var shouldSave = dbContext.ChangeTracker.HasChanges();
                if (shouldSave)
                {
                    PreprocessModelsBeforeSaving(dbContext);
                    dbContext.SaveChanges();
                    //var check = true;
                }
            }
            base.OnResultExecuted(filterContext);
        }

        private void PreprocessModelsBeforeSaving(DbContext dbContext)
        {
            // Complete models (eg: fill in CurrentUser, CreateDateTimeUtc, fields, etc.)
        }


        private void HackSessionLog(ResultExecutedContext filterContext)
        {
            var sessionOperationLog = this._sessionOperationLogService.Current;

            sessionOperationLog.EndDateTimeUtc = DateTimeOffset.UtcNow;
            sessionOperationLog.Duration =
                sessionOperationLog.EndDateTimeUtc.Subtract(sessionOperationLog.BeginDateTimeUtc);
            sessionOperationLog.ResponseCode = filterContext.HttpContext.Response.StatusCode.ToString();

        }
    }
}