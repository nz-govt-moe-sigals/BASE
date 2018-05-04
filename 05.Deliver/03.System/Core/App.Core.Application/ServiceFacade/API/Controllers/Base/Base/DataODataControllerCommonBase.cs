namespace App.Core.Application.ServiceFacade.API.Controllers
{
    using System.Linq;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using AutoMapper.QueryableExtensions;

    public abstract class DataODataControllerCommonBase<TEntity,TDto> : ODataControllerCommonBase
        where TEntity : class, IHasRecordState, new()
        where TDto: class, new()
    {
        protected string _dbContextIdentifier;

        protected IRepositoryService _repositoryService;
        protected IObjectMappingService _objectMappingService;
        protected ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        protected DataODataControllerCommonBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            
            base(diagnosticsTracingService, principalService)
        {
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;

        }

        //Helper:
        protected virtual IQueryable<TEntity> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<TEntity>(this._dbContextIdentifier);
        }

        protected virtual IQueryable<TEntity> InternalActiveRecords()
        {
            return InternalGetDbSet().Where(x => x.RecordState == RecordPersistenceState.Active);
        }





        // PUT api/values/5 
        protected virtual void InternalPut(TDto value)
        {
            //Create a new record:
            var entity = this._objectMappingService.Map<TDto, TEntity>(value);
            this._repositoryService.AddOnCommit(this._dbContextIdentifier, entity);
        }

        // Limit options for Denial of Service by 
        // excessive resource consumtion conditions:
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TDto> InternalGet()
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
            results.ForEach(x => _secureApiMessageAttribute.Process(x));

            return results;
        }


    }
}