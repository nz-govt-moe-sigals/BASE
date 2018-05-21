using Microsoft.Web.Http;

namespace App.Core.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="DataClassificationDto"/> messages 
    /// for User Agents to cache as reference data.
    /// </summary>
    //[ODataRoutePrefix("body")]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    //[ODataPath(Constants.Api.ApiControllerNames.DataClassification)]
    public class DataClassificationController : CommonODataControllerBase // ODataControllerStandardDataBase<DataClassification,DataClassificationDto>
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        public DataClassificationController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute):base(diagnosticsTracingService, principalService)
        {
            this._repositoryService = repositoryService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;
        }

        //Helper:
        protected IQueryable<DataClassification> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<DataClassification>(AppCoreDbContextNames.Core);
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<DataClassificationDto> Get()
        {
            //return InternalGet();
            var result =
                InternalGetDbSet()
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<DataClassificationDto>(
                        //(object)null,
                        //x => x.DataClassification
                    );
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        //[ODataRoute("({key})")]
        public DataClassificationDto Get(NZDataClassification key)
        {
            //return InternalGet(key);
            var result =
                InternalGetDbSet()
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<DataClassificationDto>(
                        //(object)null,
                        //x => x.DataClassification
                    )
                    .SingleOrDefault(x => x.Id == key);
            this._secureApiMessageAttribute.Process(result);
            return result;
        }



    }
}