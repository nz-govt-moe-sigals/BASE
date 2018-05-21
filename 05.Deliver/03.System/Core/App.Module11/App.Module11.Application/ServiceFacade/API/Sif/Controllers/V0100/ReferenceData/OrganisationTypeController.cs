using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module11.Application.ServiceFacade.API.Controllers;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

namespace App.Module11.Application.ServiceFacade.API.Sif.Controllers.V0100.ReferenceData
{
    using App.Core.Shared.Attributes;
    using App.Module11.Application.Constants.Api;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [Key(ApiControllerNames.EducationProviderType)]
    public class EducationProviderTypeController : SIFResourceODataControllerBase<EducationProviderType, EducationProviderOrganisationTypeDto>
    {
        public EducationProviderTypeController(
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
        public IQueryable<EducationProviderOrganisationTypeDto> Get()
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
        public EducationProviderOrganisationTypeDto Get(string key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(EducationProviderOrganisationTypeDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(EducationProviderOrganisationTypeDto value)
        {
            InternalPut(value);
        }
    }
}