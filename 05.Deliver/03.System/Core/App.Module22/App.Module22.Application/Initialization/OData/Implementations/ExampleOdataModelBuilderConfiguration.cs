using App.Module22.Application.Constants.Api;
using Microsoft.Web.Http;

namespace App.Module22.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module22.Application.Initialization.OData;

    public class CourseOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<CourseDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<CourseDto>(ApiControllerNames.Course).EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }


    }

}

