using App.Core.Application.API.Controllers.Base.Base;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;
using App.Module80.Infrastructure.Constants.Db;

namespace App.Module80.Application.API.Controllers.Base
{
    public abstract class ActiveRecordStateODataControllerBase<TEntity, TDto> : ActiveRecordStateCommonODataControllerBase<TEntity, TDto> /*NO:IHasInitialize as it makes the method public wihich is not needed*/
        where TEntity : class, IHasRecordState, new()
        where TDto : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveRecordStateODataControllerBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        protected ActiveRecordStateODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier.
        }

        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="F:App.Core.Application.API.Controllers.Base.Base.DataCommonODataControllerBase`2._dbContextIdentifier" />
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected override void Initialize()
        {
            _dbContextIdentifier = AppModuleDbContextNames.Default;
        }
    }
}
