namespace App.Module3.Application.ServiceFacade.API.Base
{
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Module3.Infrastructure.Constants.Db;

    public abstract class
        GuidIdActiveRecordStateODataControllerBase<TEntity, TDto> : GuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveRecordStateGuidIdODataControllerStandardDataBase{TEntity, TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        protected GuidIdActiveRecordStateODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier.
        }

        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="F:App.Core.Application.ServiceFacade.API.Controllers.Base.Base.DataODataControllerCommonBase`2._dbContextIdentifier" />
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected override void Initialize()
        {
            this._dbContextIdentifier = AppModule3DbContextNames.Module3;
        }
    }
}