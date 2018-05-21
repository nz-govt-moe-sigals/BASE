namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using System.Runtime.Caching;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ICachingService" />
    ///     Infrastructure Service Contract
    /// </summary>
    public class CachingService : AppCoreServiceBase, ICachingService
    {
        private readonly IUniversalDateTimeService _dateTimeService;

        public CachingService(IUniversalDateTimeService dateTimeService)
        {
            this._dateTimeService = dateTimeService;
        }

        public void Register<T>(string key, T value, TimeSpan duration, Func<T> expiredCallback)
        {
            if (duration.TotalSeconds < 60)
            {
                duration = TimeSpan.FromSeconds(60);
            }

            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy cacheItemPolicy =
                new CacheItemPolicy
                {
                    AbsoluteExpiration = this._dateTimeService.NowUtc().Add(duration)
                };

            // We want the item to be be self-invoking
            cacheItemPolicy.RemovedCallback = (CacheEntryRemovedArguments arguments) =>
            {
                //Get the current (future) value:
                value = expiredCallback();
                //Reset it, reusing the policy (ie, duration), and callback:
                arguments.Source.Set(arguments.CacheItem.Key, value, cacheItemPolicy, regionName: null);
            };

            cache.Set(key, value, cacheItemPolicy);
        }

    }
}