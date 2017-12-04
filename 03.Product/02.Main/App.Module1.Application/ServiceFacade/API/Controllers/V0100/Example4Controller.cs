namespace App.Module1.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Module1.Application.Services;
    using App.Module1.Shared.Configuration.Models;
    using App.Module1.Shared.Models.Entities;

    /// <summary>
    ///     An example of a classic WebAPI, with DI in the constructor,
    ///     using an orm accessed db to hold a list of Example items
    ///     and applying Bearer token validation.
    ///     <para>
    ///         Things to notice:
    ///         * DbContext is injected (in a perfect world, this would be a RepositoryService that wraps it).
    ///         * The Context is not submitted. Just concentrate on doing work, not saving it, and the framework
    ///         will handle it transparently, as late as possible in order to diminish the number of commits
    ///         as well as be stuck in a position that not everything can be committed.
    ///     </para>
    /// </summary>
    [Authorize]
    public class Example4Controller : ApiControllerBase
    {
        private readonly ExampleApiConfiguration _apiConfiguration;
        private readonly IExampleApplicationService _exampleApplicationService;
        private readonly IHostSettingsService _hostSettingsService;
        private readonly IObjectMappingService _objectMappingService;

        public Example4Controller(IPrincipalService principalsService,
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
        public IEnumerable<Example> Get()
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleReadScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            var results = this._exampleApplicationService
                    .GetQueryableSet(null)
                    .Where(x => x.Owner == owner)
                /*plus any OData source criteria on the Queryable result*/
                ;
            var t = this._exampleApplicationService
                .GetQueryableSet(null).ToArray();
            /*plus any OData source criteria on the Queryable result*/
            ;
            return results;
        }

        public void Post(Example example)
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleWriteScope);
            // Validate payload:
            if (string.IsNullOrEmpty(example.PublicText))
            {
                throw new WebException("Please provide a example description");
            }
            //As you're saving, fill in some fields, for later filtering against:

            example.Owner = GetCurrentUserIdentifier();

            this._exampleApplicationService.Add(example);
        }

        public void Delete(Guid id)
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleWriteScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            var example = this._exampleApplicationService.GetQueryableSet(null)
                .FirstOrDefault(t => t.Owner.Equals(owner) && t.Id.Equals(id));
            if (example == null)
            {
                return;
            }
            this._exampleApplicationService.Delete(example);
        }

        private string GetCurrentUserIdentifier()
        {
            // OWIN auth middleware constants
            var objectIdElement = "http://schemas.microsoft.com/identity/claims/objectidentifier";
            return this._principalService.Current.FindFirst(objectIdElement).Value;
        }
    }
}