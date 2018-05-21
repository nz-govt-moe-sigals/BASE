namespace App.Module01.Infrastructure.Services.Implementations
{
    /// <summary>
    /// Abstract base classs for all Core Infrastructure Services.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public abstract class AppModuleServiceBase : IHasAppModuleService, IHasModuleSpecificIdentifier
    {
    }
}