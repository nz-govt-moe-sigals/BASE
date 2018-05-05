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
using IHasSourceSystemKey = App.Module3.Shared.Models.IHasSourceSystemKey;

namespace App.Module3.Application.ServiceFacade.API.Moe.Controllers
{
    using App.Module3.Application.ServiceFacade.API.Base;

    public abstract  class ODataControllerMoeResourceDataBase<TEntity, TDto> : ActiveRecordStateODataControllerBase<TEntity,TDto> where TEntity : class, IHasGuidId, IHasSourceSystemKey, IHasRecordState, new()
        where TDto : class, IHasSIFIdAsStringId, new()
    {
        protected ODataControllerMoeResourceDataBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier.
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
