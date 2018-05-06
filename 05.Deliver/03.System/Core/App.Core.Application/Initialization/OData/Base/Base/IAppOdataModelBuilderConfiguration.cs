namespace App.Core.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    // SKYOUT: using App.Core.Infrastructure.Initialization.OData;

    /// <summary>
    /// Contract for a Model Builder Configuration fragment
    /// specific to this Module.
    /// </summary>
    public interface IAppOdataModelBuilderConfiguration // SKYOUT: : IOdataModelBuilderConfigurationBase
    {
        void Define(ODataModelBuilder builder);
    }
}