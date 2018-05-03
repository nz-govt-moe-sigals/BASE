namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.OData;
    using System.Web.OData.Routing;
    using App.Core.Infrastructure.Initialization.Search;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    [ODataRoutePrefix("search")]
    public class SearchController : ODataControllerBase
    {
        private readonly IObjectMappingService _objectMappingService;

        public SearchController(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IObjectMappingService objectMappingService) : base(diagnosticsTracingService, principalService)
        {
            this._objectMappingService = objectMappingService;
        }



        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        [EnableQuery(PageSize = 100)]
        public IQueryable<SearchResponseItemDto> Get(string types, string searchTerm)
        {
            var results = new List<SearchResponseItemDto>();
            if (searchTerm == null)
            {
                return results.AsQueryable();
            }
            searchTerm = searchTerm.Trim();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return results.AsQueryable();
            }

            if ((string.IsNullOrWhiteSpace(types)) || (types == "undefined"))
            {
                types = "*";
            }
            types = types.ToLower().Trim();


            if (types == "*")
            {
                AppDependencyLocator.Current.GetAllInstances<ISearchProvider>()
                    .ForEach(x =>
                    {
                        foreach (var searchResponseItem in x.Search(searchTerm))
                        {
                            results.Add(
                                _objectMappingService
                                    .Map<SearchResponseItem, SearchResponseItemDto>(searchResponseItem));
                        }
                    });
            }
            else
            {
                //TODO: Naive split needs quotation handling.
                var typesList = types.Split(new char[] {',', ';', '|'});

                typesList.ForEach(t =>
                {
                    var x = AppDependencyLocator.Current.GetInstance<ISearchProvider>(t);
                    foreach (var searchResponseItem in x.Search(searchTerm))
                    {
                        results.Add(
                            this
                            ._objectMappingService
                            .Map<SearchResponseItem, SearchResponseItemDto>(searchResponseItem));
                    }
                });
            }

            return results.AsQueryable();

        }
    }
}