namespace App.Core.Infrastructure.Services
{
    using System;

    public interface IRedisCacheService : IHasAppCoreService
    {

        void Set<T>(string key, T value, TimeSpan? duration=null);

        void Set<T>(string key, string subKey, T value, TimeSpan? duration=null);

        T Get<T>(string key);

        T Get<T>(string key, string subKey);
    }

}