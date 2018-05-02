﻿using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module3.Application.ServiceFacade.API.Controllers;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

namespace App.Module3.Application.ServiceFacade.API.Sif.Controllers.V0100.ReferenceData
{
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Web.OData.Routing;
    using App.Core.Shared.Attributes;
    using App.Module3.Application.Constants.Api;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    [ODataRoutePrefix(ApiControllerNames.SchoolingGender)]
    [Key(ApiControllerNames.SchoolingGender)]
    public class SchoolingGenderController : ODataControllerSifResourceDataBase<EducationProviderGender, EducationProviderGenderDto>
    {
        public SchoolingGenderController(
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
        public IQueryable<EducationProviderGenderDto> Get()
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
        public EducationProviderGenderDto Get(string key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(EducationProviderGenderDto value)
        {
            InternalPost(value);
        }

        
        //// PUT api/values/5 
        public void Put(EducationProviderGenderDto value)
        {
            InternalPut(value);
        }
    }
}