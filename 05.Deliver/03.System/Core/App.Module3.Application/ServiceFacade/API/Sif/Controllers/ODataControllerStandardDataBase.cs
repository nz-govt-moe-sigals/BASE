namespace App.Module3.Application.ServiceFacade.API.Controllers
{
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Module3.Infrastructure.Constants.Db;

    public abstract class
        ODataControllerStandardDataBase<TEntity, TDto> : ActiveRecordStateODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {
        protected ODataControllerStandardDataBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            _dbContextIdentifier = AppModule3DbContextNames.Module3;
        }
    }
}