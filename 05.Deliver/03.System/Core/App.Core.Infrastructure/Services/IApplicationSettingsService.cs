namespace App.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an Infrastructure Service to 
    ///    manage mutable settings
    ///     shared across all Modules of the system.
    /// <para>
    ///     As they are mutable, they cannot be cached in-mem per machine.
    ///     Consider using Redis Cache after recording changes using the RepositoryService. 
    /// </para>
    /// </summary>
    public interface IApplicationSettingsService : IMutableSettingsService, IHasAppCoreService
    {
    }
}