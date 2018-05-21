namespace App.Module3.Application.ServiceFacade.API.Controllers
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using App.Module3.Application.ServiceFacade.API.Base;
    using App.Module3.Infrastructure.Constants.Db;
    using App.Module3.Shared.Models;
    using App.Module3.Shared.Models.Entities;
    using AutoMapper.QueryableExtensions;

    public abstract class SIFResourceODataControllerBase<TEntity, TDto> : ActiveRecordStateODataControllerBase<TEntity, TDto> where TEntity
        : class, IHasGuidId, IHasSIFKey, IHasRecordState, new()
        where TDto : class, IHasSIFIdAsStringId, /* IHasSIFNOTIdAsStringId*/ new()
    {


        protected SIFResourceODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute)
            : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier.

        }

        //// POST api/values 
        protected virtual void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.SIFKey.ToString() == value.Id);
            this._objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }

        // PUT api/values/5 
        protected new void InternalPut(TDto value)
        {
            //Create a new record:
            var entity = this._objectMappingService.Map<TDto, TEntity>(value);
            this._repositoryService.AddOnCommit(_dbContextIdentifier, entity);
        }




        // Limit options for Denial of Service by 
        // excessive resource consumtion conditions:
        [EnableQuery(PageSize = 100)]
        protected IQueryable<TDto> InternalGet()
        {
            IQueryable<TDto> results;
            try
            {
                results = InternalActiveRecords()
                    .ProjectTo<TDto>()
                    ;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }

            // TODO: IMPORTANT: Verify this is not causing double iteration:
            results.ForEach(x => this._secureApiMessageAttribute.Process(x));

            return results;
        }

        protected TDto InternalGet(string sifKey)
        {
            var result =
            InternalActiveRecords()
            .ProjectTo<TDto>()
                .SingleOrDefault(x => x.Id == sifKey);

            this._secureApiMessageAttribute.Process(result);

            return result;
        }


        public void InternalDelete(string sifKey)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id.ToString() == sifKey);
            if (entity?.RecordState == RecordPersistenceState.Active)
            {
                entity.RecordState = RecordPersistenceState.ToDispose;
            }
        }

    }
}