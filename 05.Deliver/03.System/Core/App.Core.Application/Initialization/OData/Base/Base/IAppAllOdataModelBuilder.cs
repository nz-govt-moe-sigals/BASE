namespace App.Core.Application.Initialization.OData
{
    using System.Web.Http;
    using Microsoft.Web.OData.Builder;

    /// <summary>
    /// Contract for a Model Builder that will scan 
    /// all Modules for <see cref="ModelBuilderConfiguration"/> implementations,
    /// as oppossed to scanning just this module 
    /// (as <see cref="IAppCoreODataModelBuilder"/> will do).
    /// </summary>
    public interface IAppAllOdataModelBuilder 
    {
        void Initialize(HttpConfiguration httpConfiguration);
    }
}