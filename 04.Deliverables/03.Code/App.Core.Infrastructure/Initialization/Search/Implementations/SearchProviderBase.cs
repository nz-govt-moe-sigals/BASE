namespace App.Core.Infrastructure.Initialization.Search.Implementations
{
    using System.Linq;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    public abstract class SearchProviderBase<TModel> : ISearchProvider 
        where TModel : class, new()
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;
        protected readonly IRepositoryService _repositoryService;

        protected SearchProviderBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._principalService = principalService;
            this._repositoryService = repositoryService;
        }

        public abstract IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}