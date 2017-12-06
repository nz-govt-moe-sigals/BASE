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
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<EducationOrganisationDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<EducationOrganisationDto>()
                .HasKey(x => x.Id);
        }
    }
}