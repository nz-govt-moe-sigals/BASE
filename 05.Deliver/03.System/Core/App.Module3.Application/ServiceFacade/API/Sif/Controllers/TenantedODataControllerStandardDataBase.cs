namespace App.Module3.Application.ServiceFacade.API.Controllers
{
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Module3.Infrastructure.Constants.Db;

    public abstract class
        TenantedODataControllerStandardDataBase<TEntity, TDto> : TenantedActiveRecordStateGuidIdODataControllerCommonBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, IHasTenantFK, new()
        where TDto : class, IHasGuidId, new()
    {
        protected TenantedODataControllerStandardDataBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute, ITenantService tenantService) :
            base(diagnosticsTracingService,repositoryService, objectMappingService,
                secureApiMessageAttribute,principalService, tenantService )
        {
            this._dbContextIdentifier = AppModule3DbContextNames.Module3;
        }
    }
}