namespace App.Module11.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Module11.Application.Constants.Api;
    using App.Module11.Application.Initialization.OData;
    using App.Module11.Shared.Models.Entities;
    using App.Module11.Shared.Models.Messages.V0100;


    public class SchoolGenderODataModelBuilderConfiguration : AppModuleODataModelBuilderConfigurationBase<SchoolGenderDto>
    {
        public SchoolGenderODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolGender)
        {
        }
    }
}





