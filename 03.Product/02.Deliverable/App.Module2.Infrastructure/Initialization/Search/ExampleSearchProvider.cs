
namespace App.Module2.Infrastructure.Initialization.Search
{
    using System.Linq;
    using App.Core.Infrastructure.Initialization.Search.Implementations;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Attributes;
    using App.Core.Shared.Models.Messages;
    using App.Module2.Infrastructure.Constants.Db;
    using App.Module2.Shared.Models.Entities;

    [Key("Example")]
    public class SchoolSearchProvider : SearchProviderBase<EducationOrganisation>
    {
        public SchoolSearchProvider(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService) : base(diagnosticsTracingService,
            principalService, repositoryService)
        {
            
        }

        public override IQueryable<SearchResponseItem> Search(string searchTerm)
        {
            var items =
                    this._repositoryService.GetByFilter<EducationOrganisation>(AppModule2DbContextNames.Module2,
                        x => x.Organisation.Name.Contains(searchTerm))
                ;

            //Do it in two steps to return an IQqueryable:
            var results =
                items.Select(x => new SearchResponseItem()
                {
                    TypeKey = "EducationOrganisation",
                    TypeId = x.Id.ToString(),
                    Title = x.Organisation.Name,
                    Description = x.Description
                });

            return results;
        }
    }
}
