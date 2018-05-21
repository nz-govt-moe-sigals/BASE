using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using App.Core.Infrastructure.Services;
using App.Module11.Application.Attributes;
using App.Module11.Application.ExtensionMethods;
using App.Module11.Application.ServiceFacade.API.Base;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using AutoMapper.QueryableExtensions;
using Microsoft.OData.UriParser;
using Microsoft.Web.Http;

namespace App.Module11.Application.ServiceFacade.API.Sif.Controllers.V0100
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")] // currently object does the code logic
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
        [EnableQueryExtended( )]
        public IQueryable<SifProviderDto> Get(ODataQueryOptions<EducationProviderDto> queryOptions)
        {
            //var newQueryOptions = new ODataQueryOptionsTest<EducationProviderDto>(queryOptions.Context, queryOptions.Request);
            var y = InternalActiveRecords();
            var z = y.ProjectTo<EducationProviderDto>();
            var a = (queryOptions.ApplyTo(z, 
                ignoreQueryOptions: 
                                     AllowedQueryOptions.Expand // ODataQueryOptions does not support, so apply at end
                                    | AllowedQueryOptions.Select // ODataQueryOptions does not support, so apply at end
                ,querySettings: new ODataQuerySettings()
                { 
                    PageSize = 100
                }) as IQueryable<EducationProviderDto>);
            var x = AutoMapper.Mapper.Map<IList<SifProviderDto>>(a).AsQueryable();
            return x;
            //return Ok(x, x.GetType());
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
