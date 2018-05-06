namespace App.Core.Application.Initialization.OData
{
    using System.Web.Http;
    //  SKYOUT: using App.Core.Infrastructure.Initialization.OData;

    /// <summary>
    /// Contract for a *Typed* Model Builder that will scan 
    /// all Modules for ModelBuilderConfiguration implenetations,
    /// as oppossed to scanning just this module.
    /// </summary>
    public interface IAppOdataModelBuilder /* SKYOUT: IOdataModelBuilderBase */
    {
        void Initialize(HttpConfiguration httpConfiguration);
    }
}