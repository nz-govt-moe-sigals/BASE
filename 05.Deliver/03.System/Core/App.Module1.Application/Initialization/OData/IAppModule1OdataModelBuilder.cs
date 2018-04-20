namespace App.Module2.Application.Initialization.OData
{
    using System.Web.Http;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Module2.Infrastructure.Initialization.OData;

    /// <summary>
    /// A Module specific, and Typed, impelementation
    /// of <see cref="IOdataModelBuilderBase"/>,
    /// which is untyped, and in App.Core.Infrastructure, 
    /// where it can be found by all modules.
    /// </summary>
    public interface IAppModule1OdataModelBuilder : IAppModule1OdataModelBuilderBase
    {
        void Initialize(HttpConfiguration httpConfiguration);
    }
}