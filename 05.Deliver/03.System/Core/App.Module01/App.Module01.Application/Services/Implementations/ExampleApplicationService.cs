namespace App.Module01.Application.Services.Implementations
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Services;
    using App.Module01.Shared.Models.Entities;

    public class ExampleApplicationService : IExampleApplicationService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IRepositoryService _repositoryService;

        public ExampleApplicationService(IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._repositoryService = repositoryService;
        }

        public DbSet<Example> GetQueryableSet(string contextKey)
        {
            return this._repositoryService.GetQueryableSet<Example>(contextKey) as DbSet<Example>;
        }

        public void Add(Example example)
        {
            var check = this._repositoryService.HasChanges(null);
            this._repositoryService.AddOnCommit(null, example);
            var check2 = this._repositoryService.HasChanges(null);
        }

        public void Delete(Example example)
        {
            this._repositoryService.DeleteOnCommit(null, example);
        }
    }
}