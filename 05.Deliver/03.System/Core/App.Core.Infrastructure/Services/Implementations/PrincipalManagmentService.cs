using System;

namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Linq;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IPrincipalManagmentService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IPrincipalManagmentService" />
    public class PrincipalManagmentService : AppCoreServiceBase, IPrincipalManagmentService
    {
        private readonly IRepositoryService _repositoryService;

        public PrincipalManagmentService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }

        public Principal Get(Guid id)
        {
            Principal result = this._repositoryService.GetSingle<Principal>(Constants.Db.AppCoreDbContextNames.Core, x => x.Id == id);

            return result;
        }

        public Principal Get(string externalIdPrincipalKey)
        {
            Principal result = 
                this._repositoryService.GetSingle<Principal>(
                    Constants.Db.AppCoreDbContextNames.Core, 
                    x => x.Logins.Any(y=>y.IdPLogin == externalIdPrincipalKey));

            return result;
        }

        
    }
}
