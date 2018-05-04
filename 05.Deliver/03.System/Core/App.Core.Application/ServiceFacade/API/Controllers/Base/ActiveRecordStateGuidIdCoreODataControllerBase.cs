using App.Core.Infrastructure.Services;

namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models;

    public abstract class ActiveRecordStateGuidIdCoreODataControllerBase<TEntity, TDto> : ActiveRecordStateGuidIdODataControllerCommonBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {

        protected ActiveRecordStateGuidIdCoreODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            // Note the setting of the dbcontect identifier
            // (each module will do this, specific to the module):
            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }
    }
}