using App.Core.Application.API.Controllers.Base.CoreModule;

namespace App.Core.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper.QueryableExtensions;
    using App.Core.Shared.Models.Entities.TenancySpecific;




    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// OData Queryable REST Controller for
    /// <see cref="MediaMetadataDto"/> messages 
    /// 
    /// </summary>
    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.MediaMetadata)]
    public class MediaMetadataController : GuidIdActiveRecordStateCoreODataControllerBase<MediaMetadata, MediaMetadataDto>
    {
        public MediaMetadataController(
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
        public IQueryable<MediaMetadataDto> Get()
        {
            //return InternalGet();
            var result =
                InternalGetDbSet()
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<MediaMetadataDto>(
                        (object) null,
                        x => x.DataClassification
                    );
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        //[ODataRoute("({key})")]
        public MediaMetadataDto Get(Guid key)
        {
            //return InternalGet(key);
            var result =
                InternalGetDbSet()
                    // Note how we only want only distribute active records:
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<MediaMetadataDto>(
                    (object)null,
                    x=>x.DataClassification
                    )
                    .SingleOrDefault(x => x.Id == key);
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

    }
}