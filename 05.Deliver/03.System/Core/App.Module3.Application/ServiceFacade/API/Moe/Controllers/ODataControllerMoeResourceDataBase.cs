using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;
using App.Core.Shared.Models.Entities;
using App.Module3.Application.ServiceFacade.API.Controllers;
using App.Module3.Infrastructure.Constants.Db;
using App.Module3.Shared.Models;
using App.Module3.Shared.Models.Entities;
using AutoMapper.QueryableExtensions;

namespace App.Module3.Application.ServiceFacade.API.Moe.Controllers
{
    public abstract  class ODataControllerMoeResourceDataBase<TEntity, TDto> : ODataControllerBase
        where TEntity : class, IHasGuidId, IHasSourceSystemKey, IHasRecordState, new()
        where TDto : class, IHasSIFIdAsStringId, new()
    {
        private readonly IObjectMappingService _objectMappingService;
        private readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;
        private readonly IRepositoryService _repositoryService;

        protected ODataControllerMoeResourceDataBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute)
            : base(diagnosticsTracingService, principalService)
        {
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;
        }

        protected IQueryable<TEntity> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<TEntity>(AppModule3DbContextNames.Module3);
        }

        protected IQueryable<TEntity> InternalGetDbSetOfActivEntities()
        {
            return InternalGetDbSet().Where(x => x.RecordState == RecordPersistenceState.Active);

        }


        //// POST api/values 
        protected void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.SourceSystemKey.ToString() == value.Id);
            this._objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }

        // PUT api/values/5 
        protected void InternalPut(TDto value)
        {
            //Create a new record:
            var entity = this._objectMappingService.Map<TDto, TEntity>(value);
            this._repositoryService.AddOnCommit(AppModule3DbContextNames.Module3, entity);
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
                    InternalGetDbSetOfActivEntities()
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

        protected TDto InternalGet(string firstkey)
        {
            var result =
                InternalGetDbSetOfActivEntities()
                    .ProjectTo<TDto>()
                    .SingleOrDefault(x => x.Id == firstkey);

            this._secureApiMessageAttribute.Process(result);

            return result;
        }





        public void InternalDelete(string firstkey)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id.ToString() == firstkey);
            if (entity?.RecordState == RecordPersistenceState.Active)
            {
                entity.RecordState = RecordPersistenceState.ToDispose;
            }
        }

    }
}
