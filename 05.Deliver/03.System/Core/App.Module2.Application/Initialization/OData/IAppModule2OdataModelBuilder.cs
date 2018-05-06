namespace App.Module2.Application.Initialization.OData
{
    using System.Web.Http;
    using App.Core.Application.Initialization.OData;

    /// <summary>
    /// A Module specific, and Typed, impelementation
    /// of <see cref="IOdataModelBuilderBase"/>,
    /// which is untyped, and in App.Core.Infrastructure, 
    /// where it can be found by all modules.
    /// </summary>
    public interface IAppModule2OdataModelBuilder : IAppOdataModelBuilder
    {
    }
}