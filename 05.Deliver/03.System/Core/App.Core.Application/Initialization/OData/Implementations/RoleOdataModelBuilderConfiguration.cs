namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class RoleOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<RoleDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public RoleOdataModelBuilderConfiguration() : base(ApiControllerNames.Role)
        {

        }
    }


  
}