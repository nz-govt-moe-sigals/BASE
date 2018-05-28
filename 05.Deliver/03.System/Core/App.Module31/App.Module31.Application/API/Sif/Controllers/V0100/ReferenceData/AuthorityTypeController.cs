using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module31.Application.API.Controllers;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.API.SIF.V0100;

namespace App.Module31.Application.API.Sif.Controllers.V0100.ReferenceData
{
    using App.Core.Shared.Attributes;
    using App.Module31.Application.Constants.Api;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [Key(ApiControllerNames.AuthorityType)]
    public class AuthorityTypeController : SIFResourceODataControllerBase<AuthorityType, AuthorityTypeDto>
    {
        public AuthorityTypeController(
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
        public IQueryable<AuthorityTypeDto> Get()
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
        public AuthorityTypeDto Get(string key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(AuthorityTypeDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(AuthorityTypeDto value)
        {
            InternalPut(value);
        }
    }
}




