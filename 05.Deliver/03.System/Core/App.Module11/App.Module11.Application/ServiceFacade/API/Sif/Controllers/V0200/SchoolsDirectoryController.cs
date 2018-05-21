using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Module11.Application.ServiceFacade.API.Base;
using App.Module11.Application.ServiceFacade.API.Sif.Controllers.V0100;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;
using AutoMapper.QueryableExtensions;
using Microsoft.Web.Http;

namespace App.Module11.Application.ServiceFacade.API.Sif.Controllers.V0200
{
    [ApiVersion("2.0")]
    public class SchoolsDirectoryController : ActiveRecordStateODataControllerBase<EducationProviderProfile,
        SchoolDirectoryDto>
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
        public SchoolsDirectoryController(IDiagnosticsTracingService diagnosticsTracingService,
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
        [EnableQuery()] // deliberately left it off Page size see version 1 for the default func
        public IQueryable<SchoolDirectoryDto> Get()
        {

            return InternalGet();

        }

    }
}
