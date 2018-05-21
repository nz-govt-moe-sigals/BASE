namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Collections.Generic;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Context;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISessionOperationLogService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISessionOperationLogService" />
    public class SessionOperationLogService : AppCoreServiceBase, ISessionOperationLogService
    {
        private readonly IContextService _contextService;
        private readonly IRepositoryService _repositoryService;
 
        public SessionOperationLogService(IContextService contextService, IRepositoryService repositoryService)
        {
            this._contextService = contextService;
            this._repositoryService = repositoryService;
        }



        public SessionOperation Current
        {
            get
            {
                var r = this._contextService.Get(AppContextKeys.SessionOperation) as SessionOperation;

                if (r != null)
                {
                    return r;
                }

                r = new SessionOperation();
                this._contextService.Set(AppContextKeys.SessionOperation, r);
                this._repositoryService.AddOnCommit(AppCoreDbContextNames.Core, r);

                return r;
            }
        }
        public object GetDetail(string key)
        {
            var d = CurrentDetails;
            object r;
            if (d.TryGetValue(key, out r))
            {
                return r;
            }
            return null;
        }
        public void SetDetail(string key, object value)
        {
            var d = CurrentDetails;
            d[key] = value;
        }
        public void IncrementDetail(string key)
        {
            var d = CurrentDetails;
            object r;
            if (d.TryGetValue(key, out r))
            {
                r = ((int)r)+1;
                return;
            }
            d[key] = 1;
        }


        public Dictionary<string,object> CurrentDetails
        {
            get
            {
                var r = this._contextService.Get(AppContextKeys.SessionOperationDetails) as Dictionary<string,object>;
                if (r != null)
                {
                    return r;
                }
                r = new Dictionary<string,object>();
                this._contextService.Set(AppContextKeys.SessionOperationDetails, r);
                return r;
            }

        }
    }
}