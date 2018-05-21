namespace App.Module11.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Module11.Application.Constants.Api;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class AreaUnitODataModelBuilderConfiguration : AppModule11ODataModelBuilderReferenceDataConfigurationBase<AreaUnitDto>
    {
        public AreaUnitODataModelBuilderConfiguration() : base(ApiControllerNames.AreaUnit)
        {
        }

       
    }
}