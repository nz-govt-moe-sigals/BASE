using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using App.Core.Infrastructure.Services;
using App.Module3.Application.ServiceFacade.API.Base;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using AutoMapper.QueryableExtensions;
using Microsoft.OData.UriParser;

namespace App.Module3.Application.ServiceFacade.API.Sif.Controllers.V0100
{
    public class ProvidersController : ActiveRecordStateODataControllerBase<EducationProviderProfile,
        SifProviderDto>
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationProviderController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        public ProvidersController(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService, ISessionOperationLogService sessionOperationLogService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            this._sessionOperationLogService = sessionOperationLogService;
            // Base will invoke Initialize() to set base._dbContextIdentifier.
        }

        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [AllowAnonymous]
        //[EnableQuery( AllowedQueryOptions = AllowedQueryOptions.None)]
        public IHttpActionResult Get(ODataQueryOptions<EducationProviderDto> queryOptions)
        {
            var y = InternalActiveRecords();
            var z = y.ProjectTo<EducationProviderDto>();
            var a = (queryOptions.ApplyTo(z, ignoreQueryOptions: AllowedQueryOptions.Expand | AllowedQueryOptions.Select, querySettings: new ODataQuerySettings()
                { 
                    PageSize = 100
                }) as IQueryable<EducationProviderDto>);
            var x = AutoMapper.Mapper.Map<IList<SifProviderDto>>(a);
            return Ok(x, x.GetType());
        }

        [AllowAnonymous]
        //[ODataRoute("({key})")]
        public SifProviderDto Get(int key)
        {
            var result =
                InternalActiveRecords()
                    .ProjectTo<SifProviderDto>()
                    .SingleOrDefault(x => x.LocalId == key);

            this._secureApiMessageAttribute.Process(result);


            return result;
        }
    }
}
