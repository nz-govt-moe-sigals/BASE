namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Services;

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