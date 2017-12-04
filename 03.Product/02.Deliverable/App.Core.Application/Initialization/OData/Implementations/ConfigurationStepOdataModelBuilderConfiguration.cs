namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class ConfigurationStepOdataModelBuilderConfiguration : IOdataModelBuilderConfiguration
    {
        public void Define(object builder)
        {
           Define(builder as ODataModelBuilder);
        }

        public void Define(ODataModelBuilder builder)
        {
            builder.EntitySet<ConfigurationStepDto>(ApiControllerNames.ConfigurationStep);
            //DTO Type description:
            builder.EntityType<ConfigurationStepDto>().Filter(); //Can be noparam to allow for any.
            builder.EntityType<ConfigurationStepDto>()
                .HasKey(x => x.Id);
        }

    }
}