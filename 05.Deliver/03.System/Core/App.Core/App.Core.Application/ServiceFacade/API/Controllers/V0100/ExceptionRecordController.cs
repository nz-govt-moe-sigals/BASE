namespace App.Core.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="ExceptionRecordDto"/> messages 
    /// for Application Support Specialists to 
    /// query what Exceptions have happened of late.
    /// </summary>
    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.ExceptionRecord)]
    public class ExceptionRecordController : GuidIdActiveRecordStateODataControllerBase<ExceptionRecord, ExceptionRecordDto>
    {
        public ExceptionRecordController(
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
        public IQueryable<ExceptionRecordDto> Get()
        {
            return InternalGet();
                    }

        //[ODataRoute("({key})")]
        public ExceptionRecordDto Get(Guid key)
        {
            return InternalGet(key);
        }

    }
}