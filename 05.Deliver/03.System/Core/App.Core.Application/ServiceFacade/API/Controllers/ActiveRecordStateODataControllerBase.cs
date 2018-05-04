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

    public abstract class ActiveRecordStateODataControllerBase<TEntity, TDto> : ODataControllerBase
        where TEntity : class, IHasGuidId, IHasRecordState, new()
        where TDto : class, IHasGuidId, new()
    {
        protected string _dbContextIdentifier { get; set; }

        protected readonly IObjectMappingService _objectMappingService;
        protected readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;
        protected readonly IRepositoryService _repositoryService;



        protected ActiveRecordStateODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService)
        {
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;

            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }

        //Helper:
        protected IQueryable<TEntity> InternalActiveRecords()
        {
            return InternalGetDbSet().Where(x => x.RecordState == RecordPersistenceState.Active);
        }

        protected IQueryable<TEntity> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<TEntity>(this._dbContextIdentifier);
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

        // PUT api/values/5 
        protected void InternalPut(TDto value)
        {
            //Create a new record:
            var entity = this._objectMappingService.Map<TDto, TEntity>(value);
            this._repositoryService.AddOnCommit(this._dbContextIdentifier, entity);
        }

        // Limit options for Denial of Service by 
        // excessive resource consumtion conditions:
        [EnableQuery(PageSize = 100)]
        protected IQueryable<TDto> InternalGet()
        {
            IQueryable<TDto> results;
            try
            {
                results =
                    InternalActiveRecords()
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
            results.ForEach(x=>_secureApiMessageAttribute.Process(x));

            return results;
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
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == key);
            // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
            if (entity?.RecordState == RecordPersistenceState.Active)
            {
                entity.RecordState = RecordPersistenceState.ToDispose;
            }
        }
    }
}