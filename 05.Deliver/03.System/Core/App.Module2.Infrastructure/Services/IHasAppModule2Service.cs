namespace App.Module2.Infrastructure.Services
{
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Services;

    /// <summary>
    /// Contract for all Module Application Services.
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from <see cref="IHasSingletonLifecycle"/>)
    /// and allowing for filtering per Core/Module.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Services.IHasAppService" />
    public interface IHasAppModule2Service : IHasAppService
    {
    }
}