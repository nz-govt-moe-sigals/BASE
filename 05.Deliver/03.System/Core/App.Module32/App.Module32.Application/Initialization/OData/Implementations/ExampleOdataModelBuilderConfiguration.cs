using App.Module32.Application.Constants.Api;
using App.Module32.Shared.Models.Messages.API.V0100;
using Microsoft.Web.Http;

namespace App.Module32.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module32.Application.Initialization.OData;

    public class ExampleOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<ExampleDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<ExampleDto>(ApiControllerNames.Example).EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }


    }

}

