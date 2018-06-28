using App.Core.Shared.Models.Entities;

namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper.QueryableExtensions;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ITenantService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ITenantService" />
    public class TenantService : AppCoreServiceBase, ITenantService
    {
        private static readonly string _currentRequestCacheKey = "_CurrentTenantKey";
        private static readonly string _ResourceListCacheKey = "_TenantCache";
        private readonly ICacheItemService _cacheItemService;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IRepositoryService _repositoryService;
        private readonly IOperationContextService _operationContextService;
        private readonly IPrincipalService _principalService;
        private TenantDto _defaultTenant;

        public TenantService(IOperationContextService operationContextService, IPrincipalService principalService,
           ICacheItemService cachingService, IRedisCacheService redisCacheService, IRepositoryService repositoryService)
        {
            this._operationContextService = operationContextService;
            this._principalService = principalService;
            this._cacheItemService = cachingService;
            this._redisCacheService = redisCacheService;
            this._repositoryService = repositoryService;
        }

        /// <summary>
        /// Gets the list of cached Resources retrieved during this request:
        /// </summary>
        /// <returns></returns>
        private List<TenantDto> GetContextCache()
        {

            var result = this._operationContextService.Get<List<TenantDto>>(_ResourceListCacheKey);
            if (result == null)
            {
                result = new List<TenantDto>();
                this._operationContextService.Set(_ResourceListCacheKey, result);
            }
            return result;
        }



        /// <summary>
        ///     The current Tenant (ie, the start of the Url)
        ///     <para>
        ///         Used to set the resource' appearance (skin header/logo/footer, etc.)
        ///     </para>
        /// </summary>
        public TenantDto CurrentTenant
        {
            get => this._operationContextService.Get<TenantDto>(_currentRequestCacheKey);
            private set => this._operationContextService.Set(_currentRequestCacheKey, value);
        }



       


        ///// <summary>
        /////     The Key of the Tenant of the current Security Principal (ie, the Tenant Key within a Claim of the Thread current
        /////     Principal)
        ///// </summary>
        //public string PrincipalTenantKey
        //{
        //    get => this._principalService.PrincipalTenantKey;
        //    set => this._principalService.PrincipalTenantKey = value;
        //}

        //public static string CurrentRequestCacheKey => _currentRequestCacheKey;


        private TenantDto GetDefaultTenant()
        {
            if (this._defaultTenant == null)
            {
                this._defaultTenant = _cacheItemService.Get<TenantDto>(Constants.Cache.StaticKeys.DefaultTenant);
            }
            return this._defaultTenant;
        }

        public string GetDefaultTenantKey()
        {
            return GetDefaultTenant()?.Key;
        }


        /// <summary>
        /// <para>
        /// Inovked by Middleware Module 
        /// (before Routing gets involved)
        /// </para>
        /// </summary>
        /// <param name="tenantKeyOrPath"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public TenantDto SetTenantFromUrl(string tenantKeyOrPath, string hostName = null)
        {
            TenantDto result;
            result = GetTenant(tenantKeyOrPath, hostName, true);

            this.CurrentTenant = result;
            return result;
        }


        /// <summary>
        /// <para>
        ///     Can be invoked by Route Condition
        ///     to verify that first part of route is valid.
        ///     (note that when done from there, 
        ///     this will be the same as what was resolved 
        ///     within the Middleware, when it set the Tenancy).
        /// </para>
        /// <para>
        /// If invoked from another location, will be slower.
        /// </para>
        /// </summary>
        /// <param name="tenantKey"></param>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public bool IsValidTenantKey(string tenantKey, string hostName = null)
        {

            // Since this is after the Middleware has parsed it, 
            // it's already in cache... so can use local cache.

            tenantKey = tenantKey.ToLowerInvariant();

            var result = GetTenant(tenantKey, hostName);

            return result != null;
        }



        private TenantDto GetTenant(string tenantKeyOrPath, string hostName = null, bool defaultIfNotFound = true)
        {

            TenantSearchTokens searchTokens = ExtractSearchTokens(hostName, tenantKeyOrPath);

            TenantDto result;
            if (!string.IsNullOrWhiteSpace(searchTokens.HostName))
            {
                result = SearchCacheForTenantByHostName(searchTokens);
                if (result != null)
                {
                    return result;
                }
            }
            result = SearchCacheForTenantByKey(searchTokens);
            if (result != null)
            {
                return result;
            }
            if (string.IsNullOrWhiteSpace(searchTokens.HostName))
            {
                result = this._repositoryService
                    .GetQueryableSet<Tenant>(Constants.Db.AppCoreDbContextNames.Core)
                    .Where(x => ((x.Key == searchTokens.TenancyKey)))
                    .ProjectTo<TenantDto>((object)null, x => x.Properties)
                    .FirstOrDefault(x=>true);
            }
            else
            {
                result = this._repositoryService
                    .GetQueryableSet<Tenant>(Constants.Db.AppCoreDbContextNames.Core)
                    .Where(x => ((x.HostName == searchTokens.HostName) || (x.Key == searchTokens.TenancyKey)))
                    .ProjectTo<TenantDto>((object)null, x => x.Properties)
                    .FirstOrDefault(x => true);
            }
            if (result != null)
            {
                string redisKey;
                // Cache in redis under both keys:
                if (!string.IsNullOrWhiteSpace(searchTokens.HostName))
                {
                    redisKey = _ResourceListCacheKey + ":" + "HostName" + ":" + searchTokens.HostName;
                    _redisCacheService.Set(redisKey, result);
                }
                redisKey = _ResourceListCacheKey + ":" + "Key" + ":" + searchTokens.TenancyKey;
                _redisCacheService.Set(redisKey, result);
                // Then in local request:
                GetContextCache().Add(result);
            }
            return result;
        }

        class TenantSearchTokens
        {
            public string HostName { get; private set; }
            public string TenancyKey { get; private set; }
            public TenantSearchTokens(string hostName, string tenancyKey)
            {
                HostName = hostName;
                TenancyKey = tenancyKey;
            }
        }

        private TenantSearchTokens ExtractSearchTokens(string hostName, string tenantKeyOrPath)
        {
            //remove 
            if (!string.IsNullOrEmpty(hostName)) {
                hostName = hostName.ToLower().Split(':').First();
            }

            // TODO: need to get the list of names to not bother checking for (ie, the default one to which it was deployed):
            string[] defaultHostNames = new string[] { "localhost" };

            if (string.IsNullOrWhiteSpace(hostName))
            {
                hostName = null;
            }
            else
            {
                if (defaultHostNames.Contains(hostName))
                {
                    hostName = null;

                }
            }

            // Not found by HostName, so search by Path.
            // Should be first place, but  Path can start 
            // with Versioning ('v1.0')
            string tenantKey;
            if (string.IsNullOrWhiteSpace(tenantKeyOrPath))
            {
                // As path is too short to be anything, it's the default:
                tenantKey = GetDefaultTenantKey();
            }
            else if (tenantKeyOrPath == "/")
            {
                // As path is too short to be anything, it's the default:
                tenantKey = GetDefaultTenantKey();
            }

            else
            {
                var pathParts = tenantKeyOrPath.Split(new char['/']);
                var index = 0;
                // If the first part is not a version number, it 
                // could be the second 
                if (index >= pathParts.Length)
                {
                    // As path is too short to be anything, it's the default:
                    tenantKey = GetDefaultTenantKey();
                }
                else
                {
                    // Index = 0: 
                    string pathPart = pathParts[index];

                    if (Regex.Match(pathPart, "v\\d+(\\.\\d?)").Success)
                    {
                        // The path starts with a version number, 
                        // but the path is long enough to still contain the tenancy
                        // in the next part:
                        index++;
                        // Index = 1: 
                        pathPart = pathParts[index];
                    }

                    if (index >= pathParts.Length)
                    {
                        // As path is too short to be anything, it's the default:
                        tenantKey = GetDefaultTenantKey();
                    }
                    else
                    {
                        try
                        {
                            CultureInfo cultureInfo = new CultureInfo(pathPart);
                            // Since this is the culture code, means no tenancy was provided
                            // So it's the default one.
                            tenantKey = GetDefaultTenantKey();
                        }
                        catch
                        {
                            // Not a cultureCode, so it's a tenancy, if long enough
                            tenantKey = pathPart;
                        }
                    }
                }
            }

            return new TenantSearchTokens(hostName, tenantKey);

        }


        private TenantDto SearchCacheForTenantByHostName(TenantSearchTokens tenantSearchTokens)
        {
            if (string.IsNullOrWhiteSpace(tenantSearchTokens.HostName))
            {
                return null;
            }
            //First, search in Request Cache:
            var list = GetContextCache();
            TenantDto result = list.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.HostName, tenantSearchTokens.HostName) == 0);
            if (result != null)
            {
                return result;
            }
            //Otherwise look in shared cache:
            string redisKey = _ResourceListCacheKey + ":" + "HostName" + ":" + tenantSearchTokens.HostName;

            result = _redisCacheService.Get<TenantDto>(redisKey);

            return result;
        }

        private TenantDto SearchCacheForTenantByKey(TenantSearchTokens tenantSearchTokens)
        {
            if (string.IsNullOrWhiteSpace(tenantSearchTokens.TenancyKey))
            {
                return null;
            }
            //First, search in Request Cache:
            var list = GetContextCache();
            TenantDto result;
            
            result = list.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.Key, tenantSearchTokens.TenancyKey) == 0);
            if (result != null)
            {
                return result;
            }
            //Otherwise look in shared cache:
            string redisKey = _ResourceListCacheKey + ":" + "Key" + ":" + tenantSearchTokens.TenancyKey;

            result = _redisCacheService.Get<TenantDto>(redisKey);

            return result;
        }





    }
}