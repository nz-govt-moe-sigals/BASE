using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages;
using App.Core.Shared.Models.Messages.API.V0100;

namespace App.Core.Application.API.Controllers.V0100
{
    public class GeoInformationController : CommonODataControllerBase
    {
        private readonly IGeoIPService _geoIpService;
        private readonly IObjectMappingService _objectMappingService;

        public GeoInformationController( IGeoIPService geoIpService, IObjectMappingService objectMappingService,
            IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService) 
            : base(diagnosticsTracingService, principalService)
        {
            _geoIpService = geoIpService;
            _objectMappingService = objectMappingService;
        }

        
        public GeoInformationDto Get()
        {
            this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"GeoLocationController.Get");
            var geoinfo = _geoIpService.Get(HttpContext.Current.Request.UserHostAddress);
            var result = this._objectMappingService.Map<GeoInformation, GeoInformationDto>(geoinfo);
            return result;
        }
    }
}
