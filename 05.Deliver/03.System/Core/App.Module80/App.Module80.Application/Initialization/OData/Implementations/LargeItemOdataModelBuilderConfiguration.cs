using App.Module80.Application.Constants.Api;
using App.Module80.Shared.Models.Messages.API;
using Microsoft.Web.Http;

namespace App.Module80.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module80.Application.Initialization.OData;

    public class LargeItemOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<LargeItemDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<LargeItemDto>(ApiControllerNames.LargeItem).EntityType;
            entity.HasKey(x => x.Code);
            return entity;
        }


    }

}

