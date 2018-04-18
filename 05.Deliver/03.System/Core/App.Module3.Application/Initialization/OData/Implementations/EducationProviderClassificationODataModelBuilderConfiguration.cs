namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.V0100;

    public class EducationProviderClassificationODataModelBuilderConfiguration  : AppModule3ODataModelBuilderReferenceDataConfigurationBase<EducationProviderClassificationDto>
    {
        public EducationProviderClassificationODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolClassification)
        {
        }
    }
}