
namespace App.Core.Application.Initialization.OData.Implementations
{
    using System.Web.OData.Builder;
    using App.Core.Application.Constants.Api;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class ConfigurationStepRecordOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<ConfigurationStepRecordDto> //, IAppCoreOdataModelBuilderConfiguration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStepRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAppCoreOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public ConfigurationStepRecordOdataModelBuilderConfiguration() : base(ApiControllerNames.ConfigurationStepRecord)
        {
            
        }

    }
}