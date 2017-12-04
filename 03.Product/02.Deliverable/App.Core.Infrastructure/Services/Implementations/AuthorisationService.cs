using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class AuthorisationService : IAuthorisationService
    {
        private readonly IPrincipalService _principalService;

        public AuthorisationService(IPrincipalService principalService)
        {
            this._principalService = principalService;
        }

        public bool HasRoles(params string[] roles)
        {
            return roles.Any(x => this._principalService.Current.IsInRole(x));
        }

        // Validate to ensure the necessary scopes are present.
        public bool HasScope(string scope)
        {
            string scopeElement = Constants.IDA.ClaimTitles.ScopeElementId;

            var value = this._principalService.Current?.FindFirst(scopeElement)?.Value?.Contains(scope);
            return value != null && value.Value;
        }




    }
}
