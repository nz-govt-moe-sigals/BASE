namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class RegionODataModelBuilderConfiguration  : AppModule3ODataModelBuilderReferenceDataConfigurationBase<RegionDto>
    {
        public RegionODataModelBuilderConfiguration() : base(ApiControllerNames.Region)
        {
        }
    }
}