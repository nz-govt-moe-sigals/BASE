namespace App.Core.Application.ServiceFacade.API.Controllers.Base
{
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Constants.Db;
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
    public abstract class ActiveRecordStateODataControllerBase<TEntity,TDto> : ActiveRecordStateCommonODataControllerBase<TEntity, TDto>  /*NO:IHasInitialize as it makes the method public wihich is not needed*/
        where TEntity : class, IHasRecordState, new()
        where TDto: class, new()
    {




        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveRecordStateODataControllerBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        protected ActiveRecordStateODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, IRepositoryService repositoryService, IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) : base(diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
            // Base will invoke Initialize() to set base._dbContextIdentifier

        }


        /// <summary>
        /// Class implementers must implement this method and
        /// set the <see cref="_dbContextIdentifier"/>
        /// on a per Module basis -- and invoke it from the Constructor.
        /// </summary>
        protected override void Initialize()
        {
            // Note the setting of the dbcontect identifier
            // (each module will do this, specific to the module):
            this._dbContextIdentifier = AppCoreDbContextNames.Core;
        }

    }
}