﻿using App.Core.Application.Initialization.OData.Implementations;

namespace App.Core.Application.Initialization.OData.Implementations
{
using System.Web.OData.Builder;
using App.Core.Application.Constants.Api;
using App.Core.Shared.Models.Messages.API.V0100;

    public class SessionOperationOdataModelBuilderConfiguration : AppCoreODataModelBuilderConfigurationBase<SessionOperationDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionOperationOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IOdataModelBuilderConfigurationBase"/> won't find them.
        /// </internal>
        public SessionOperationOdataModelBuilderConfiguration() : base(ApiControllerNames.SessionOperation)
        {

        }
    }

  
}