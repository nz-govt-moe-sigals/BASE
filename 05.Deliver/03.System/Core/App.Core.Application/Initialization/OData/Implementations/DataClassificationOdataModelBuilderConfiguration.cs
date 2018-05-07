using Microsoft.Web.Http;

namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Infrastructure.Initialization.OData;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class DataClassificationOdataModelBuilderConfiguration : IAppCoreOdataModelBuilderConfigurationBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataClassificationOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAppCoreOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public DataClassificationOdataModelBuilderConfiguration()
        {
        }

        private void ConfigureV1(ODataModelBuilder builder)
        {
            var entity = Define(builder);
            //entity.Ignore(p => p.ExtraField);

        }

        private void ConfigureV2(ODataModelBuilder builder)
        {
            Define(builder);
        }

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            switch (apiVersion.MajorVersion)
            {
                case 2:
                    ConfigureV2(builder);
                    break;
                default:
                    ConfigureV1(builder);
                    break;

            }

        }


        public EntityTypeConfiguration<DataClassificationDto> Define(ODataModelBuilder builder)
        {
            var entity = builder.EntitySet<DataClassificationDto>(ApiControllerNames.DataClassification).EntityType;
            entity.HasKey(x => x.Id);
            return entity;
        }
    }
}