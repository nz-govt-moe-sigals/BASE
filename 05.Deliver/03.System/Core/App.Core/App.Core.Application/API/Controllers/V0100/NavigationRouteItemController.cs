namespace App.Core.Application.API.Controllers.V0100
{
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="MediaMetadataDto"/> messages 
    /// 
    /// </summary>
    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.NavigationRouteItem)]
    public class NavigationRouteItemController : GuidIdActiveRecordStateODataControllerBase<NavigationRoute, NavigationRouteDto>
    {
        public NavigationRouteItemController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }
    }
}