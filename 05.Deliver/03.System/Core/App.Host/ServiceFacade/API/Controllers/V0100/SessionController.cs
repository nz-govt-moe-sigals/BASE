namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class SessionController : ODataControllerStandardDataBase<Session, SessionDto>
    {
        public SessionController(
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
            this._diagnosticsTracingService.Trace(TraceLevel.Debug, "SessionController created.");
        }

        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<SessionDto> Get()
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Principal)
                //.Include(x => x.Operations)
                .ProjectTo<SessionDto>(
                    (object)null,
                    x=>x.Principal,
                    x=>x.Operations
                );
        }

        //[ODataRoute("({key})")]
        public SessionDto Get(Guid key)
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Principal)
                //.Include(x => x.Operations)
                .ProjectTo<SessionDto>(
                    (object)null,
                    x => x.Principal,
                    x => x.Operations
                ).SingleOrDefault(x => x.Id == key);
        }
    }
}