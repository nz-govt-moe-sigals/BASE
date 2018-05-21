namespace App.Module31.Application.Initialization.OData.Implementations
{
    using App.Module31.Application.Constants.Api;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;

    public class RegionalCouncilODataModelBuilderConfiguration  : AppModuleODataModelBuilderReferenceDataConfigurationBase<RegionalCouncilDto>
    {
        public RegionalCouncilODataModelBuilderConfiguration() : base(ApiControllerNames.RegionalCouncil)
        {
        }
    }
}




