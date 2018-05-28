namespace App.Module31.Application.Initialization.OData.Implementations
{
    using App.Module31.Application.Constants.Api;
    using App.Module31.Shared.Models.Messages.API.SIF.V0100;

    public class WardODataModelBuilderConfiguration  : AppModuleODataModelBuilderReferenceDataConfigurationBase<WardDto>
    {
        public WardODataModelBuilderConfiguration() : base(ApiControllerNames.Ward)
        {
        }
    }
}




