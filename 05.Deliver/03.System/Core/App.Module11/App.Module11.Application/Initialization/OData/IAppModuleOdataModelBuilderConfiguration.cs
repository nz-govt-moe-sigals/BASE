namespace App.Module11.Application.Initialization.OData
{
    using Microsoft.Web.OData.Builder;

    /// <summary>
    /// A Module specific implementation of
    /// IOdataModelBuilderConfigurationBase
    /// allowing for distinct Odata 'clumps of apis' (ie metadatas).
    /// separated by domain (eg: 'api/odata/core', 'api/odata/module1', etc.)
    /// </summary>
    public interface IAppModuleOdataModelBuilderConfiguration : IModelConfiguration, IHasModuleSpecificIdentifier
    {
    }
}
