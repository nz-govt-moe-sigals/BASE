using System.Web.Http;
using System.Web.Http.Results;

namespace App.Core.Application.ServiceFacade.API.Controllers.Base.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.OData;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Contracts;
    using App.Core.Shared.Models;
    using App.Core.Shared.Models.Entities;
    using AutoMapper.QueryableExtensions;

    /// <summary>
    /// Just about every controller, whatever module,  *should* inherit in one way or another
    /// from this base controller.
    /// <para>
    /// The advantages include:
    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent 
    ///   of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    ///   through the layers. ie, the Magic of ProjectTo.
    /// * only one base class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of 
    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// (that said, still don't trust developers rushing to meet deadlines to take 
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <seealso cref="System.Web.OData.ODataController" />
    public abstract class ActiveRecordStateCommonODataControllerBase<TEntity,TDto> : CommonODataControllerBase /*NO:IHasInitialize as it makes the method public wihich is not needed*/
        where TEntity : class, IHasRecordState, new()
        where TDto: class, new()
    {
        protected /*readonly*/ string _dbContextIdentifier;

        protected readonly IRepositoryService _repositoryService;
        protected readonly IObjectMappingService _objectMappingService;
        protected readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        protected ActiveRecordStateCommonODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService,
            IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            
            base(diagnosticsTracingService, principalService)
        {
            this._repositoryService = repositoryService;
            this._objectMappingService = objectMappingService;
            this._secureApiMessageAttribute = secureApiMessageAttribute;

            // Base will invoke Initialize() to set base._dbContextIdentifier:
            // ReSharper disable once VirtualMemberCallInConstructor
            Initialize(); 
        }


        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="_dbContextIdentifier"/>
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected abstract void Initialize();


        //Helper:
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalGetDbSet()
        {
            return this._repositoryService.GetQueryableSet<TEntity>(this._dbContextIdentifier);
        }

        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalActiveRecords()
        {
            return InternalGetDbSet().Where(x => x.RecordState == RecordPersistenceState.Active);
        }

        protected IHttpActionResult Ok(object content, Type type)
        {
            Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
            return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
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
        protected virtual IQueryable<TDto> InternalGet(params Expression<Func<TDto,object>>[] expandProperties)
        {
            IQueryable<TDto> results;
            try
            {
                results =
                    InternalActiveRecords()
                        .ProjectTo<TDto>(
                        (object)null,
                        expandProperties
                        )
                    ;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }
            if (this._secureApiMessageAttribute.NeedsProcessing(typeof(TDto)))
            {
                // TODO: IMPORTANT: Verify this is not causing double iteration:
                results.ForEach(x => this._secureApiMessageAttribute.Process(x));
            }

            return results;
        }


 
    }
}