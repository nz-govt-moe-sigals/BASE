namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class DataClassificationOdataModelBuilderConfiguration : IAppCoreOdataModelBuilderConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataClassificationOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public DataClassificationOdataModelBuilderConfiguration()
        {
        }

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