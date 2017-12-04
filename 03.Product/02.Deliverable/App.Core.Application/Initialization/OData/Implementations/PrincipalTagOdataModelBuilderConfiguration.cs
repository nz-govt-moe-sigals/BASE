namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class PrincipalTagOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {

        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<PrincipalTagDto>(ApiControllerNames.PrincipalTag);

            //DTO Type description:
            builder.EntityType<PrincipalTagDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<PrincipalTagDto>()
                .HasKey(x => x.Id);
        }
    }
}
