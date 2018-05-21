namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Application.Attributes;
    using App.Core.Application.ServiceFacade.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;

    [ODataPath(Constants.Api.ApiControllerNames.TenantedNavigationRouteItem)]
    public class TenantedNavigationRouteItemController : GuidIdActiveRecordStateODataControllerBase<NavigationRoute, NavigationRouteDto>
    {
        public TenantedNavigationRouteItemController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }
    }
}