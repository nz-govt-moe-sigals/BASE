namespace App.Module1.Application.ServiceFacade.API.Controllers
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module1.Infrastructure.Constants.Db;
    using AutoMapper.QueryableExtensions;

    public abstract class
        ODataControllerStandardDataBase<TEntity, TDto> : ActiveRecordStateODataControllerBase<TEntity, TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {
        public ODataControllerStandardDataBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            _dbContextIdentifier = AppModule1DbContextNames.Module1;
        }
    }
}