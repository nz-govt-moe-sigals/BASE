namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class DataClassificationOdataModelBuilderConfiguration : IAppCoreOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
            Define(builder as ODataModelBuilder);
        }
        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<DataClassificationDto>(ApiControllerNames.DataClassification);
            // Optional DTO Type description
            // Tip/Warning: if you define ops here, at the model level, have to relist all ops allowed (ie, it cancels the globally set operations list):
            // builder.EntityType<DataClassificationDto>().Filter(/*noparam to allow for any*/);
            builder.EntityType<DataClassificationDto>()
                .HasKey(x => x.Id);
        }
    }
}