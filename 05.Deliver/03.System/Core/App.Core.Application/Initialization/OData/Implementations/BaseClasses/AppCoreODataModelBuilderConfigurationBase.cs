using System.Web.OData.Builder;
using App.Core.Shared.Models;
using Microsoft.Web.Http;

namespace App.Core.Application.Initialization.OData.Implementations.BaseClasses
{
    public abstract class AppCoreODataModelBuilderConfigurationBase<T> : IAppCoreOdataModelBuilderConfigurationBase
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