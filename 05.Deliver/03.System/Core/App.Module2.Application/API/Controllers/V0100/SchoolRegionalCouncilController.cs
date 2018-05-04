﻿namespace App.Module2.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Application.ServiceFacade.API.Controllers;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.V0100;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class SchoolRegionalCouncilController : ODataControllerStandardDataBase<SchoolRegionalCouncil, SchoolRegionalCouncilDto>
    {
        public SchoolRegionalCouncilController(
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
        public IQueryable<SchoolRegionalCouncilDto> Get()
        {
            return InternalGet();
        }

        //[ODataRoute("({key})")]
        public SchoolRegionalCouncilDto Get(Guid key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(SchoolRegionalCouncilDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(SchoolRegionalCouncilDto value)
        {
            InternalPut(value);
        }
    }
}