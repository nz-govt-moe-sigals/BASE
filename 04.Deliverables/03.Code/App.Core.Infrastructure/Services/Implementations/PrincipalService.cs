namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Security.Claims;


    public class PrincipalService : AppCoreServiceBase, IPrincipalService
    {
        // OWIN auth middleware constants
        
        public ClaimsIdentity CurrentIdentity => ClaimsPrincipal.Current.Identities.FirstOrDefault();


        public string CurrentName
        {
            get
            {
                //http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier (ie ID)
                // not 'Name' (ie: "SSmith").
                var signedInUserID = this.Current.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return signedInUserID;
            }
        }

        public ClaimsPrincipal Current => ClaimsPrincipal.Current;

        // Validate to ensure the necessary scopes are present.
        public bool HasRequiredScopes(string permission, string scopeElement = Constants.IDA.ClaimTitles.ScopeElementId)
        {
            var value = this.Current?.FindFirst(scopeElement)?.Value?.Contains(permission);
            return value != null && value.Value;
        }

        public string CurrentPrincipalIdentifier
        {
            get
            {
                var owner = ClaimsPrincipal.Current.FindFirst(Constants.IDA.ClaimTitles.ObjectIdElementId)?.Value;
                return owner;
            }
        }

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
            var cultureInfoCode = this.Current.FindFirst(claimName)?.Value;
            return cultureInfoCode;
        }

        private void SetClaimValue(string claimName, string value)
        {
            var claim = this.Current.FindFirst(claimName);
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