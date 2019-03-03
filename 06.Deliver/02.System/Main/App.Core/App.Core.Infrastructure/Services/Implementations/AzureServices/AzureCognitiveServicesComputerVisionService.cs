using App.Core.Infrastructure.Services.Configuration.Implementations;
using App.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration;

namespace App.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureCognitiveServicesComputerVisionService: AppCoreServiceBase, IAzureCognitiveServicesComputerVisionService
    {

        public AzureCognitiveServicesComputerVisionService(AzureCognitiveServicesComputerVisionServiceConfiguration azureCognitiveServicesComputerVisionServiceConfiguration )
        {

        }
    }
}
