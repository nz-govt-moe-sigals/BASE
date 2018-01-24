using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Services.Implementations
{

    /// <summary>
    /// Implementation of a
    /// Contract for an Infrastructure Service to 
    /// Query whether the current Thread's Principal
    /// is Authorised to perform specific Operations.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IAuthorisationService" />
    public class AuthorisationService : IAuthorisationService
    {
        private readonly IPrincipalService _principalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorisationService"/> class.
        /// </summary>
        /// <param name="principalService">The principal service.</param>
        public AuthorisationService(IPrincipalService principalService)
        {
            this._principalService = principalService;
        }

        /// <summary>
        /// Determines whether the current thread Principal has roles claims.
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns>
        ///   <c>true</c> if the specified roles has roles; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRoles(params string[] roles)
        {
            return roles.Any(x => this._principalService.CurrentPrincipal.IsInRole(x));
        }

        /// <summary>
        /// Determines whether the current thread Principal has scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <returns>
        ///   <c>true</c> if the specified scope has scope; otherwise, <c>false</c>.
        /// </returns>
        public bool HasScope(string scope)
        {
            string scopeElement = Constants.IDA.ClaimTitles.ScopeElementId;

            var value = this._principalService.CurrentPrincipal?.FindFirst(scopeElement)?.Value?.Contains(scope);
            return value != null && value.Value;
        }
    }
}
