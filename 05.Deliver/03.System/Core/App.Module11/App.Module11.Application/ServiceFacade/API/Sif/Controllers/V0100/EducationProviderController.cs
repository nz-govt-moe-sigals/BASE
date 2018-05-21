using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.OData.Extensions;
using System.Web.OData.Query;

namespace App.Module11.Application.ServiceFacade.API.Sif.Controllers.V0100
{
    using System.Web.Http;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.ServiceFacade.API.Controllers;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Module11.Application.Constants.Api;
    using App.Module11.Application.ServiceFacade.API.Base;
    using App.Module11.Application.ServiceFacade.API.Controllers;
    using App.Module11.Infrastructure.Constants.Db;
    using App.Module11.Shared.Models.Entities;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;
    using AutoMapper.QueryableExtensions;

    [ODataPath(ApiControllerNames.EducationProvider)]
    public class EducationProviderController : ActiveRecordStateODataControllerBase<EducationProviderProfile,
        EducationProviderDto>
    {
        private readonly ISessionOperationLogService _sessionOperationLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EducationProviderController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        public EducationProviderController(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, IRepositoryService repositoryService, ISessionOperationLogService sessionOperationLogService,
            IObjectMappingService objectMappingService, ISecureAPIMessageAttributeService secureApiMessageAttribute) :
            base(diagnosticsTracingService, principalService, repositoryService, objectMappingService,
                secureApiMessageAttribute)
        {
            this._sessionOperationLogService = sessionOperationLogService;
            // Base will invoke Initialize() to set base._dbContextIdentifier.
        }

        //[AllowAnonymous]
        //[EnableQuery(PageSize = 100)]
        //public IQueryable<EducationProviderDto> Get()
        //{
        //    return InternalGet();
        //}

  
        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [AllowAnonymous]
        [EnableQuery(PageSize = 100)]
        public IQueryable<EducationProviderDto> Get()
        {
            return InternalGet();            
            /*
            var y = InternalActiveRecords();
            var z = y.ProjectTo<EducationProviderDto>();
            var a = queryOptions.ApplyTo(z, ignoreQueryOptions: AllowedQueryOptions.Expand | AllowedQueryOptions.Select) as IQueryable<EducationProviderDto>;

            return Ok(a, a.GetType());
            */
            //using (var elapsedTime = new ElapsedTime())
            //{

            //    var r = InternalGet(
            //            x=>x.AreaUnit,
            //            x => x.AuthorityType,
            //            x => x.Classification,
            //        x => x.CoL,
            //        x=>x.CommunityBoard,
            //            x => x.EducationProviderType,
            //        x => x.GeneralElectorate,
            //            x => x.LevelGender,
            //            x => x.LocalOffice,
            //            x => x.Locations,
            //        x => x.MaoriElectorate,
            //            x => x.Region,
            //            x => x.RollCounts,
            //        x => x.SchoolingGender,
            //        x => x.Status,
            //        x => x.TeacherEducation,
            //        x=>x.TerritorialAuthority,
            //        x=>x.RegionalCouncil,
            //        x=>x.UrbanArea,
            //            x => x.Ward
            //        )
            //        .ToArray();

            //    this._sessionOperationLogService.SetDetail("DbDuration", elapsedTime.Elapsed.TotalMilliseconds );

            //    if (elapsedTime.Elapsed.TotalMilliseconds > 2000)
            //    {
            //        this._diagnosticsTracingService.Trace(TraceLevel.Warn, "Taking too long to get Providers");
            //    }

            //    return r;
            //}
        }

        [AllowAnonymous]
        //[ODataRoute("({key})")]
        public EducationProviderDto Get(int key)
        {
            var result =
                InternalActiveRecords()
                    .ProjectTo<EducationProviderDto>()
                    .SingleOrDefault(x => x.SchoolId == key);

            this._secureApiMessageAttribute.Process(result);


            return result;
        }
    }
}
