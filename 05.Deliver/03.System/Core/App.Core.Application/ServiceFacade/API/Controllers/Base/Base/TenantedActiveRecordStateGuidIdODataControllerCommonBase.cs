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

    public abstract class TenantedActiveRecordStateGuidIdODataControllerCommonBase<TEntity, TDto> : DataODataControllerCommonBase<TEntity,TDto>
        where TEntity : class, IHasGuidId, IHasRecordState, IHasTenantFK, new()
        where TDto : class, IHasGuidId, new()
    {

        private readonly ITenantService _tenantService;



        protected TenantedActiveRecordStateGuidIdODataControllerCommonBase(IDiagnosticsTracingService diagnosticsTracingService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute, IPrincipalService principalService, ITenantService tenantService ) 
            : base(diagnosticsTracingService, principalService,repositoryService,objectMappingService,secureApiMessageAttribute)
        {
         
        }

        //Helper:
        protected override IQueryable<TEntity> InternalActiveRecords()
        {
            return this.InternalGetDbSet().Where(x => x.RecordState == RecordPersistenceState.Active);
        }
        protected override IQueryable<TEntity> InternalGetDbSet()
        {
            Guid tenantFK = GetTenantFK();

            return base.InternalGetDbSet().Where(x => (x.TenantFK == tenantFK));
        }

        protected Guid GetTenantFK()
        {
            //this._principalService.t
            var result = this._tenantService.PrincipalTenant.Id;
            return result;
        }

        // IMPORTANT:
        // The methods are protected (and prefixed with 'Internal') rather than public, 
        // in order to ensure developers don't blindly expose the methods without
        // attaching appropriate security attributes and calls, as well as 
        // (optional) route attributes 


        //// POST api/values 
        protected void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == value.Id);

            this._objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }

        protected TDto InternalGet(Guid key)
        {
            var result  =
                InternalActiveRecords()
                .ProjectTo<TDto>()
                .SingleOrDefault(x => x.Id == key);

            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        public void InternalDelete(Guid key)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => (x.Id == key));
            // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
            if (entity?.RecordState == RecordPersistenceState.Active)
            {
                entity.RecordState = RecordPersistenceState.ToDispose;
            }
        }
    }
}