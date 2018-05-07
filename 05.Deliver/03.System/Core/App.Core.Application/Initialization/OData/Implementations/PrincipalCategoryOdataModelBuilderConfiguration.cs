using App.Core.Application.Initialization.OData.Implementations.BaseClasses;

namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Shared.Models.Messages.APIs.V0100;


    public class PrincipalCategoryOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<PrincipalCategoryDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalCategoryOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public PrincipalCategoryOdataModelBuilderConfiguration() : base(ApiControllerNames.PrincipalCategory)
        {

        }
    }

  
}
