namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ITenantService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ITenantService" />
    public class TenantService : ITenantService
    {
        private static readonly string _cacheKey = "ResourceTenantKey";
        private readonly IOperationContextService _contextService;
        private readonly ICachingService _cachingService;
        private readonly IRepositoryService _repositoryService;
        private readonly IOperationContextService _operationContextService;
        private readonly IPrincipalService _principalService;
        private Tenant _defaultTenant;


        public TenantService(IOperationContextService operationContextService, IPrincipalService principalService,
            IOperationContextService contextService, ICachingService cachingService, IRepositoryService repositoryService)
        {
            this._operationContextService = operationContextService;
            this._principalService = principalService;
            this._contextService = contextService;
            this._cachingService = cachingService;
            this._repositoryService = repositoryService;
        }

        /// <summary>
        ///     The Key of the Tenant the current Request's Resource belongs to (ie, the start of the Url)
        ///     <para>
        ///         Used to set the resource' appearance (skin header/logo/footer, etc.)
        ///     </para>
        /// </summary>
        public Tenant ResourceTenant
        {
            get => this._operationContextService.Get<Tenant>(_cacheKey);
            private set => this._operationContextService.Set(_cacheKey, value);
        }

        public Tenant PrincipalTenant => throw new Exception("TODO");

        /// <summary>
        ///     The Key of the Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current
        ///     Principal)
        /// </summary>
        public string PrincipalTenantKey
        {
            get => this._principalService.PrincipalTenantKey;
            set => this._principalService.PrincipalTenantKey = value;
        }

        /// <summary>
        ///     Can be invoked by Route Condition
        ///     to verify that first part of route is valid.
        /// </summary>
        /// <param name="tenantKey"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public bool IsValidTenantKey(string tenantKey, string hostName = null)
        {
            tenantKey = tenantKey.ToLowerInvariant();
            var result = GetTenant(tenantKey, hostName);
            return result != null;
        }


        public string GetDefaultTenantKey()
        {
            return GetDefaultTenant()?.Key;
        }


        public Tenant SetTenant(string tenantKey, string hostName = null)
        {
            Tenant result;
            result = GetTenant(tenantKey, hostName);
            this.ResourceTenant = result;
            return result;
        }

        private List<Tenant> GetContextCache()
        {
            const string key = "_TenantCache";
            var result = this._operationContextService.Get<List<Tenant>>("_TenantCache");
            if (result == null)
            {
                result = new List<Tenant>();
                this._operationContextService.Set(key, result);
            }
            return result;
        }


        private Tenant GetTenant(string tenantKey, string hostName = null)
        {
            if (tenantKey == null)
            {
                return null;
            }
            tenantKey = tenantKey.ToLower();

            if (tenantKey == "default")
            {
                return GetDefaultTenant();
            }

            Tenant result;
            var list = GetContextCache();
            if (hostName == null)
            {
                result = list.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.Key, tenantKey) ==
                                                  0);
                if (result != null)
                {
                    return result;
                }
                result = this._repositoryService.GetSingle<Tenant>(Constants.Db.AppCoreDbContextNames.Core, x => tenantKey == x.Key);
                if (result != null)
                {
                    list.Add(result);
                }
                return result;
            }

            hostName = hostName.ToLower();
            result = list.FirstOrDefault(
                x => StringComparer.InvariantCultureIgnoreCase.Compare(x.Key, tenantKey) == 0 ||
                     StringComparer.InvariantCultureIgnoreCase.Compare(x.HostName, hostName) == 0);
            if (result != null)
            {
                return result;
            }
            result = this._repositoryService.GetSingle<Tenant>(Constants.Db.AppCoreDbContextNames.Core, x => tenantKey == x.Key || hostName == x.HostName);
            if (result != null)
            {
                list.Add(result);
            }
            return result;
        }

        private Tenant GetDefaultTenant()
        {
            if (this._defaultTenant == null)
            {
                this._defaultTenant = this._repositoryService.GetSingle<Tenant>(Constants.Db.AppCoreDbContextNames.Core, x => x.IsDefault == true);
            }
            return this._defaultTenant;
        }
    }
}