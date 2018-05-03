using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System.Web.Http;
    using App.Core.Application.Attributes;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="ConfigurationStepRecordDto"/> messages 
    /// that provide Application Support Specialists a queryable 
    /// view of what config steps were taken, so they can track 
    /// down issues by ruling out config mistakes first.
    /// </summary>
    /// <seealso cref="App.Core.Application.ServiceFacade.API.Controllers.ODataControllerBase" />
    [ODataPath(Constants.Api.ApiControllerNames.ConfigurationStepRecord)]
    public class ConfigurationStepRecordController : ODataControllerBase
    {
        private readonly IConfigurationStepService _configurationStepService;
        private readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        public ConfigurationStepRecordController(
            IUniversalDateTimeService dateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IConfigurationStepService configurationStepService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService)
        {
            this._configurationStepService = configurationStepService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;
        }

        // POST api/values 
        public IQueryable<ConfigurationStepRecordDto> Get()
        {

            return this._configurationStepService.Get().ProjectTo<ConfigurationStepRecordDto>();
        }
    }
}