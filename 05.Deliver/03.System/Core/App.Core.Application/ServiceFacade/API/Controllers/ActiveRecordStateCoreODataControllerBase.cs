using App.Core.Infrastructure.Services;

namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Shared.Models;

    public abstract class ActiveRecordStateCoreODataControllerBase<TEntity, TDto> : ActiveRecordStateODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {

        protected ActiveRecordStateCoreODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }
    }
}