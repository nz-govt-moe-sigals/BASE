//namespace App.Core.Application.ServiceFacade.API.Controllers.Base.Base
//{
//    using System;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using System.Reflection;
//    using App.Core.Infrastructure.Services;
//    using App.Core.Shared.Models;
//    using App.Core.Shared.Models.Entities;
//    using AutoMapper.QueryableExtensions;

//    /// <summary>
//    /// The base class for UnTenanted (ie, common/Core) Controllers 
//    /// whose DTOs expose 
//    /// the internal Guid Id of the logical entities.
//    /// <para>
//    /// In the past exposing the storage Id was considering
//    /// exposing an unecessary amount of information, that could be
//    /// maybe leveraged for an attack. 
//    /// As a security concern that's basically false concern. On the other hand,
//    /// it does cause a contractual dependency to the Guid Id, in between systems,
//    /// when a Code would be more appropriate.
//    /// </para>
//    /// <para>
//    /// The advantages include:
//    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent 
//    ///   of that Entity, as well as the logic to leverage AutoMapper to pass the linq
//    ///   through the layers. ie, the Magic of ProjectTo.
//    /// * only one base class that needs to be updated to .NET Core when we get there.
//    /// * ensures that all classes are injected with an implementation of 
//    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
//    /// so there is absolutely no excuse for poor diagnostics logs, or security...
//    /// (that said, still don't trust developers rushing to meet deadlines to take 
//    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
//    /// Security and Logging as GLobal Filters anyway).
//    /// </para>
//    /// </summary>
//    /// <typeparam name="TEntity">The type of the entity.</typeparam>
//    /// <typeparam name="TDto">The type of the dto.</typeparam>
//    /// <typeparam name="TDtoKeyPropertyType">The DTO's Key Property Type</typeparam>
//    /// <seealso cref="ActiveRecordStateCommonODataControllerBase{TEntity,TDto}" />
//    public abstract class IdActiveRecordStateCommonODataControllerBase<TEntity, TDto, TDtoKeyPropertyType> : ActiveRecordStateCommonODataControllerBase<TEntity,TDto>
//        where TEntity : class, IHasRecordState, new()
//        where TDto : class, new()
//        where TDtoKeyPropertyType : struct
//    {
//        private readonly Expression<Func<TDto, TDtoKeyPropertyType>> _property;


//        /// <summary>
//        /// Initializes a new instance of the <see cref="GuidIdActiveRecordStateCommonODataControllerBase{TEntity,TDto}" /> class.
//        /// </summary>
//        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
//        /// <param name="principalService">The principal service.</param>
//        /// <param name="repositoryService">The repository service.</param>
//        /// <param name="objectMappingService">The object mapping service.</param>
//        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
//        /// <param name="property">The DTO's Key property (eg: use 'x=>x.Id').</param>
//        protected IdActiveRecordStateCommonODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, 
//            IPrincipalService principalService,
//            IRepositoryService repositoryService, 
//            IObjectMappingService objectMappingService, 
//            ISecureAPIMessageAttributeService secureApiMessageAttribute,
//            Expression<Func<TDto, TDtoKeyPropertyType>> property
//            ) :
//            base( diagnosticsTracingService, principalService, repositoryService,objectMappingService,secureApiMessageAttribute)
//        {
//            this._property = property;


//            // Base will invoke Initialize() to set base._dbContextIdentifier
//        }





//        // IMPORTANT:
//        // The methods are protected (and prefixed with 'Internal') rather than public, 
//        // in order to ensure developers don't blindly expose the methods without
//        // attaching appropriate security attributes and calls, as well as 
//        // (optional) route attributes 


//        //// POST api/values 
//        protected virtual void InternalPost(TDto value)
//        {
//            //Update an existing record:
//            var entity = InternalGetDbSet()
//                .Filter(_property, key).FirstOrDefault();.SingleOrDefault(x => x.Id == value.Id);

            
//            this._objectMappingService.Map(value, entity);
//            // Nothing else to do (it's already being tracked)
//            //so when committed later, will be saved.
//        }


//        protected virtual TDto InternalGet(TDtoKeyPropertyType key)
//        {

//            var result  =
//                InternalActiveRecords()
//                .ProjectTo<TDto>()
//                .Filter(_property, key).FirstOrDefault();

//            this._secureApiMessageAttribute.Process(result);

//            return result;
//        }

//        protected virtual void InternalDelete(TDtoKeyPropertyType key)
//        {
//            //We are doing a logical delete by changing state:
//            var entity = InternalGetDbSet()
//                .Filter(_property, key).FirstOrDefault();

//            // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
//            if (entity?.RecordState == RecordPersistenceState.Active)
//            {
//                entity.RecordState = RecordPersistenceState.ToDispose;
//            }
//        }

//        //private static TEntity GetEntity<TEntity, TKey>(Expression<Func<TEntity, TKey>> property, TKey keyValue)
//        //    where TKey : struct
//        //    where TEntity : BaseEntity<TKey>
//        //{
//        //    using (var ctx = new Context2())
//        //    {
//        //        var query = Filter(ctx.Set<TEntity>(), property, keyValue);
//        //        return query.First();
//        //    }
//        //}

//    }

//    public static class X
//    {

//        public static IQueryable<TEntity> Filter<TEntity, TProperty>(this IQueryable<TEntity> dbSet,
//            Expression<Func<TEntity, TProperty>> property,
//            TProperty value)
//            where TProperty : struct
//        {

//            var memberExpression = property.Body as MemberExpression;
//            if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
//            {
//                throw new ArgumentException("Property expected", "property");
//            }

//            Expression left = property.Body;
//            Expression right = Expression.Constant(value, typeof(TProperty));

//            Expression searchExpression = Expression.Equal(left, right);
//            var lambda = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(left, right),
//                new ParameterExpression[] { property.Parameters.Single() });

//            return dbSet.Where(lambda);
//        }

//    }

//}