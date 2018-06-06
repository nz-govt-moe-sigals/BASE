using App.Module32.Shared.Contracts;

namespace App.Module32.Infrastructure.Services.Implementations.Base
{
    /// <summary>
    /// Abstract base classs for all Core Infrastructure Services.
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IHasAppCoreService" />
    public abstract class AppModuleServiceBase : IHasAppModuleService, IHasModuleSpecificIdentifier
    {
    }
}

