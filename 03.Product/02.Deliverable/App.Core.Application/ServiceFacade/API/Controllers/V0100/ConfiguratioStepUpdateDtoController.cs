using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    public class ConfiguratioStepUpdateDtoController : ODataControllerBase
    {
        private readonly IUniversalDateTimeService _dateTimeService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IRepositoryService _repositoryService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        public ConfiguratioStepUpdateDtoController(
            IUniversalDateTimeService dateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(principalService)
        {
            this._dateTimeService = dateTimeService;
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;
        }

        // POST api/values 
        public IQueryable<ConfigurationStepDto> Get()
        {

            return this._repositoryService
                .GetQueryableSet<ConfigurationStepDto>(
                    App.Core.Infrastructure.Constants.Db.AppCoreDbContextNames.Core);
        }
    }
}