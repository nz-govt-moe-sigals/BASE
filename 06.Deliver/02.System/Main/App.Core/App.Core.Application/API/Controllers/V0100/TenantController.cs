using System.Web.Http;
using App.Core.Application.API.Controllers.Base.CoreModule;
using App.Core.Application.Filters.WebApi;
using App.Core.Shared.Constants;

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
    [WebApiAppAuthorize(Roles = "core_read")]
    [ODataPath(Constants.Api.ApiControllerNames.Tenant)]
    public class TenantController : GuidIdActiveRecordStateCoreODataControllerBase<Tenant, TenantDto>
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

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// POST api/values 
        public void Post(TenantDto value)
        {
            InternalPost(value);
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// PUT api/values/5 
        public void Put(TenantDto value)
        {
            InternalPut(value);
        }
    }
}