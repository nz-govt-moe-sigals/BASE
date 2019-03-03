namespace App.Core.Infrastructure.Services.Implementations
{
    using App.Core.Infrastructure.Cache;
    using System;

    public class CacheItemService : AppCoreServiceBase, ICacheItemService
    {
        private readonly IDependencyResolutionService _dependencyResolutionService;

        public CacheItemService(IDependencyResolutionService dependencyResolutionService)
        {
            this._dependencyResolutionService = dependencyResolutionService;
        }

        public T Get<T>(string key)
            where T: class
        {
            IAppCoreCacheItem cacheItem = _dependencyResolutionService.GetInstance<IAppCoreCacheItem>(key);

            T result = cacheItem.Get() as T;

            return result;
        }

        public T Get<T>(string key, string subKey)
            where T : class
        {
            throw new NotImplementedException();
        }
    }
}