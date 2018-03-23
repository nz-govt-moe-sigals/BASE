//namespace App.Core.Infrastructure.Initialization.OData
//{
//    /// <summary>
//    /// Contract for a *Typed* implementation of Model Builder
//    /// that will scan for just this Module's 
//    /// Model Builder Configuration files.
//    /// <para>
//    /// Note that the Initialize() method's argument 
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
//    public interface IAppCoreOdataModelBuilderBase : IOdataModelBuilderBase
//    {
//        // Has to remain untyped, and in App.XXX.Infrastructure, 
//        // so that it can be referenced to from Intialize/DependencyResolution/OData,
//        // when looking for initializers
//    }
//}

