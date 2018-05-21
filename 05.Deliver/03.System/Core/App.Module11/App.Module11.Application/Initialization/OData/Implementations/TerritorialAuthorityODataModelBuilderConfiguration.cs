namespace App.Module11.Application.Initialization.OData.Implementations
{
    using App.Module11.Application.Constants.Api;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class TerritorialAuthorityODataModelBuilderConfiguration  : AppModule11ODataModelBuilderReferenceDataConfigurationBase<TerritorialAuthorityDto>
    {
        public TerritorialAuthorityODataModelBuilderConfiguration() : base(ApiControllerNames.TerritorialAuthority)
        {
        }
    }
}