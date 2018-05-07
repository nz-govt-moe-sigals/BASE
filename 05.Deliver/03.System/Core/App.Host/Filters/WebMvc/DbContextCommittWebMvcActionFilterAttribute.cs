using App.Core.Infrastructure.Initialization.DependencyResolution;

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
    public class DbContextCommittWebMvcActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;
        private readonly IContextService _contextService;

        public DbContextCommittWebMvcActionFilterAttribute(ISessionOperationLogService sessionOperationLogService, IContextService contextService)
        {
            this._sessionOperationLogService = sessionOperationLogService;
            this._contextService = contextService;
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
            // CHANGED:
            // See DbContext, where we are overridding SaveEvent so same purpose.
        }


        private void HackSessionLog(ResultExecutedContext filterContext)
        {
            SessionOperation sessionOperation  = this._sessionOperationLogService.Current;
            
            
            sessionOperation.EndDateTimeUtc = DateTimeOffset.UtcNow;
            sessionOperation.Duration =
                sessionOperation.EndDateTimeUtc.Subtract(sessionOperation.BeginDateTimeUtc);
            sessionOperation.ResponseCode = filterContext.HttpContext.Response.StatusCode.ToString();

        }
    }
}