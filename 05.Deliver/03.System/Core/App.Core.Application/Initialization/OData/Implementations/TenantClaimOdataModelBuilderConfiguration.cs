namespace App.Core.Application.Initialization.OData.Implementations
{
    using App.Core.Application.Constants.Api;
using App.Core.Shared.Models.Messages.APIs.V0100;

    public class TenantClaimOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<TenantClaimDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantClaimOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public TenantClaimOdataModelBuilderConfiguration() : base(ApiControllerNames.TenantClaim)
        {

        }
    }


}