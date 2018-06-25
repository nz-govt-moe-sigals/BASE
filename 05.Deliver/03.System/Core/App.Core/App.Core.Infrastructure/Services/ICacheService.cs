namespace App.Core.Infrastructure.Services
{
    using App.Core.Infrastructure.Services.Enums;
    using App.Core.Shared.Services;

    /// <summary>
    /// Base contract for an Infrastructure Service to 
    /// Cache information.
    /// <para>
    /// Only suitable for Immutable information.
    /// Consider Redis Cache Service for Muttable information
    /// shared between devices.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface ICacheItemService : IHasAppCoreService
    {
        void Get<T>(CacheType cacheType, string key, string subKey = null);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }

}