using App.Module32.Shared.Contracts;

namespace App.Module32.Shared {
    /// <summary>
    /// Unique base identifier used by this Module's
    /// common named
    /// <see cref="IHasModuleSpecificIdentifier"/>.
    /// <para>
    /// It's very important that once you create a new Module
    /// that you ensure this contract is renamed, before doing 
    /// anything. 
    /// </para>
    /// </summary>
    public interface IAppModule32
    {
    }

}


