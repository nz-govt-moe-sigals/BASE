namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class SchoolYearLevelODataModelBuilderConfiguration  : AppModule3ODataModelBuilderReferenceDataConfigurationBase<EducationProviderYearLevelDto>
    {
        public SchoolYearLevelODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolYearLevel)
        {
        }
    }
}