namespace App.Module3.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Module3.Application.Constants.Api;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class AreaUnitODataModelBuilderConfiguration : AppModule3ODataModelBuilderReferenceDataConfigurationBase<AreaUnitDto>
    {
        public AreaUnitODataModelBuilderConfiguration() : base(ApiControllerNames.AreaUnit)
        {
        }

        public override EntityTypeConfiguration<AreaUnitDto> Define(ODataModelBuilder builder)
        {
            return base.Define(builder);

        }
    }
}