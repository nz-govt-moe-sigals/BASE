using App.Core.Application.Initialization.OData.Implementations;

namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.API.V0100;

    public class ApplicationDescriptionOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<ApplicationDescriptionDto>
    {
        public ApplicationDescriptionOdataModelBuilderConfiguration() : base(ApiControllerNames.ApplicationDescription)
        {

        }
    }
}