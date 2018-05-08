using System.Web.OData.Builder;
using Microsoft.Web.Http;

namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class WardODataModelBuilderConfiguration : AppModule3ODataModelBuilderReferenceDataConfigurationBase<WardDto>
    { 
        public WardODataModelBuilderConfiguration() : base(ApiControllerNames.Ward)
        {
        }


        //public override EntityTypeConfiguration<WardDto> Define(ODataModelBuilder builder)
        //{
        //    var entity = builder.EntitySet<WardDto>(ApiControllerNames.Ward).EntityType;
        //    entity.HasKey(x => x.Id);
        //    return entity;
        //}


    }
}