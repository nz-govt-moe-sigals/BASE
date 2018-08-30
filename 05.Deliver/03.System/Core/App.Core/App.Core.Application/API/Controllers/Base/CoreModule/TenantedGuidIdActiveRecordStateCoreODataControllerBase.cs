using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;
using App.Core.Shared.Models;

namespace App.Core.Application.API.Controllers.Base.CoreModule
{
    [WebApiAppAuthorize(Roles = AppModuleApiScopes.ReadScope)]
    public class TenantedGuidIdActiveRecordStateCoreODataControllerBase<TEntity, TDto> 
        : TenantedGuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, IHasTenantFK, new()
        where TDto : class, IHasGuidId, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantedGuidIdActiveRecordStateCoreODataControllerBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        protected TenantedGuidIdActiveRecordStateCoreODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute, IPrincipalService principalService, ITenantService tenantService) : base(diagnosticsTracingService, repositoryService, objectMappingService, secureApiMessageAttribute, principalService, tenantService)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier

        }

        protected override void Initialize()
        {
            // Note the setting of the dbcontect identifier
            // (each module will do this, specific to the module):
            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }
    }
}
