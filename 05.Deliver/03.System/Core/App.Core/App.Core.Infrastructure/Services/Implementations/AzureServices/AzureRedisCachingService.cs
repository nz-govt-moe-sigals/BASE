using System;
using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;
using CachingFramework.Redis;
using CachingFramework.Redis.Contracts.Providers;
using StackExchange.Redis;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureRedisCacheService : AppCoreServiceBase, IAzureRedisCacheService
    {
        private readonly IOperationContextService _operationContextService;
        private readonly Lazy<RedisContext> _redisContext;
 

        public AzureRedisCacheService (IOperationContextService operationContextService, IAzureRedisConnection azureRedisConnection)
        {
            this._operationContextService = operationContextService;
            if(azureRedisConnection.Enabled) 
            {
                _redisContext = new Lazy<RedisContext>(() => new RedisContext(azureRedisConnection.ConnectionMultiplexer));
            }
                //To make this library's context:
             

            
        }

        private ICacheProvider Cache
        {
            get
            {
                if (_redisContext != null)
                {
                    return _redisContext.Value.Cache;
                }

                return null;
            }
        }

        public void Set<T>(string key, T value, TimeSpan? duration = null)
        {
            if(Cache == null ) { return; }

            if (!duration.HasValue)
            {
                duration = TimeSpan.FromSeconds(60);
            }

            if (duration.Value.TotalSeconds < 5)
            {
                duration = TimeSpan.FromSeconds(30);
            }

            Cache.SetObject(key, value, duration);

            // And for faster retrieval, set it also in local context:
            var localKey = GetOperationKey(key);
            _operationContextService.Set<T>(localKey, value);

        }



        public void Set<T>(string key, string subKey, T value, TimeSpan? duration=null)
        {
            if (Cache == null) { return; }

            if ((duration == null) || (!duration.HasValue))
            {
                duration = TimeSpan.FromSeconds(60);
            }

            if (duration.Value.TotalSeconds < 5)
            {
                duration = TimeSpan.FromSeconds(30);
            }

            Cache.SetHashed(key, subKey, value, duration);

        }

        public T Get<T>(string key)
        {
            var localKey = GetOperationKey(key);
            var result = _operationContextService.Get<T>(localKey);
            if (result != null)
            {
                return result;
            }
            if (Cache == null) { return default(T); }
            result = Cache.GetObject<T>(key);
            if (result != null)
            {
                _operationContextService.Set(localKey, result);
            }
            return result;
        }

        public T Get<T>(string key, string subKey)
        {
            if (Cache == null) { return default(T); }
            return Cache.GetHashed<T>(key,subKey);
        }


        private string GetOperationKey(string key)
        {
            return "_redis:" + key;
        }
    }

}