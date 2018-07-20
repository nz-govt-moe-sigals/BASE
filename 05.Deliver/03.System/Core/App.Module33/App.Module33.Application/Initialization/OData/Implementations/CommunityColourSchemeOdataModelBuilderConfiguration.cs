using App.Module33.Application.Constants.Api;
using App.Module33.Shared.Models.Messages.API.V0100;
using Microsoft.Web.Http;

namespace App.Module33.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module33.Application.Initialization.OData;

    public class CommunityColourSchemeOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<CommunityColourSchemeDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<CommunityColourSchemeDto>(ApiControllerNames.CommunityColourScheme).EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }


    }

}

