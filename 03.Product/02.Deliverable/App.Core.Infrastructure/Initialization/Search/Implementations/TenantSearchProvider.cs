
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

    [Key("Tenant")]
    public class TenantSearchProvider : SearchProviderBase<Tenant>
    {
        public TenantSearchProvider(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService) : base(diagnosticsTracingService,
            principalService, repositoryService)
        {
            
        }

        public override IQueryable<SearchResponseItem> Search(string searchTerm)
        {

            var items =
                this._repositoryService.GetByFilter<Tenant>(Constants.Db.AppCoreDbContextNames.Core,
                x => x.DisplayName.Contains(searchTerm))
                .Include(x=>x.Claims)
                .Include(x=>x.Properties);

            //Do it in two steps to return an IQqueryable:
            var results =
                items.Select(x=>new SearchResponseItem()
                    {
                        TypeKey = "Tenant",
                        TypeId = x.Id.ToString(),
                        Title = x.DisplayName,
                        Description = x.Properties.SingleOrDefault(y => y.Key == "Description").Value
                    });
            
            return results;
        }
    }
}
