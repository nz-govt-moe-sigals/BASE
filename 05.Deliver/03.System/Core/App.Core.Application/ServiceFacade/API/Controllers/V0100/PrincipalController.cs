namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.Principal)]
    public class PrincipalController : ActiveRecordStateCoreODataControllerBase<Principal, PrincipalDto>
    {
        public PrincipalController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService, 
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base
            (diagnosticsTracingService, 
                principalService, 
                repositoryService, 
                objectMappingService, 
                secureApiMessageAttribute)
        {
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<PrincipalDto> Get()
        {
            var results = InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Properties)
                //.Include(x => x.Claims)
                .ProjectTo<PrincipalDto>(
                    (object)null,
                    x => x.DataClassification,
                    x => x.Category,
                    x=>x.Tags,
                    x=>x.Properties,
                    x=>x.Claims
                );

            //results = QueryableExtensions.Include(
            //        QueryableExtensions.Include(
            //            GetDbSet()
            //            .Where(x => x.RecordState == RecordPersistenceState.Active), 
            //            x => x.Properties), x => x.Claims)
            //    .ProjectTo<PrincipalDto>()//x=>x.Names,x=>x.Channels,x=>x.Properties,x=>x.Claims
            //    ;

            return results;
        }

        //[ODataRoute("({key})")]
        public PrincipalDto Get(Guid key)
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Properties)
                //.Include(x => x.Claims)
                .ProjectTo<PrincipalDto>(
                    (object)null,
                    x => x.DataClassification,
                    x => x.Category,
                    x => x.Tags,
                    x => x.Properties,
                    x => x.Claims

                ).SingleOrDefault(x => x.Id == key);
        }
        //{
        //public void Post([FromPrincipal]PrincipalDto value)

        //// POST api/values 
        //    _dbConnection.Bodies.Add( Mapper.Map<Principal>(value));
        //}

        //// PUT api/values/5 
        //public void Put(Guid key, [FromPrincipal]PrincipalDto value)
        //{
        //}
    }
}