namespace App.Core.Application.Initialization.OData
{
    using System.Web.OData.Builder;

    public interface IOdataModelBuilderConfiguration : App.Core.Infrastructure.Initialization.OData.IOdataModelBuilderConfigurationBase
    {
        void Define(ODataModelBuilder builder);
    }
}