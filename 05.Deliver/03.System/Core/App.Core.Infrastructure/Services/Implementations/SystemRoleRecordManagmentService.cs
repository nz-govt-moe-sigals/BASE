using System;

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISystemRoleRecordManagmentService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISystemRoleRecordManagmentService" />
    public class SystemRoleRecordManagmentService : AppCoreServiceBase, ISystemRoleRecordManagmentService
    {
        private readonly IRepositoryService _repositoryService;

        public SystemRoleRecordManagmentService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }


        public SystemRole GetSystemRoleByDataStoreId(Guid id)
        {
            var result = this._repositoryService.GetSingle<SystemRole>(Constants.Db.AppCoreDbContextNames.Core, x => x.Id == id);
            return result;
        }

        public SystemRole GetByKey(string key)
        {
            var result = this._repositoryService.GetSingle<SystemRole>(Constants.Db.AppCoreDbContextNames.Core, x => x.Key == key);
            return result;
        }
    }
}
