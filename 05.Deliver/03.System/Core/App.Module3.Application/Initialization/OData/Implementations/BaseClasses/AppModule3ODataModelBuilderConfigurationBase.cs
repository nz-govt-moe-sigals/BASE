namespace App.Module3.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Module3.Application.Initialization.OData;
    using App.Module3.Shared.Models.Entities;

    /// <summary>
    /// 
    /// <para>
    /// As for better understanding the interface inheritence,
    /// find and read first README.STRUCTUREMAP.IDEMPOTENCY.txt
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppModule3ODataModelBuilderReferenceDataConfigurationBase<T> : IAppModule3OdataModelBuilderConfiguration
        where T: class, IHasId<string>,  new()
    {
        private readonly string _controllerName;

        protected AppModule3ODataModelBuilderReferenceDataConfigurationBase(string controllerName)
        {
            this._controllerName = controllerName;
        }

        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            // Note that we are registering the path in lower case.
            // And the full root with start with 
            // ApiControllerNames.PathRoot (ie, 'odata/foo' for FooController):
            builder.EntitySet<T>(this._controllerName.ToLower());

            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<EducationOrganisationDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<T>()
                .HasKey(x => x.Id);
        }
    }
}