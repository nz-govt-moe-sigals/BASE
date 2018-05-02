namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class EducationProviderTypeODataModelBuilderConfiguration : AppModule3ODataModelBuilderReferenceDataConfigurationBase<OrganisationTypeDto>
    {
        public EducationProviderTypeODataModelBuilderConfiguration() : base(ApiControllerNames.EducationProviderType)
        {
        }
    }
}