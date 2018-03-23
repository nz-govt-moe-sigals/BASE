namespace App.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base class for <see cref="IMutableSettingsService" />
    /// </summary>
    public interface IImmutableSetingsService : IHasAppCoreService
    {
        /// <summary>
        ///     Return a single Host Setting, typed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T Get<T>(string key, T defaultValue);
    }
}