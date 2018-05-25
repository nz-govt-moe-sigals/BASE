namespace App.Module32.Application.ServiceFacade.API.Controllers
{
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Module32.Infrastructure.Constants.Db;

    /// <summary>
    /// Abstract Base class for OData Controllers within this specific Module.
    /// <para>
    /// Technically, DDD would stipilate that Http specific Controllers remain Dumb, 
    /// not have direct access to Repositories
    /// and instead use a Domain Service into which 
    /// a <see cref="IRepositoryService"/>
    /// is injected. At least in theory. The reality is that API Apps don't have 
    /// much logic, so there's no advantage to get overly complex right away. Hence
    /// why a Repository Service is injected into this controller.
    /// </para>
    /// <para>
    /// That said, in order for the RepositoryService to know which DbContext/Schema
    /// to work with, Controllers must defined the DbContext name.
    /// This is done within the <see cref="IInitialize"/> method defined
    /// in the underlying <see cref="ActiveRecordStateCommonODataControllerBase{TEntity,TDto}"/>
    /// </para>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public abstract class
        TenantedGuidIdActiveRecordStateODataControllerDataBase<TEntity, TDto> : TenantedGuidIdActiveRecordStateCommonODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, IHasTenantFK, new()
        where TDto : class, IHasGuidId, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantedGuidIdActiveRecordStateODataControllerDataBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="tenantService">The tenant service.</param>
        protected TenantedGuidIdActiveRecordStateODataControllerDataBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute, ITenantService tenantService) :
            base(diagnosticsTracingService, repositoryService, objectMappingService,
                secureApiMessageAttribute, principalService, tenantService)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier
        }

        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="F:App.Core.Application.ServiceFacade.API.Controllers.Base.Base.DataCommonODataControllerBase`2._dbContextIdentifier" />
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected override void Initialize()
        {
            this._dbContextIdentifier = AppModuleDbContextNames.Default;
        }


    }
}

