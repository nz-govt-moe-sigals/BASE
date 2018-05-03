namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class PrincipalPropertyOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<PrincipalPropertyDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalPropertyOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public PrincipalPropertyOdataModelBuilderConfiguration() : base(ApiControllerNames.PrincipalProperty)
        {

        }
    }

   
}
