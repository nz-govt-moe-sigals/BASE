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

    public class NotificationUpdateController : ODataControllerBase
    {
        private readonly IUniversalDateTimeService _dateTimeService;
        private readonly IRepositoryService _repositoryService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        public NotificationUpdateController(
            IUniversalDateTimeService dateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService)
        {
            this._dateTimeService = dateTimeService;
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;
        }

        // POST api/values 
        public void Post([FromBody]NotificationUpdateDto value)
        {

            var record = this._repositoryService
                .GetQueryableSet<Notification>(App.Core.Infrastructure.Constants.Db.AppCoreDbContextNames.Core).SingleOrDefault(x => x.Id == value.Id);

            if (record == null)
            {
                return;
            }
            if (value.Read)
            {
                if (record.DateTimeReadUtc.HasValue)
                {
                    // Idempotent.
                    return;
                }
                record.DateTimeReadUtc = this._dateTimeService.NowUtc().UtcDateTime;
                // That's it.
                return;
            }
            record.DateTimeReadUtc = null;
        }
    }
}