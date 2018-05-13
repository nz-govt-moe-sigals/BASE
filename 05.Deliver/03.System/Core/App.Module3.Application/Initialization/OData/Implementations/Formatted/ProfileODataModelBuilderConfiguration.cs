
using System.Web.OData.Builder;
using App.Module3.Application.Constants.Api;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using Microsoft.Web.Http;

namespace App.Module3.Application.Initialization.OData.Implementations.Formatted
{
    public class ProfileODataModelBuilderConfiguration : IAppModule3OdataModelBuilderConfiguration
    {
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);

        }

        public EntityTypeConfiguration<SifProviderDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<SifProviderDto>(ApiControllerNames.FormattedProvider).EntityType;
            entity.HasKey(x => x.LocalId);
            return entity;
        }
    }
}
