namespace App.Core.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Module2.Application.Constants.Api;
using App.Module2.Application.Initialization.OData;
using App.Module2.Shared.Models.Entities;

    public class EducationOrganisationODataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<EducationOrganisationDto>(ApiControllerNames.EducationOrganisation);
            //DTO Type description:
            builder.EntityType<EducationOrganisationDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<EducationOrganisationDto>()
                .HasKey(x => x.Id);
        }
    }
}