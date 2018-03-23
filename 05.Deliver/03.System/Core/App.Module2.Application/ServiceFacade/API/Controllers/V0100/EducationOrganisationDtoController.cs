namespace App.Module2.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module2.Application.ServiceFacade.API.Controllers;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class EducationOrganisationController : ODataControllerStandardDataBase<EducationOrganisation, EducationOrganisationDto>
    {
        public EducationOrganisationController(
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
        public IQueryable<EducationOrganisationDto> Get()
        {
            var result =
                InternalGetDbSet()
                    // Note how the Project method changes how Includes are defined:
                    // .Include(x => x.Principal)
                    // .Include(x => x.Organisation)
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<EducationOrganisationDto>(
                    (object)null,
                        x => x.Principal,
                        x => x.Organisation
                    );
            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            this._secureApiMessageAttribute.Process(result);

            return result;

        }

        //[ODataRoute("({key})")]
        public EducationOrganisationDto Get(Guid key)
        {
            var result =
                InternalGetDbSet()
                    // Note how the Project method changes how Includes are defined:
                    //.Include(x => x.Principal)
                    // .Include(x => x.Organisation)
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<EducationOrganisationDto>(
                        (object)null,
                        x => x.Principal,
                        x => x.Organisation
                    )
                    .SingleOrDefault(x => x.Id == key);
            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        ////// POST api/values 
        //public void Post(EducationOrganisationDto value)
        //{
        //    InternalPost(value);
        //}

        ////// PUT api/values/5 
        //public void Put(EducationOrganisationDto value)
        //{
        //    InternalPut(value);
        //}
    }
}