namespace App.Module11.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module11.Application.API.Controllers;
    using App.Module11.Shared.Models.Entities;
    using App.Module11.Shared.Models.Messages.V0100;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class SchoolTypeController : GuidIdActiveRecordStateODataControllerBase<SchoolType, SchoolTypeDto>
    {
        public SchoolTypeController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService, 
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base
            (diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<SchoolTypeDto> Get()
        {
            return InternalGet();
        }

        //[ODataRoute("({key})")]
        public SchoolTypeDto Get(Guid key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(SchoolTypeDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(SchoolTypeDto value)
        {
            InternalPut(value);
        }
    }
}





