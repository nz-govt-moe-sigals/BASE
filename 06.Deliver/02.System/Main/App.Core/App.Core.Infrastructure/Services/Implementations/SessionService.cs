using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Shared.Models.Entities;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ISessionService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.ISessionService" />
    public class SessionService : AppCoreServiceBase, ISessionService
    {
        //private static readonly string _currentRequestCacheKey = "_CurrentSessionKey";
        private static readonly string _resourceListCacheKey = "_SessionCache";
        private readonly IRepositoryService _repositoryService;
        private readonly IOperationContextService _operationContextService;
        private readonly IAzureRedisCacheService _azureRedisCacheService;

        public SessionService(IRepositoryService repositoryService,
            IOperationContextService operationContextService,
            IAzureRedisCacheService azureRedisCacheService)
        {
            this._repositoryService = repositoryService;
            _operationContextService = operationContextService;
            _azureRedisCacheService = azureRedisCacheService;
        }

        public Session Get(string uniqueCacheId, TimeSpan? timespanToCache = null)
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

            return GetFromRepositoryAndCache(uniqueCacheId, timespanToCache);
        }

        public Session CreateAndSave(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var session = Create(principal, uniqueCacheId, timespanToCache);
            _repositoryService.SaveChanges(Constants.Db.AppCoreDbContextNames.Core);
            return session;
        }

        public Session Create(Principal principal, string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            Session session = new Session()
            {
                PrincipalFK = principal.Id,
                UniqueIdentifier = uniqueCacheId
            };

            this._repositoryService.AddOnCommit<Session>(Constants.Db.AppCoreDbContextNames.Core, session);
            AddToCache(uniqueCacheId, session, timespanToCache);

            return session;
        }

        public SessionDto GetFromLocalCache()
        {
            return this._operationContextService.Get<SessionDto>(_resourceListCacheKey);
        }

        public SessionDto GetFromDistributedCacheAndCacheLocally(string uniqueCacheId)
        {
            string redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            var result = _azureRedisCacheService.Get<SessionDto>(redisKey);
            if (result != null)
            {
                AddToLocalCache(result);
            }

            return result;
        }

        public Session GetFromRepositoryAndCache(string uniqueCacheId, TimeSpan? timespanToCache = null)
        {
            var session = _repositoryService.GetQueryableSingle<Session>(
                    Constants.Db.AppCoreDbContextNames.Core, x => x.UniqueIdentifier == uniqueCacheId)
                .Include(x => x.Principal)
                .FirstOrDefault();

            AddToCache(uniqueCacheId, session, timespanToCache);
            return session;
        }

        public void AddToCache(string uniqueCacheId, Session result, TimeSpan? timespan = null)
        {
            AddToCache(uniqueCacheId, MapToDto(result), timespan);
        }

        public void AddToCache(string uniqueCacheId, SessionDto result, TimeSpan? timespan = null)
        {
            AddToLocalCache(result);
            AddToDistributedCache(uniqueCacheId, result);
        }

        public void AddToLocalCache(SessionDto result)
        {
            if(result == null) { return; } 
            this._operationContextService.Set(_resourceListCacheKey, result);
        }

        public void AddToLocalCache(Session result)
        {
            AddToLocalCache(MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, Session result, TimeSpan? timespan = null)
        {
            AddToDistributedCache(uniqueCacheId, MapToDto(result));
        }

        public void AddToDistributedCache(string uniqueCacheId, SessionDto result, TimeSpan? timespan = null)
        {
            if (string.IsNullOrWhiteSpace(uniqueCacheId) || result == null) { return; }
            string redisKey = GetRedisKey() + uniqueCacheId.ToLower();
            _azureRedisCacheService.Set(redisKey, result, timespan ?? TimeSpan.FromMinutes(5));
        }

        protected SessionDto MapToDto(Session session)
        {
            return AutoMapper.Mapper.Map<Session, SessionDto>(session);
        }

        protected Session MaptoEntity(SessionDto session)
        {
            return AutoMapper.Mapper.Map<SessionDto, Session>(session);
        }

        protected string GetRedisKey()
        {
            return _resourceListCacheKey + ":" + "Key" + ":";
        }
    }
}
