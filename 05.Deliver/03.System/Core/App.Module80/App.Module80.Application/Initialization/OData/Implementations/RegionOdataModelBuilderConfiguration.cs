using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;
using App.Module80.Application.Constants.Api;
using App.Module80.Shared.Models.Messages.API;
using Microsoft.Web.Http;

namespace App.Module80.Application.Initialization.OData.Implementations
{
    public class RegionOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<RegionDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<RegionDto>(ApiControllerNames.Region).EntityType;
            entity.HasKey(x => x.RegionId);
            return entity;
        }


    }
}
