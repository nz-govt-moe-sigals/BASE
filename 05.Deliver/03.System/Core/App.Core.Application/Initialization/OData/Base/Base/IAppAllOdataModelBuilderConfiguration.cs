namespace App.Core.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    using Microsoft.Web.OData.Builder;

    /// <summary>
    /// A base Contract for a Model Builder Configuration *fragment*.
    /// <para>
    /// Each Module provides a Module specific implementation of this contract
    /// (eg: IAppModuleXODataModelBuilderConfiguration) that inherits from this
    /// base contract.
    /// </para>
    /// </summary>
    public interface IAppAllOdataModelBuilderConfiguration : IModelConfiguration
    {
        void Define(ODataModelBuilder builder);
    }
}