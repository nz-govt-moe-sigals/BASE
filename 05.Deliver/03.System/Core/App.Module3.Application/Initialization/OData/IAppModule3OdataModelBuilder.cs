namespace App.Module3.Application.Initialization.OData
{
    using System.Web.Http;
    using App.Core.Application.Initialization.OData;


    /// <summary>
    /// A Module specific, and Typed, impelementation
    /// of <see cref="IOdataModelBuilderBase"/>,
    /// which is untyped, and in App.Core.Infrastructure, 
    /// where it can be found by all modules.
    /// <para>
    /// Used for auto-discovery at startup, in order to build up the Module specific
    /// OData Meta Model, made up of these discovered/registered Odata Models.
    /// </para>
    /// <para>
    /// Inherits from the common untyped
    /// <see cref="App.Core.Infrastructure.Initialization.OData.IOdataModelBuilderBase"/>
    /// but makes it Module specific. 
    /// </para>
    /// </summary>    
    public interface IAppModule3OdataModelBuilder : IAppOdataModelBuilder
    {
    }
}