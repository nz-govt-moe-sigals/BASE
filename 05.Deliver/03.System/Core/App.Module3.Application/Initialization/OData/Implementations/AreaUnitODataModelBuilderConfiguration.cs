namespace App.Module3.Application.Initialization.OData.Implementations
{
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.V0100;

    public class AreaUnitODataModelBuilderConfiguration : AppModule3ODataModelBuilderConfigurationBase<AreaUnitDto>
    {
        public AreaUnitODataModelBuilderConfiguration() : base(ApiControllerNames.AreaUnit)
        {
        }
    }
}