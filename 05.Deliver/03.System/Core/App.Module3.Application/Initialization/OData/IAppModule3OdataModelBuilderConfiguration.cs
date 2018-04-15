namespace App.Module3.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Module3.Infrastructure.Initialization.OData;

    /// <summary>
    /// A Module specific implementation of
    /// IOdataModelBuilderConfigurationBase
    /// allowing for distinct Odata 'clumps of apis' (ie metadatas).
    /// separated by domain (eg: 'api/odata/core', 'api/odata/module1', etc.)
    /// </summary>
    public interface IAppModule3OdataModelBuilderConfiguration : IOdataModelBuilderConfigurationBase
    {
        void Define(ODataModelBuilder builder);
    }
}
