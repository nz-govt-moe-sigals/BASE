namespace App.Module2.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Module2.Application.Constants.Api;
    using App.Module2.Application.Initialization.OData;
    using App.Module2.Shared.Models.Messages.V0100;

    public class BodyODataModelBuilderConfiguration : AppModule2ODataModelBuilderConfigurationBase<BodyDto>
    {
        public BodyODataModelBuilderConfiguration() : base(ApiControllerNames.Body)
        {
        }
    }
}
