namespace App.Module11.Application.Initialization.OData.Implementations
{
    using App.Module11.Application.Constants.Api;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class SchoolingGenderODataModelBuilderConfiguration  : AppModule11ODataModelBuilderReferenceDataConfigurationBase<EducationProviderSchoolingGenderDto>
    {
        public SchoolingGenderODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolingGender)
        {
        }
    }
}