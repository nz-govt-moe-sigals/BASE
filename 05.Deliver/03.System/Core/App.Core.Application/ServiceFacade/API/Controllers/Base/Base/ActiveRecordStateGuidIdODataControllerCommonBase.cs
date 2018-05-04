namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Constants;
    using App.Core.Infrastructure.Constants.Db;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using AutoMapper.QueryableExtensions;

    public abstract class ActiveRecordStateGuidIdODataControllerCommonBase<TEntity, TDto> : DataODataControllerCommonBase<TEntity,TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {



        protected ActiveRecordStateGuidIdODataControllerCommonBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base( diagnosticsTracingService, principalService, repositoryService,objectMappingService,secureApiMessageAttribute)
        {

        }

        // IMPORTANT:
        // The methods are protected (and prefixed with 'Internal') rather than public, 
        // in order to ensure developers don't blindly expose the methods without
        // attaching appropriate security attributes and calls, as well as 
        // (optional) route attributes 


        //// POST api/values 
        protected virtual void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == value.Id);

            this._objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }


        protected virtual TDto InternalGet(Guid key)
        {

            var result  =
                InternalActiveRecords()
                .ProjectTo<TDto>()
                .SingleOrDefault(x => x.Id == key);

            this._secureApiMessageAttribute.Process(result);

            return result;
        }

        protected virtual void InternalDelete(Guid key)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == key);
            // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
            if (entity?.RecordState == RecordPersistenceState.Active)
            {
                entity.RecordState = RecordPersistenceState.ToDispose;
            }
        }
    }
}