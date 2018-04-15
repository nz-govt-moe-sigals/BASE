namespace App.Module3.Infrastructure.Initialization.OData
{
    using App.Core.Infrastructure.Initialization.OData;

    /// <summary>
    /// Used for auto-discovery at startup, in order to build up the Module specific
    /// OData Meta Model, made up of these discovered/registered Odata Models.
    /// <para>
    /// Inherits from the common 
    /// <see cref="App.Core.Infrastructure.Initialization.OData.IOdataModelBuilderBase"/>
    /// but makes it Module specific. 
    /// </para>
    /// <para>
    /// Has to remain untyped, and in App.XXX.Infrastructure, 
    /// so that it can be referenced to from Intialize/DependencyResolution,
    /// when looking for initializers.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Initialization.OData.IOdataModelBuilderBase" />
    public interface IAppModule3OdataModelBuilderBase : IOdataModelBuilderBase
    {

    }
}