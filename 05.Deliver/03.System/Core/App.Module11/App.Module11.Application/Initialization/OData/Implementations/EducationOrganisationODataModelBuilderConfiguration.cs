namespace App.Module11.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Module11.Application.Constants.Api;
using App.Module11.Application.Initialization.OData;
using App.Module11.Shared.Models.Entities;

    public class EducationOrganisationODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<EducationOrganisationDto>
    {
        public EducationOrganisationODataModelBuilderConfiguration() : base(ApiControllerNames.EducationOrganisation)
        {
        }
    }
}





