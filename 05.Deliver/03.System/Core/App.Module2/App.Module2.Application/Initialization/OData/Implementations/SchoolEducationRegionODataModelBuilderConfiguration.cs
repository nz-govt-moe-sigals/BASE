namespace App.Module2.Application.Initialization.OData.Implementations
{
    using App.Module2.Application.Constants.Api;
    using App.Module2.Shared.Models.Messages.V0100;

    public class SchoolEducationRegionODataModelBuilderConfiguration : AppModule2ODataModelBuilderConfigurationBase<SchoolEducationRegionDto>
    {
        public SchoolEducationRegionODataModelBuilderConfiguration() : base(ApiControllerNames.SchoolEducationRegion)
        {
        }
    }
}