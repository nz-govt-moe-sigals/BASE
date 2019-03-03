using System;
using System.Collections.Generic;
using App.Core.Infrastructure.Db.Migrations.Seeding;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Linq;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IPrincipalManagmentService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IPrincipalManagmentService" />
    public class PrincipalManagmentService : AppCoreServiceBase, IPrincipalManagmentService
    {
        private static readonly string _resourceListCacheKey = "_PrincipalManagmentCache";
        private readonly IRepositoryService _repositoryService;
        private readonly IOperationContextService _operationContextService;
        private readonly IAzureRedisCacheService _azureRedisCacheService;

        public PrincipalManagmentService(IRepositoryService repositoryService,
            IOperationContextService operationContextService,
            IAzureRedisCacheService azureRedisCacheService)
        {
            this._repositoryService = repositoryService;
            _operationContextService = operationContextService;
            _azureRedisCacheService = azureRedisCacheService;
        }

        public Principal Get(string idpPrincipalKey, string subPrincipalKey, string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId))
            {
                return null;
            }
            //First, search in Request Cache:
            var result = GetFromLocalCache();
            if (result == null)
            {
                //Otherwise look in shared cache:
                result = GetFromDistributedCacheAndCacheLocally(uniqueCacheId);
            }
            if (result != null)
            {
                return MaptoEntity(result);
            }

            return GetFromRepositoryAndCache(idpPrincipalKey, subPrincipalKey, uniqueCacheId, timespanToCache);
        }

        /// <summary>
        /// 
        /// </summary>
        public Principal CreateIfNotExists(string idpPrincipalKey, string subPrincipalKey, string name,
            string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var currentPrincipal = Get(idpPrincipalKey, subPrincipalKey, uniqueCacheId);
            if (currentPrincipal != null) { return currentPrincipal; }

            currentPrincipal = new Principal
            {
                CategoryFK = AppCoreDbContextSeederPrincipalCategory.GetDefaultPrincipalCategory().Id,
                FullName = name,
                Enabled = true,
                EnabledBeginningUtc = DateTime.UtcNow
            };
            var login = new PrincipalLogin()
            {
                PrincipalFK = currentPrincipal.Id,
                CreatedByPrincipalId = currentPrincipal.Id.ToString(),
                LastModifiedByPrincipalId = currentPrincipal.Id.ToString(),
                LastLoggedInUtc = DateTime.UtcNow,
                IdPLogin = idpPrincipalKey,
                SubLogin = subPrincipalKey,
            };
            currentPrincipal.Logins.Add(login);
            this._repositoryService.AddOnCommit(Constants.Db.AppCoreDbContextNames.Core, currentPrincipal);
            // Yep Want to save as quickly as possible. 
            this._repositoryService.SaveChanges(Constants.Db.AppCoreDbContextNames.Core);
            AddToCache(uniqueCacheId, currentPrincipal, timespanToCache);
            return currentPrincipal;
        }


        public Principal Get(Guid id)
        {
            Principal result = this._repositoryService.GetSingle
                <Principal>(Constants.Db.AppCoreDbContextNames.Core, x => x.Id == id);
            return result;
        }

        public Principal GetFromRepositoryAndCache(string idpPrincipalKey, string subPrincipalKey, string uniqueCacheId = null, TimeSpan? timespanToCache = null)
        {
            Principal result = this._repositoryService.GetQueryableSingle<Principal>(Constants.Db.AppCoreDbContextNames.Core,
                    x => x.Logins.Any(y => y.IdPLogin == idpPrincipalKey && y.SubLogin == subPrincipalKey))
                .Include(x => x.Claims)
                .FirstOrDefault();
            AddToCache(uniqueCacheId, result, timespanToCache);
            return result;
        }

        public PrincipalDto GetFromLocalCache()
        {
            return this._operationContextService.Get<PrincipalDto>(_resourceListCacheKey);
        }

        public PrincipalDto GetFromDistributedCacheAndCacheLocally(string uniqueCacheId)
        {
            string redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            var result = _azureRedisCacheService.Get<PrincipalDto>(redisKey);
            if (result != null)
            {
                AddToLocalCache(result);
            }

            return result;
        }


        public void AddToCache(string uniqueCacheId, Principal result, TimeSpan? timespan = null)
        {
            AddToCache(uniqueCacheId, MapToDto(result), timespan);
        }

        public void AddToCache(string uniqueCacheId, PrincipalDto result, TimeSpan? timespan = null)
        {
            AddToLocalCache(result);
            AddToDistributedCache(uniqueCacheId, result);
        }

        public void AddToLocalCache(PrincipalDto result)
        {
            if (result == null) { return; }
            this._operationContextService.Set(_resourceListCacheKey, result);
        }

        public void AddToLocalCache(Principal result)
        {
            AddToLocalCache(MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, Principal result, TimeSpan? timespan = null)
        {
            AddToDistributedCache(uniqueCacheId, MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, PrincipalDto result, TimeSpan? timespan = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId) || result == null) { return; }
            string redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            _azureRedisCacheService.Set(redisKey, result, timespan ?? TimeSpan.FromMinutes(5));
        }

        protected PrincipalDto MapToDto(Principal principal)
        {
            return AutoMapper.Mapper.Map<Principal, PrincipalDto>(principal);
        }

        protected Principal MaptoEntity(PrincipalDto principal)
        {
            return AutoMapper.Mapper.Map<PrincipalDto, Principal>(principal);
        }

        protected string GetRedisKey()
        {
            return _resourceListCacheKey + ":" + "Key" + ":";
        }





    }
}
