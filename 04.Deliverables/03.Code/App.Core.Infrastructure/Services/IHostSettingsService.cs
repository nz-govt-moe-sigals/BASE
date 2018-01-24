namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Services;



    /// <summary>
    /// Contract for an common Infrastructure Service to 
    /// manage Host specific, immutable Settings
    /// (commonly this wraps web.config, etc. settings
    /// that were injected at deployment time by the 
    /// Build Engine).
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IImmutableSetingsService" />
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface IHostSettingsService : IImmutableSetingsService, IHasAppCoreService
    {
        /// <summary>
        ///     Create a Configuration object and fill properties from Host Settings with the same name.
        ///     <para>
        ///         Note that default values are not provided if the property value = default(T)
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <returns></returns>
        T GetObject<T>(string prefix = null) where T : class;
    }
}