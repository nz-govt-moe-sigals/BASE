using System.Web.OData.Builder;
using App.Core.Shared.Models;
using Microsoft.Web.Http;

namespace App.Core.Application.Initialization.OData.Implementations
{

    /// <summary>
    /// Module Specific
    /// OData Model Definition.
    /// Invoked by a Model Builder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppCoreODataModelBuilderConfigurationBase<T> : IAppCoreOdataModelBuilderConfiguration
        where T : class, IHasGuidId, new()
    {
        private readonly string _controllerName;

        protected AppCoreODataModelBuilderConfigurationBase(string controllerName)
        {
            this._controllerName = controllerName;
        }

        public  EntityTypeConfiguration<T> Define(ODataModelBuilder builder)

        {
            var entity = builder.EntitySet<T>(this._controllerName).EntityType;
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