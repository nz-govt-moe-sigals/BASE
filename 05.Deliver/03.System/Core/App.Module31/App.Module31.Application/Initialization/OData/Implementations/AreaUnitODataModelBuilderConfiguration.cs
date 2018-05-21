namespace App.Module31.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Module31.Application.Constants.Api;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;

    public class AreaUnitODataModelBuilderConfiguration : AppModuleODataModelBuilderReferenceDataConfigurationBase<AreaUnitDto>
    {
        public AreaUnitODataModelBuilderConfiguration() : base(ApiControllerNames.AreaUnit)
        {
        }

       
    }
}




