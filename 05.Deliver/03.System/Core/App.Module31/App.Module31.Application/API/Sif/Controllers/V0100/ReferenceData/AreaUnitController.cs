using System.Linq;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module31.Application.API.Controllers;
using App.Module31.Shared.Models.Entities;
using App.Module31.Shared.Models.Messages.API.SIF.V0100;

namespace App.Module31.Application.API.Sif.Controllers.V0100.ReferenceData
{
    using System.Web.OData.Routing;
    using App.Core.Shared.Attributes;
    using App.Module31.Application.Constants.Api;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    //[ODataRoutePrefix("areaunit")]
    //[Key(ApiControllerNames.AreaUnit)]
    public class AreaUnitController : SIFResourceODataControllerBase<AreaUnit, AreaUnitDto>
    {
        public AreaUnitController(
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
        public IQueryable<AreaUnitDto> Get()
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
        public AreaUnitDto Get(string key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(AreaUnitDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(AreaUnitDto value)
        {
            InternalPut(value);
        }
    }
}




