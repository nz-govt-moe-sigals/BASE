namespace App.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a Service to manage mutable settings
    ///     shared across all Modules of the system.
    /// </summary>
    public interface IApplicationSettingsService : IMutableSettingsService, IHasAppCoreService
    {
    }
}