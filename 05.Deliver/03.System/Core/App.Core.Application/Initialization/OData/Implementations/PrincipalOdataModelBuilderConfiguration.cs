using App.Core.Application.Initialization.OData.Implementations.BaseClasses;

namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class PrincipalOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<PrincipalDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public PrincipalOdataModelBuilderConfiguration() : base(ApiControllerNames.Principal)
        {

        }
    }


  
}
