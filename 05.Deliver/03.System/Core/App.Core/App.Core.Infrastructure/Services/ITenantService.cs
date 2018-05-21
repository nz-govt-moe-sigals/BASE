namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Services;

    /// <summary>
    ///     A service contract to manage Tenants.
    ///     <para>
    ///         Important: there are always two Tenants: the Tenant that owns the Resource being requested
    ///         and the Principal's Session Tenant. A Principal can be within
    ///     </para>
    /// </summary>
    public interface ITenantService : IHasAppCoreService
    {
        /// <summary>
        ///     The Tenant the current Request's Resource belongs to (ie, the start of the Url)
        ///     <para>
        ///         Used to set the resource' appearance (skin header/logo/footer, etc.)
        ///     </para>
        /// </summary>
        Tenant ResourceTenant { get; }

        /// <summary>
        ///     The Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current Principal)
        ///     <para>Used to assertain permissions.</para>
        /// </summary>
        string PrincipalTenantKey { get; set; }


        Tenant PrincipalTenant { get; }

        /// <summary>
        ///     Determines if given text is a valid Tenant Key
        ///     <para>
        ///         Invoked by Routing to determine if first part of MVC/WebAPI route is a Tenant Key.
        ///     </para>
        /// </summary>
        /// <returns></returns>
        bool IsValidTenantKey(string tenantKey, string hostName = null);


        Tenant SetTenant(string tenantKey, string hostName = null);

        string GetDefaultTenantKey();
    }
}