namespace App.Core.Application.Initialization.OData
{
    using System.Web.OData.Builder;
    /// <summary>
    /// Contract for a Model Builder Configuration fragment
    /// specific to this Module.
    /// </summary>
    public interface IAppOdataModelBuilderConfiguration 
    {
        void Define(ODataModelBuilder builder);
    }
}