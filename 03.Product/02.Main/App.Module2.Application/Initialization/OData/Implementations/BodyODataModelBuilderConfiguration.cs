namespace App.Core.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Core.Shared.Models.Messages.APIs.V0100;
using App.Module2.Application.Constants.Api;
using App.Module2.Application.Initialization.OData;
using App.Module2.Shared.Models.Messages.V0100;

    public class BodyODataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }

        public void Define(ODataModelBuilder builder)
        {

            builder.EntitySet<BodyDto>(ApiControllerNames.Body);
            //DTO Type description:
            builder.EntityType<BodyDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<BodyDto>()
                .HasKey(x => x.Id);
            
        }
    }
}
