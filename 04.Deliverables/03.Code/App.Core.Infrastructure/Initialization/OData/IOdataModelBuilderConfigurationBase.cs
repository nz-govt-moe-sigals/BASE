
namespace App.Core.Infrastructure.Initialization.OData
{

    /// <summary>
    /// <para>
    /// Note that the Define() method's argument 
    /// has to be an untyped oject, rather than a typed
    /// ODataModelBuilder, as
    /// a) the interface has to be in App.Core.Infrastructure
    ///    for all Modules to be able to see it.
    /// b) Because it is App.Core.Infrastructure, and not
    ///    App.Core.Application, it does not know about OData
    ///    types as it has no reference to this presentation 
    ///    technology (which would create a dependency on
    ///     WebAPI, etc...)
    /// than </para>
    /// </summary>
    public interface IOdataModelBuilderConfigurationBase
    {
        /// <summary>
        /// <para>
        /// Note that the Define() method's argument 
        /// has to be an untyped oject, rather than a typed
        /// ODataModelBuilder, as
        /// a) the interface has to be in App.Core.Infrastructure
        ///    for all Modules to be able to see it.
        /// b) Because it is App.Core.Infrastructure, and not
        ///    App.Core.Application, it does not know about OData
        ///    types as it has no reference to this presentation 
        ///    technology (which would create a dependency on
        ///     WebAPI, etc...)
        /// than </para>
        /// </summary>
        /// <param name="builder"></param>
        void Define(/*ODataModelBuilder*/ object builder);
    }
}