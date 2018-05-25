
namespace App.Core.Infrastructure.Initialization.Search.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;
    using App.Module02.Infrastructure.Constants.Db;
    using App.Module02.Shared.Models.Entities;

    [Key("Example")]
    public class ExampleSearchProvider : SearchProviderBase<AccountRoleGroup>
    {
        public ExampleSearchProvider(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService) : base(diagnosticsTracingService,
            principalService, repositoryService)
        {
            
        }

        public override IQueryable<SearchResponseItem> Search(string searchTerm)
        {
            var items =
                    this._repositoryService.GetByFilter<AccountRoleGroup>(AppModuleDbContextNames.Default,
                        x => x.Title.Contains(searchTerm))
                ;

            //Do it in two steps to return an IQqueryable:
            var results =
                items.Select(x => new SearchResponseItem()
                {
                    TypeKey = "AccountGroup",
                    TypeId = x.Id.ToString(),
                    Title = x.Title,
                    Description = "..."
                });

            return results;
        }
    }
}


