using App.Core.Application.API.Controllers.Base.CoreModule;

namespace App.Core.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.SessionOperation)]
    public class SessionOperationController : GuidIdActiveRecordStateCoreODataControllerBase<SessionOperation, SessionOperationDto>
    {
        public SessionOperationController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService, 
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute)
            : base(
                  diagnosticsTracingService, 
                  principalService, 
                  repositoryService, 
                  objectMappingService,
                  secureApiMessageAttribute
                  )
        {
        }

        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<SessionOperationDto> Get()
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Principal)
                //.Include(x => x.Operations)
                .ProjectTo<SessionOperationDto>(
                    //(object)null,
                );
        }

        //[ODataRoute("({key})")]
        public SessionOperationDto Get(Guid key)
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Principal)
                //.Include(x => x.Operations)
                .ProjectTo<SessionOperationDto>(
                    //(object)null,
                ).SingleOrDefault(x => x.Id == key);
        }
    }
}