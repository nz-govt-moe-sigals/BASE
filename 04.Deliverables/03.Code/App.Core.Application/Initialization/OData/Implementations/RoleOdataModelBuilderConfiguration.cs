namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class RoleOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<RoleDto>(ApiControllerNames.Role);
            //DTO Type description:
            builder.EntityType<RoleDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<RoleDto>()
                .HasKey(x => x.Id);
        }
    }
}