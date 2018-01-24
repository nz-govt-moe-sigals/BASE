namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Security.Claims;


    /// <summary>
    /// Implementation of a
    /// Contract for an infrastructure service to 
    /// work with the current thread Principal.
    /// It does not work with any datastorage (ie it does not know how to
    /// retrieve a Principal record from the database). For that, use the
    /// PrincipalRecordService.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.Implementations.AppCoreServiceBase" />
    /// <seealso cref="App.Core.Infrastructure.Services.IPrincipalService" />
    public class PrincipalService : AppCoreServiceBase, IPrincipalService
    {
        // OWIN auth middleware constants
        
        public ClaimsIdentity CurrentIdentity => ClaimsPrincipal.Current.Identities.FirstOrDefault();


        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalService"/> class.
        /// </summary>
        public PrincipalService()
        {

            //Does not rely on other services -- just the thread.
        }

        /// <summary>
        /// Gets the current thread's Principal's NameIdentifier (not same as ObjectIdElementId).
        /// </summary>
        /// <value>
        /// The name of the current.
        /// </value>
        public string CurrentPrincipalName
        {
            get
            {
                //http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier (ie ID)
                // not 'Name' (ie: "SSmith").
                var signedInUserID = this.CurrentPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return signedInUserID;
            }
        }

        /// <summary>
        /// Gets the current Thread's <see cref="ClaimsPrincipal" />.
        /// </summary>
        public ClaimsPrincipal CurrentPrincipal => ClaimsPrincipal.Current;

        /// <summary>
        // Validate the current thread Principal has the necessary scopes.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <param name="scopeElement">The scope element.</param>
        /// <returns>
        ///   <c>true</c> if [has required scopes] [the specified permission]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasRequiredScopes(string permission, string scopeElement = Constants.IDA.ClaimTitles.ScopeElementId)
        {
            var value = this.CurrentPrincipal?.FindFirst(scopeElement)?.Value?.Contains(permission);
            return value != null && value.Value;
        }


        /// <summary>
        /// Gets the current thread's Principal's Object/Record Identifier (not same as NameIdentifier).
        /// </summary>
        /// <value>
        /// The current principal identifier.
        /// </value>
        public string CurrentPrincipalIdentifier
        {
            get
            {
                var owner = ClaimsPrincipal.Current.FindFirst(Constants.IDA.ClaimTitles.ObjectIdElementId)?.Value;
                return owner;
            }
        }

        /// <summary>
        /// The FK to the current Session Record.
        /// </summary>
        public Guid CurrentSessionIdentifier
        {
            get
            {
                var sessionFK = ClaimsPrincipal.Current.FindFirst(Constants.IDA.ClaimTitles.ObjectIdElementId)?.Value;

                if (!string.IsNullOrWhiteSpace(sessionFK))
                {
                    Guid result = Guid.Parse(sessionFK);
                    return result;
                }
                else
                {
                    return new Guid();
                }
            }
        }


        public bool IsInRole(params string[] roles)
        {
            return roles.Any(x => ClaimsPrincipal.Current.IsInRole(x));
        }


        public string ClaimPreferredCultureCode
        {
            get => GetClaimValue(Constants.IDA.ClaimTitles.CultureElementId);
            set => SetClaimValue(Constants.IDA.ClaimTitles.CultureElementId, value);
        }

        /// <summary>
        ///     The Key of the Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current
        ///     Principal)
        /// </summary>
        public string PrincipalTenantKey
        {
            get => GetClaimValue(Constants.IDA.ClaimTitles.PrincipalKeyElementId);
            set => SetClaimValue(Constants.IDA.ClaimTitles.PrincipalKeyElementId, value);
        }


        private string GetClaimValue(string claimName)
        {
            var cultureInfoCode = this.CurrentPrincipal.FindFirst(claimName)?.Value;
            return cultureInfoCode;
        }

        private void SetClaimValue(string claimName, string value)
        {
            var claim = this.CurrentPrincipal.FindFirst(claimName);
            if (claim != null)
            {
                this.CurrentIdentity
                    .TryRemoveClaim(claim);
            }
            claim = new Claim(claimName, value);
            this.CurrentIdentity.AddClaim(claim);
        }
    }
}