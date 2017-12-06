namespace App.Core.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Core.Application.Constants.Api;
using App.Core.Shared.Models.Messages.APIs.V0100;

    public class TenantClaimOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<TenantClaimDto>(ApiControllerNames.TenantClaim);
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<TenantClaimDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<TenantClaimDto>()
                .HasKey(x => x.Id);
        }
    }
}