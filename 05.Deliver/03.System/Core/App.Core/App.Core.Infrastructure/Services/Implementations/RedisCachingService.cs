namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Initialization.DependencyResolution;
    using CachingFramework.Redis;
    using CachingFramework.Redis.Contracts.Providers;
    using StackExchange.Redis;
    using System;

    public class RedisCacheService : AppCoreServiceBase, IRedisCacheService
    {
        private readonly IAzureRedisCacheService _azureRedisCacheService;
        private readonly IOperationContextService _operationContextService;
        Lazy<RedisContext> _redisContext;

        ICacheProvider Cache
        {
            get
            {
                return _redisContext.Value.Cache;
            }
        }

        public RedisCacheService (IAzureRedisCacheService azureRedisCacheService, IOperationContextService operationContextService)
        {
            // Leverage the other service's configuration
            _azureRedisCacheService = azureRedisCacheService;
            this._operationContextService = operationContextService;
            // to extract the configuration object:
            var configuration = _azureRedisCacheService.Configuration;
            // to parse a configurationOptions:
            ConfigurationOptions configurationOptions = ConfigurationOptions.Parse(configuration.ConnectionString);
            configurationOptions.ClientName = "...";
            configurationOptions.AllowAdmin = false;
            configurationOptions.AllowAdmin = false;
            configurationOptions.Ssl = true;

            /*
            //To make this library's context:
            _redisContext = new Lazy<RedisContext>(() => new RedisContext(configurationOptions));
            */

            
        }

        public void Set<T>(string key, T value, TimeSpan? duration = null)
        {
            if ((duration == null) || (!duration.HasValue))
            {
                duration = TimeSpan.FromSeconds(60);
            }

            if (duration.Value.TotalSeconds < 5)
            {
                duration = TimeSpan.FromSeconds(30);
            }

            Cache.SetObject(key, value, duration);

            // And for faster retrieval, set it also in local context:
            var localKey = "_redis:" + key;
            _operationContextService.Set<T>(localKey, value);

        }



        public void Set<T>(string key, string subKey, T value, TimeSpan? duration=null)
        {
            if ((duration == null) || (!duration.HasValue))
            {
                duration = TimeSpan.FromSeconds(60);
            }

            if (duration.Value.TotalSeconds < 5)
            {
                duration = TimeSpan.FromSeconds(30);
            }

            Cache.SetHashed(key,subKey, value, duration);

        }

        public T Get<T>(string key)
        {
            var localKey = "_redis:" + key;
            var result = _operationContextService.Get<T>(localKey);
            if (result != null)
            {
                return result;
            }
            result = Cache.GetObject<T>(key);
            if (result != null)
            {
                _operationContextService.Set(localKey, result);
            }
            return result;
        }
        public T Get<T>(string key, string subKey)
        {
            return Cache.GetHashed<T>(key,subKey);
        }

    }

}