namespace App.Module11.Application.Initialization.OData.Implementations
{
    using App.Module11.Application.Constants.Api;
    using App.Module11.Shared.Models.Messages.V0100;

    public class SchoolDecileODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<SchoolDecileDto>
    {

        public SchoolDecileODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolDecile)
        {
        }
    }
}





