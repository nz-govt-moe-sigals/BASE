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
        // It is important to understand that 'Shared' 
        // will *not* have any Service *implementations*.
        // The contract is only here so that Services can be implemented 
        // in both Infrastructure, and Domain, without either knowing (ie
        // havin a Reference) between the two.

        // This assmebly is to remain light and dumb, basically only for 
        // Models, Messages, and tools to factory them
        // without referncing external services.
    }
}