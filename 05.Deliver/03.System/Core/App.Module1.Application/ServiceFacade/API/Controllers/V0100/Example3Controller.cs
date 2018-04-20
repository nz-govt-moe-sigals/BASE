namespace App.Module2.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Module2.Application.Services;
    using App.Module2.Shared.Configuration.Models;
    using App.Module2.Shared.Models.Entities;

    /// <summary>
    ///     An example of a classic WebAPI, with DI in the constructor,
    ///     using an in-mem fake db to hold a list of Example items
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
    public class Example3Controller : ApiControllerBase
    {
        private static readonly List<Example> _inMemFakeDb = new List<Example>();
        private readonly ExampleApiConfiguration _apiConfiguration;
        private readonly IHostSettingsService _hostSettingsService;

        public Example3Controller(IPrincipalService principalsService,
            IHostSettingsService hostSettingsService,
            IExampleApplicationService exampleApplicationService) : base(principalsService)
        {
            this._hostSettingsService = hostSettingsService;

            this._apiConfiguration = this._hostSettingsService
                .GetObject<ExampleApiConfiguration>("bearerTokenAuth:"); //"cookieAuth:" or "bearerTokenAuth:"
        }

        public IEnumerable<Example> Get()
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleReadScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            var item = _inMemFakeDb.Where(t => t.Owner == owner);
            return item;
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
            _inMemFakeDb.Add(example);
        }

        public void Delete(Guid id)
        {
            // Validate access:
            HasRequiredScopes(this._apiConfiguration.ExampleWriteScope);

            var owner = GetCurrentUserIdentifier() /*must be resolved outside of linq statement*/;
            var example = _inMemFakeDb.Where(t => t.Owner.Equals(owner) && t.Id.Equals(id)).FirstOrDefault();
            _inMemFakeDb.Remove(example);
        }

        private string GetCurrentUserIdentifier()
        {
            // OWIN auth middleware constants
            var objectIdElement = "http://schemas.microsoft.com/identity/claims/objectidentifier";
            return this._principalService.CurrentPrincipal.FindFirst(objectIdElement).Value;
        }
    }
}