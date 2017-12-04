namespace App.Core.Infrastructure.Services
{
    using System;
    using System.Security.Claims;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for a service to work with the current thread Principal.
    /// It does not work with any datastorage (ie it does not know how to
    /// retrieve a Principal record from the database). For that, use the
    /// PrincipalRecordService.
    /// </summary>
    public interface IPrincipalService : IHasAppCoreService
    {

        string CurrentName { get; }

        ClaimsPrincipal Current { get; }

        string CurrentPrincipalIdentifier { get; }

        /// <summary>
        /// The FK to the current Session Table.
        /// </summary>
        Guid CurrentSessionIdentifier { get; }

        string ClaimPreferredCultureCode { get; set; }

        string PrincipalTenantKey { get; set; }

        bool HasRequiredScopes(string permission,
            string scopeElement =  "http://schemas.microsoft.com/identity/claims/scope");

        bool IsInRole(params string[] roles);
    }
}