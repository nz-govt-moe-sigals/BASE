using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Application.ServiceFacade.API.Sif.Controllers.V0100
{
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Infrastructure.Services;
    using App.Module3.Application.Constants.Api;
    using App.Module3.Application.ServiceFacade.API.Controllers;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
    using AutoMapper.QueryableExtensions;

    [ODataPath(ApiControllerNames.EducationProvider)]
    public class EducationProviderController : DataODataControllerCommonBase<EducationProviderProfile,
        EducationProviderDto>
    {
        public EducationProviderController(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
        }

        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [AllowAnonymous]
        [EnableQuery(PageSize = 100)]
        public IQueryable<EducationProviderDto> Get()
        {
            return InternalGet();
        }

        [AllowAnonymous]
        //[ODataRoute("({key})")]
        public EducationProviderDto Get(string key)
        {
            var result =
                InternalActiveRecords()
                    .ProjectTo<EducationProviderDto>()
                    .SingleOrDefault(x => x.Id == key);

            this._secureApiMessageAttribute.Process(result);


            return result;
        }
    }
}
