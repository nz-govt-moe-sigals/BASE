using Microsoft.Web.Http;

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

        public virtual EntityTypeConfiguration<T> Define(ODataModelBuilder builder)
        {
            builder.EntitySet<T>(this._controllerName);
            var entity = builder.EntityType<T>();
            entity.HasKey(x => x.Id);
            return entity;
        }

        /// <summary>
        /// override this when you have more versions of an object 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="apiVersion"></param>
        public virtual void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
           Define(builder);
        }
    }


}