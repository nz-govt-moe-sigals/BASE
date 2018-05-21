namespace App.Module02.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Module02.Application.Constants.Api;
    using App.Module02.Application.Initialization.OData;
    using App.Module02.Shared.Models.Messages.V0100;

    public class BodyODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<BodyDto>
    {
        public BodyODataModelBuilderConfiguration() : base(ApiControllerNames.Body)
        {
        }
    }
}
