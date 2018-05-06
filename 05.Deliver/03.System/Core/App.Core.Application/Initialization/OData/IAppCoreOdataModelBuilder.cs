namespace App.Core.Application.Initialization.OData
{

    /// <summary>
    /// Contract for a *Typed* implementation of Model Builder
    /// that will scan for just this Module's 
    /// Model Builder Configuration files.
    /// <para>
    /// Note that Instances will *not* be registered against 
    /// this interface, but will instead by registed against
    /// the *untyped* base contract (IAppCoreOdataModelBuilderBuilderBase)
    /// </para>
    /// </summary>
    public interface IAppCoreOdataModelBuilder : IAppOdataModelBuilder
    {
    }
}