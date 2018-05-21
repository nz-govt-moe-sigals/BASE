using Microsoft.Web.Http;

namespace App.Module2.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models;
    using App.Module2.Application.Initialization.OData;
    using App.Module2.Shared.Models.Entities;

    /// <summary>
    /// <para>
    /// As for better understanding the interface inheritence,
    /// find and read first README.STRUCTUREMAP.IDEMPOTENCY.txt
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppModule2ODataModelBuilderConfigurationBase<T> : IAppModule2OdataModelBuilderConfiguration
        where T: class, IHasGuidId, new()
    {
        private readonly string _controllerName;

        protected AppModule2ODataModelBuilderConfigurationBase(string controllerName)
        {
            this._controllerName = controllerName;
        }

        public EntityTypeConfiguration<T1> Define<T1>(ODataModelBuilder builder)
            where T1 : class, IHasGuidId, new()
        {
            var entity = builder.EntitySet<T1>(this._controllerName).EntityType;
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
            Define<T>(builder);
        }
    }
}