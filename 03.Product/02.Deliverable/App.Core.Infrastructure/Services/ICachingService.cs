namespace App.Core.Infrastructure.Services
{
    using System;
    using App.Core.Shared.Services;

    public interface ICachingService : IHasAppCoreService
    {
        void Register<T>(string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }
}