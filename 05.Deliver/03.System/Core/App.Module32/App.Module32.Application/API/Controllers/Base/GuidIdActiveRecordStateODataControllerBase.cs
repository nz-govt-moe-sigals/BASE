using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;
using App.Module32.Infrastructure.Constants.Db;
using App.Module32.Shared.Constants;

namespace App.Module32.Application.API.Controllers.Base
{
    [WebApiAppAuthorize(Roles = AppModuleApiScopes.ReadScope)]
    public abstract class GuidIdActiveRecordStateODataControllerBase<TEntity, TDto> 
        : GuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {
        public GuidIdActiveRecordStateODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier
        }


        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="F:App.Core.Application.API.Controllers.Base.Base.DataCommonODataControllerBase`2._dbContextIdentifier" />
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected override void Initialize()
        {
            this._dbContextIdentifier = AppModuleDbContextNames.Default;
        }

    }
}

