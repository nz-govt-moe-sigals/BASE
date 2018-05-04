namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Core.Application.Initialization.OData;
    using App.Core.Shared.Models.Entities;

    /// <summary>
    /// 
    /// <para>
    /// As for better understanding the interface inheritence,
    /// find and read first README.STRUCTUREMAP.IDEMPOTENCY.txt
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppCoreODataModelBuilderConfigurationBase<T> : IAppCoreOdataModelBuilderConfiguration
        where T: class, IHasGuidId, new()
    {
        private readonly string _controllerName;

        protected AppCoreODataModelBuilderConfigurationBase(string controllerName)
        {
            this._controllerName = controllerName;
        }

        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<T>(this._controllerName.ToLower());
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<EducationOrganisationDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<T>()
                .HasKey(x => x.Id);
        }
    }
}