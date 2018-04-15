namespace App.Module3.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Module3.Application.Services;
    using App.Module3.Shared.Configuration.Models;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    /// <summary>
    ///     An example of a classic WebAPI, with DI in the constructor,
    ///     using an orm accessed db to hold a list of Example items
    ///     and applying Bearer token validation.
    ///     Same as Example3, but demonstrating the using of versionable and maintainable DTOs
    ///     <para>
    ///         Things to notice:
    ///         * We're exposing ExampleDTO (not the Example entity directly). An API is a contract. Once exposed
    ///         you can't just go change your Db schema (and therefore app entities) whenever you feel like and
    ///         break your API clients. Hence the mapping to a DTO that is fixed. At least for an API version.
    ///         Once mapping is in place, you can safely maintain your app, while keeping your word/contract.
    ///         * DbContext is injected (in a perfect world, this would be a RepositoryService that wraps it).
    ///         * The Context is not submitted. Just concentrate on doing work, not saving it, and the framework
    ///         will handle it transparently, as late as possible in order to diminish the number of commits
    ///         as well as be stuck in a position that not everything can be committed.
    ///     </para>
    /// </summary>
    [Authorize]
    public class Example5Controller : ApiControllerBase
    {
        private readonly ExampleApiConfiguration _apiConfiguration;
        private readonly IExampleApplicationService _exampleApplicationService;
        private readonly IHostSettingsService _hostSettingsService;
        private readonly IObjectMappingService _objectMappingService;

        public Example5Controller(IPrincipalService principalsService,
            IHostSettingsService hostSettingsService, IObjectMappingService objectMappingService,
            IExampleApplicationService exampleApplicationService) : base(principalsService)
        {
            this._hostSettingsService = hostSettingsService;
            this._objectMappingService = objectMappingService;
            this._exampleApplicationService = exampleApplicationService;

            this._apiConfiguration = this._hostSettingsService
                .GetObject<ExampleApiConfiguration>("bearerTokenAuth:"); //"cookieAuth:" or "bearerTokenAuth:"
        }

        //[EnableQuery(PageSize = 100)]
        public IEnumerable<ExampleDto> Get()
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleReadScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            return this._exampleApplicationService
                    .GetQueryableSet(null)
                    //Note how to filter on something that is not available via Dto:
                    .Where(x => x.Owner == owner)
                    .ProjectTo<ExampleDto>( /* as well as anything else*/)
                /*plus any OData source criteria on the Queryable result*/
                ;
        }

        public void Post(ExampleDto example)
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleWriteScope);
            // Validate payload:
            if (string.IsNullOrEmpty(example.PublicText))
            {
                throw new WebException("Please provide a example description");
            }
            //As you're saving, fill in some fields, for later filtering against:

            var exampleDb = this._objectMappingService.Map<ExampleDto, Example>(example);
            exampleDb.Owner = GetCurrentUserIdentifier();

            this._exampleApplicationService.Add(exampleDb);
        }

        public void Delete(Guid id)
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleWriteScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            var example = this._exampleApplicationService.GetQueryableSet(null)
                .FirstOrDefault(t => t.Owner.Equals(owner) && t.Id.Equals(id));

            this._exampleApplicationService.Delete(example);
        }

        private string GetCurrentUserIdentifier()
        {
            // OWIN auth middleware constants
            var objectIdElement = "http://schemas.microsoft.com/identity/claims/objectidentifier";
            return this._principalService.CurrentPrincipal.FindFirst(objectIdElement).Value;
        }
    }
}