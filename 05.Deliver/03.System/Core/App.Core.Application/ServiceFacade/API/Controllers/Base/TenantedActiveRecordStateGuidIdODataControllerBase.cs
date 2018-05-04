using App.Core.Infrastructure.Services;

namespace App.Core.Application.ServiceFacade.API.Controllers.Base
{
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models;

    public class TenantedActiveRecordStateGuidIdODataControllerBase<TEntity, TDto> : TenantedActiveRecordStateGuidIdODataControllerCommonBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, IHasTenantFK, new()
        where TDto : class, IHasGuidId, new()
    {
        protected TenantedActiveRecordStateGuidIdODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute, IPrincipalService principalService, ITenantService tenantService) : base(diagnosticsTracingService, repositoryService, objectMappingService, secureApiMessageAttribute, principalService, tenantService)
        {
            // Note the setting of the dbcontect identifier
            // (each module will do this, specific to the module):
            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }
    }
}
