using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using App.Module32.Application.Constants.Api;
using App.Module32.Shared.Models.Messages.API.V0100;
using Microsoft.Web.Http;

namespace App.Module32.Application.Initialization.OData.Implementations
{
    public class EducationStudentProviderODataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {


        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);

        }

        public EntityTypeConfiguration<StudentDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<StudentDto>(ApiControllerNames.Students).EntityType;
            entity.HasKey(x => x.StudentId);
            return entity;
        }


    }
}
