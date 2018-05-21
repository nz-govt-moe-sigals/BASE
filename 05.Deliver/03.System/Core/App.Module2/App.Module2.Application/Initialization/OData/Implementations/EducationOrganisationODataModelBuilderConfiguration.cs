namespace App.Module02.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Module02.Application.Constants.Api;
using App.Module02.Application.Initialization.OData;
using App.Module02.Shared.Models.Entities;

    public class EducationOrganisationODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<EducationOrganisationDto>
    {
        public EducationOrganisationODataModelBuilderConfiguration() : base(ApiControllerNames.EducationOrganisation)
        {
        }
    }
}