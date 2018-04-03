namespace App.Core.Infrastructure.Services.Implementations
{
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

        private SessionOperation C
        {
            get { return this._contextService.Get(AppContextKeys.SessionOperation) as SessionOperation; }
            set { this._contextService.Set(AppContextKeys.SessionOperation, value); }

        }


        public SessionOperation Current
        {
            get
            {
                if (this.C  == null)
                {
                    this.C = new SessionOperation();
                    this._repositoryService.AddOnCommit(AppCoreDbContextNames.Core, this.C);
                }
                return this.C;
            }
        }

    }
}