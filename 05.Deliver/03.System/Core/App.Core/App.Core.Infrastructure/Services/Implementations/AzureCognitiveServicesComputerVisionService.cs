﻿using App.Core.Infrastructure.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Services.Configuration.Implementations;

namespace App.Core.Infrastructure.Services.Implementations
{
    public class AzureCognitiveServicesComputerVisionService: AppCoreServiceBase, IAzureCognitiveServicesComputerVisionService
    {

        public AzureCognitiveServicesComputerVisionService(AzureCognitiveServicesComputerVisionServiceConfiguration azureCognitiveServicesComputerVisionServiceConfiguration )
        {

        }
    }
}
