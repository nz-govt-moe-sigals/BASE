namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class DataClassificationOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<DataClassificationDto>(ApiControllerNames.DataClassification);
            //DTO Type description:
            builder.EntityType<DataClassificationDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<DataClassificationDto>()
                .HasKey(x => x.Id);
        }
    }
}