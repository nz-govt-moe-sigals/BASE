namespace App.Core.Infrastructure.Services
{
    /// <summary>
    ///     Base class for Application,  Tier, Module, Organisation, Principal settings
    /// </summary>
    public interface IMutableSettingsService : IImmutableSetingsService
    {
        void Set<T>(string key, T value);
    }
}