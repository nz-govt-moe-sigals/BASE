namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISecureDataTokenService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISecureDataTokenService" />
    public class SecureDataTokenService : AppCoreServiceBase, ISecureDataTokenService
    {
        private readonly IRepositoryService _repositoryService;

        public SecureDataTokenService(IRepositoryService repositoryService)
        {
            this._repositoryService = repositoryService;
        }

        public string Get(Guid tokenKey)
        {
            var result = this._repositoryService.GetSingle<DataToken>(AppCoreDbContextNames.Core, x => x.Id == tokenKey)?.Value;

            return result;
        }

        public string Save(string value)
        {
            var dataToken = new DataToken();
            dataToken.Value = value;
            this._repositoryService.AddOnCommit(AppCoreDbContextNames.Core, dataToken);

            return dataToken.Id.ToString("D").ToLower();
        }
    }
}