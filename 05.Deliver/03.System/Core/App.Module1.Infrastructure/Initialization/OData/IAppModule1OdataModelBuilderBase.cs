namespace App.Module1.Infrastructure.Initialization.OData
{
    using App.Core.Infrastructure.Initialization.OData;

    public interface IAppModule1OdataModelBuilderBase : IOdataModelBuilderBase
    {
        // Has to remain untyped, and in App.XXX.Infrastructure, 
        // so that it can be referenced to from Intialize/DependencyResolution,
        // when looking for initializers.

    }
}