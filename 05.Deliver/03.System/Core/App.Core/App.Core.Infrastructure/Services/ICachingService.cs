namespace App.Core.Infrastructure.Services
{
    using System;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// Cache information in-mem of the local Host.
    /// <para>
    /// Only suitable for Immutable information.
    /// Consider Redis Cache Service for Muttable information
    /// shared between devices.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface ICachingService : IHasAppCoreService
    {
        void Register<T>(string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }
}