//namespace App.Core.Infrastructure.Initialization.OData
//{
//    /// <summary>
//    /// An untyped Module specific implementation of 
//    /// <see cref="IOdataModelBuilderConfigurationBase"/>,
//    /// which is an untyped implemention of an 
//    /// IModelBuilderConfiguration implementation
//    /// <para>
//    /// Note that the Define() method's argument 
//    /// has to be an untyped oject, rather than a typed
//    /// ODataModelBuilder, as
//    /// a) the interface has to be in App.Core.Infrastructure
//    ///    for this Module's Registry to be able to see it.
//    /// b) Because it is App.Core.Infrastructure, and not
//    ///    App.Core.Application, it does not know about OData
//    ///    types as it has no reference to this presentation 
//    ///    technology (which would create a dependency on
//    ///     WebAPI, etc...)
//    /// </para>
//    /// </summary>
//    public interface IAppCoreODataModelBuilderConfigurationBase : IOdataModelBuilderConfigurationBase
//    {
//    }
//}
