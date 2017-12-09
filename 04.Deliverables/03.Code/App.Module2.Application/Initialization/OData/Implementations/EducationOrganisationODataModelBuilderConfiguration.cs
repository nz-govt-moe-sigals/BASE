namespace App.Module2.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Module2.Application.Constants.Api;
using App.Module2.Application.Initialization.OData;
using App.Module2.Shared.Models.Entities;

    public class EducationOrganisationODataModelBuilderConfiguration : AppModule2ODataModelBuilderConfigurationBase<EducationOrganisationDto>
    {
        public EducationOrganisationODataModelBuilderConfiguration() : base(ApiControllerNames.EducationOrganisation)
        {
        }
    }
}