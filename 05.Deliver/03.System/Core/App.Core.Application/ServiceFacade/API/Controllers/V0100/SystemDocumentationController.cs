﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Application.Attributes;
    using App.Core.Infrastructure.Services;

    /// <summary>
    /// Controller for returning 
    /// * Cookie Policy Document Text
    /// * Privacy Document Text
    /// * Data Usage Document
    /// </summary>
    [ODataPath(Constants.Api.ApiControllerNames.SystemDocumentation)]
    public class SystemDocumentationController : ODataControllerCommonBase
    {
        public SystemDocumentationController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) : base(diagnosticsTracingService, principalService)
        {
            throw new ToDoException("SystemDocumentationController");
        }
    }
}