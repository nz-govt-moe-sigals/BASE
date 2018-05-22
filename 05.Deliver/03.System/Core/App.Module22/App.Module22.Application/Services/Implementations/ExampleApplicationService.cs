namespace App.Module22.Application.Services.Implementations
{
    using System.Data.Entity;
    using App.Core.Infrastructure.Services;
    using App.Module22.Shared.Models.Entities;

    public class CourseApplicationService : ICourseApplicationService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IRepositoryService _repositoryService;

        public CourseApplicationService(IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._repositoryService = repositoryService;
        }

        public DbSet<Course> GetQueryableSet(string contextKey)
        {
            return this._repositoryService.GetQueryableSet<Course>(contextKey) as DbSet<Course>;
        }

        public void Add(Course example)
        {
            var check = this._repositoryService.HasChanges(null);
            this._repositoryService.AddOnCommit(null, example);
            var check2 = this._repositoryService.HasChanges(null);
        }

        public void Delete(Course example)
        {
            this._repositoryService.DeleteOnCommit(null, example);
        }
    }
}

