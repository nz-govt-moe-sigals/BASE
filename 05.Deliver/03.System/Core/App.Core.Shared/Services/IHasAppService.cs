namespace App.Core.Shared.Services
{
    using App.Core.Shared.Contracts;

    /// <summary>
    /// Contract for all Application Services.
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from <see cref="IHasSingletonLifecycle"/>).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Shared.Contracts.IHasSingletonLifecycle" />
    public interface IHasAppService : IHasSingletonLifecycle
    {
    }
}