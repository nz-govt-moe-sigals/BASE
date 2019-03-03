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
        T Get<T>(string key) where T : class;
        T Get<T>(string key, string subKey) where T : class;

    }

}