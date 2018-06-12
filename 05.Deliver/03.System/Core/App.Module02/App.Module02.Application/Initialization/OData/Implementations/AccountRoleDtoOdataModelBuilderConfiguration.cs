using App.Module02.Application.Constants.Api;
using Microsoft.Web.Http;

namespace App.Module02.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module02.Application.Initialization.OData;

    /// <summary>
    /// <para>
    /// Note that it implements the module specific
    /// <see cref="IAppModuleOdataModelBuilderConfiguration"/> -- which 
    /// is how the <see cref=""/>
    /// </para>
    /// </summary>
    public class AccountRoleDtoOdataModelBuilderConfiguration : IAppModuleOdataModelBuilderConfiguration
    {

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }


        public EntityTypeConfiguration<SecurityProfileRoleDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<SecurityProfileRoleDto>(ApiControllerNames.Example).EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }


    }

}

