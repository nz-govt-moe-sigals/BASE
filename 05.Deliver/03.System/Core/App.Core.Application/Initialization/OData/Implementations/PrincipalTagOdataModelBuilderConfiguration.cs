namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class PrincipalTagOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<PrincipalTagDto>
    {
        public PrincipalTagOdataModelBuilderConfiguration() : base(ApiControllerNames.PrincipalTag)
        {

        }
    }


}
