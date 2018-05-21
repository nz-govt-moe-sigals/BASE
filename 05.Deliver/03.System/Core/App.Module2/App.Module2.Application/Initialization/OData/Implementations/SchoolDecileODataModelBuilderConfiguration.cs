namespace App.Module02.Application.Initialization.OData.Implementations
{
    using App.Module02.Application.Constants.Api;
    using App.Module02.Shared.Models.Messages.V0100;

    public class SchoolDecileODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<SchoolDecileDto>
    {

        public SchoolDecileODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolDecile)
        {
        }
    }
}