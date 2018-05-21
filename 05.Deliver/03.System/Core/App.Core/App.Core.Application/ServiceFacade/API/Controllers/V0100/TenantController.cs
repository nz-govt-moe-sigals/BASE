using System.Web.Http;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.ServiceFacade.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.Tenant)]
    [AllowAnonymous]
    public class TenantController : GuidIdActiveRecordStateODataControllerBase<Tenant, TenantDto>
    {
        public TenantController(
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
        public IQueryable<TenantDto> Get()
        {
            var results = InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Properties)
                //.Include(x => x.Claims)
                .ProjectTo<TenantDto>(
                    (object)null,
                    x => x.DataClassification,
                    x => x.Properties,
                    x => x.Claims
                );

            return results;
        }

        //[ODataRoute("({key})")]
        public TenantDto Get(Guid key)
        {
            return InternalGetDbSet()
                .Where(x => x.RecordState == RecordPersistenceState.Active)
                //.Include(x => x.Properties)
                //.Include(x => x.Claims)
                .ProjectTo<TenantDto>(
                    (object)null,
                    x=>x.DataClassification,
                    x=>x.Properties,
                    x=>x.Claims
                ).SingleOrDefault(x => x.Id == key);
        }

        //// POST api/values 
        public void Post(TenantDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(TenantDto value)
        {
            InternalPut(value);
        }
    }
}