namespace App.Module31.Application.Initialization.OData.Implementations
{
    using App.Module31.Application.Constants.Api;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;

    public class EducationProviderClassificationODataModelBuilderConfiguration  : AppModuleODataModelBuilderReferenceDataConfigurationBase<EducationProviderClassificationTypeDto>
    {
        public EducationProviderClassificationODataModelBuilderConfiguration() : base(ApiControllerNames.EducationProviderClassification)
        {
        }
    }
}




