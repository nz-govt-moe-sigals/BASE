namespace App.Core.Application.Initialization.OData.Implementations
{

    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class PrincipalCategoryOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {

        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<PrincipalCategoryDto>(ApiControllerNames.PrincipalCategory);

            //DTO Type description:
            builder.EntityType<PrincipalCategoryDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<PrincipalCategoryDto>()
                .HasKey(x => x.Id);
        }
    }
}
