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
    [Key(ApiControllerNames.CommunityBoard)]
    public class CommunityBoardController : SIFResourceODataControllerBase<CommunityBoard, CommunityBoardDto>
    {
        public CommunityBoardController(
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
        public IQueryable<CommunityBoardDto> Get()
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
        public CommunityBoardDto Get(string key)
        {
            return InternalGet(key);
        }

    }
}