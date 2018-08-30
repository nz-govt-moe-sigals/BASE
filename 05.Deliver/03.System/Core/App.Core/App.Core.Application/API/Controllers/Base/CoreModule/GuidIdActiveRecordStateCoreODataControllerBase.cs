using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Constants.Db;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;
using App.Core.Shared.Models;

namespace App.Core.Application.API.Controllers.Base.CoreModule
{
    [WebApiAppAuthorize(Roles = AppModuleApiScopes.ReadScope)]
    public abstract class GuidIdActiveRecordStateCoreODataControllerBase<TEntity, TDto> 
        : GuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidIdActiveRecordStateCoreODataControllerBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        protected GuidIdActiveRecordStateCoreODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
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