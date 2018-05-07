using App.Core.Application.Initialization.OData.Implementations.BaseClasses;

namespace App.Core.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Core.Application.Constants.Api;
using App.Core.Infrastructure.Initialization.OData;
using App.Core.Shared.Models.Messages.APIs.V0100;

    public class TenantPropertyOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<TenantPropertyDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantPropertyOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public TenantPropertyOdataModelBuilderConfiguration() : base(ApiControllerNames.TenantProperty)
        {

        }
    }
}