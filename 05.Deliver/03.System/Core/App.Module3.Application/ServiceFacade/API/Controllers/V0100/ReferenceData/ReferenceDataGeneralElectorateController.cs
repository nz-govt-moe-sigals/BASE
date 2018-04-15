namespace App.Module3.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Application.ServiceFacade.API.Controllers;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.V0100;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class GeneralElectorateController : ODataControllerStandardDataBase<GeneralElectorate, GeneralElectorateDto>
    {
        public GeneralElectorateController(
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
        public IQueryable<GeneralElectorateDto> Get()
        {
            return InternalGet();
        }

        //[ODataRoute("({key})")]
        public GeneralElectorateDto Get(Guid key)
        {
            return InternalGet(key);
        }

        //// POST api/values 
        public void Post(GeneralElectorateDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(GeneralElectorateDto value)
        {
            InternalPut(value);
        }
    }
}