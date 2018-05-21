using Microsoft.Web.OData.Builder;

namespace App.Module02.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    using App.Core.Application.Initialization.OData;

    /// <summary>
    /// A Module specific implementation of
    /// <see cref="IOdataModelBuilderConfigurationBaseStub"/>
    /// allowing for defining odata apis 'clumped by module' (ie distinct metadatas...)
    /// </summary>
    public interface IAppModuleOdataModelBuilderConfiguration : IModelConfiguration, IHasModuleSpecificIdentifier
    {


    }


}
