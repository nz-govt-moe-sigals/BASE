namespace App.Module1.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    using App.Core.Application.Initialization.OData;

    /// <summary>
    /// A Module specific implementation of
    /// IOdataModelBuilderConfigurationBase
    /// allowing for distinct Odata 'clumps of apis' (ie metadatas).
    /// separated by domain (eg: 'api/odata/core', 'api/odata/module1', etc.)
    /// </summary>
    public interface IAppModule1OdataModelBuilderConfiguration : IAppOdataModelBuilderConfiguration
    {
    }
}
