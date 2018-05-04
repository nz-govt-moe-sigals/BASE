﻿using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module3.Application.ServiceFacade.API.Controllers;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

namespace App.Module3.Application.ServiceFacade.API.Sif.Controllers.V0100.ReferenceData
{
    using App.Core.Shared.Attributes;
    using App.Module3.Application.Constants.Api;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [Key(ApiControllerNames.TerritorialAuthority)]
    public class TerritorialAuthorityController : SIFResourceODataControllerBase<TerritorialAuthority, TerritorialAuthorityDto>
    {
        public TerritorialAuthorityController(
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
        [AllowAnonymous]
        [EnableQuery(PageSize = 100)]
        public IQueryable<TerritorialAuthorityDto> Get()
        {
            return InternalGet();
        }

        /// <summary>
        /// Gets the resource with the specified Id.
        /// <para>
        /// Note OData's convention that parameter must be 'key' (not 'id' or other).
        /// </para>
        /// </summary>
        [AllowAnonymous]
        //[ODataRoute("({key})")]
        public TerritorialAuthorityDto Get(string key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(TerritorialAuthorityDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(TerritorialAuthorityDto value)
        {
            InternalPut(value);
        }
    }
}