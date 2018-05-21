using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using App.Module11.Application.Constants.Api;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;
using Microsoft.Web.Http;

namespace App.Module11.Application.Initialization.OData.Implementations
{
    public class SchooDirectoryODataModelBuilderConfiguration : IAppModule11OdataModelBuilderConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);


        }


        public EntityTypeConfiguration<SchoolDirectoryDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<SchoolDirectoryDto>(ApiControllerNames.SchoolsDirectory).EntityType;
            entity.HasKey(x => x.SchoolNumber);
            return entity;
        }
    }
}