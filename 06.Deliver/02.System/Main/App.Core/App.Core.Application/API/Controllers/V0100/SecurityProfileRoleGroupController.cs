﻿using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using App.Core.Application.API.Controllers;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;
using App.Core.Application.API.Controllers.Base;
using App.Core.Application.API.Controllers.Base.CoreModule;
using App.Core.Application.Filters.WebApi;
using App.Core.Shared.Constants;

namespace App.Core.Application.API.Controllers.V0100
{
    
    public class SecurityProfileRoleGroupController : GuidIdActiveRecordStateCoreODataControllerBase<TenancySecurityProfileRoleGroup, SecurityProfileRoleGroupDto>
    {
        public SecurityProfileRoleGroupController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base
            (diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<SecurityProfileRoleGroupDto> Get()
        {
            IQueryable<SecurityProfileRoleGroupDto> results;

            try
            {
                results =
                    InternalActiveRecords()
                        .ProjectTo<SecurityProfileRoleGroupDto>(
                            //Always either define null
                            (object)null
                        // or include related tables:
                        //x => x.Category,
                        //x => x.Properties
                        )
                    ;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }

            // TODO: IMPORTANT: Verify this is not causing double iteration:
            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            results.ForEach(x => this._secureApiMessageAttribute.Process(x));
            return results;

        }

        //[ODataRoute("({key})")]
        public SecurityProfileRoleGroupDto Get(Guid key)
        {
            var result =
                    InternalActiveRecords()
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<SecurityProfileRoleGroupDto>(
                            //Always either define null
                            (object)null
                    // or include related tables:
                    //x => x.Category,
                    //x => x.Properties
                    )
                    .SingleOrDefault(x => x.Id == key);

            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
            this._secureApiMessageAttribute.Process(result);
            return result;
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// POST api/values 
        public void Post(SecurityProfileRoleGroupDto value)
        {
            InternalPost(value);
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// PUT api/values/5 
        public void Put(SecurityProfileRoleGroupDto value)
        {
            InternalPut(value);
        }
    }
}
