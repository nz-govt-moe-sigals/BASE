namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class RoleController : ODataControllerStandardDataBase<SystemRole, RoleDto>
    {
        public RoleController(
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
        public IQueryable<RoleDto> Get()
        {
            return InternalGet();
        }

        //[ODataRoute("({key})")]
        public RoleDto Get(Guid key)
        {
            return InternalGet(key);
        }

    }
}