namespace App.Module33.Application.Services.Implementations
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Services;
    using App.Module33.Shared.Models.Entities;

    public class CommunityApplicationService : ICommunityApplicationService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IRepositoryService _repositoryService;

        public CommunityApplicationService(IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._repositoryService = repositoryService;
        }

        public DbSet<Community> GetQueryableSet(string contextKey)
        {
            return this._repositoryService.GetQueryableSet<Community>(contextKey) as DbSet<Community>;
        }

        public void Add(Community community)
        {
            var check = this._repositoryService.HasChanges(null);
            this._repositoryService.AddOnCommit(null, community);
            var check2 = this._repositoryService.HasChanges(null);
        }

        public void Delete(Community community)
        {
            this._repositoryService.DeleteOnCommit(null, community);
        }
    }
}

