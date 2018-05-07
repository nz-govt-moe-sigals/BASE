namespace App.Module3.Application.Initialization.OData
{

    using App.Core.Infrastructure.Initialization.OData;
    using Microsoft.Web.OData.Builder;

    /// <summary>
    /// A Module specific implementation of
    /// IOdataModelBuilderConfigurationBase
    /// allowing for distinct Odata 'clumps of apis' (ie metadatas).
    /// separated by domain (eg: 'api/odata/core', 'api/odata/module1', etc.)
    /// </summary>
    public interface IAppModule3OdataModelBuilderConfiguration : IOdataModelBuilderConfigurationBaseStub, IModelConfiguration
    {
    }
}
