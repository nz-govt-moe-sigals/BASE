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
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    public class BodyDtoController : ODataControllerStandardDataBase<Body, BodyDto>
    {
        public BodyDtoController(
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
        public IQueryable<BodyDto> Get()
        {
            IQueryable<BodyDto> results;

            try
            {
                results =
                    InternalGetDbSet()
                        // Note how the Project method changes how Includes are defined:
                        // .Include(x => x.Category)
                        // .Include(x => x.Aliases)
                        // .Include(x => x.Channels)
                        // .Include(x => x.Properties)
                        // .Include(x => x.Claims)
                        // Note how we only want only distribute active records:
                        .Where(x => x.RecordState == RecordPersistenceState.Active)
                        .ProjectTo<BodyDto>(
                            (object) null,
                            x=>x.Category,
                            x=>x.Names,
                            x=>x.Channels,
                            x=>x.Properties,
                            x=>x.Claims
                        )
                    ;
            }
            catch (System.Exception e)
            {
                throw;
            }

            // TODO: IMPORTANT: Verify this is not causing double iteration:
            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            results.ForEach(x => this._secureApiMessageAttribute.Process(x));
            return results;

        }

        //[ODataRoute("({key})")]
        public BodyDto Get(Guid key)
        {
            var result =
                InternalGetDbSet()
                    // Note how the Project method changes how Includes are defined:
                    // .Include(x => x.Category)
                    // .Include(x => x.Aliases)
                    // .Include(x => x.Channels)
                    // .Include(x => x.Properties)
                    // .Include(x => x.Claims)
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<BodyDto>(
                        x => x.Category,
                        x => x.Names,
                        x => x.Channels,
                        x => x.Properties,
                        x => x.Claims
                    )
                    .SingleOrDefault(x => x.Id == key);

            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        //// POST api/values 
        public void Post(BodyDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(BodyDto value)
        {
            InternalPut(value);
        }
    }
}