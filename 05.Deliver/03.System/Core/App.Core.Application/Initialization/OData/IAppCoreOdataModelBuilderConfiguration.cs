namespace App.Core.Application.Initialization.OData
{


    /// <summary>
    /// Contract for a *typed* verion of 
    /// a Module specific implementation of
    /// IOdataModelBuilderConfigurationBase
    /// allowing for distinct Odata 'clumps of apis' (ie metadatas).
    /// separated by domain (eg: 'api/odata/core', 'api/odata/module1', etc.)
    /// <para>
    /// Note that Instances will *not* be registered against 
    /// this interface, but will instead by registed against
    /// the *untyped* base contract (IAppCoreOdataModelBuilderBuilderBase)
    /// </para>
    /// </summary>
    public interface IAppCoreOdataModelBuilderConfiguration : IAppOdataModelBuilderConfiguration
    {
    }
}