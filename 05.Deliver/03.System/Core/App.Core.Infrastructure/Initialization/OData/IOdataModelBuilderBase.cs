namespace App.Core.Infrastructure.Initialization.OData
{
    using App.Core.Shared.Contracts;

    /// <summary>
    /// Contract for a builder which is invoked when 
    /// at startup, to build first a common, all-inclusive
    /// OData model (ie, metadata), and then more specific
    /// (module specific) modules.
    /// <para>
    /// Note that the Initialize() method's argument 
    /// has to be an untyped oject, rather than a typed
    /// ODataModelBuilder, as
    /// a) the interface has to be in App.Core.Infrastructure
    ///    for all Modules to be able to see it (but where the Assembly
    ///    has no reference to Web specific assemblies, so no reference
    ///    to HttpConfiguration...)
    /// b) Because it is App.Core.Infrastructure, and not
    ///    App.Core.Application, it does not know about OData
    ///    types as it has no reference to this presentation 
    ///    technology (which would create a dependency on
    ///     WebAPI, etc...)
    ///  </para>
    /// </summary>
    public interface IOdataModelBuilderBase : IHasInitialize<object>
    {
        void Initialize(object /*HttpConfiguration*/ httpConfiguration);
    }
}
