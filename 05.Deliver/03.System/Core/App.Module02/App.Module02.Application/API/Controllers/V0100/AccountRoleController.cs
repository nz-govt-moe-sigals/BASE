using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using App.Module02.Application.API.Controllers;
using App.Module02.Shared.Models.Entities;
using App.Module02.Shared.Models.Messages.API.V0100;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData;

namespace App.Module02.Application.API.Controllers.V0100
{
    public class AccountRoleController : GuidIdActiveRecordStateODataControllerBase<TenancySecurityProfileAccountRole, AccountRoleDto>
    {
        public AccountRoleController(
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
        public IQueryable<AccountRoleDto> Get()
        {
            IQueryable<AccountRoleDto> results;

            try
            {
                results =
                    InternalActiveRecords()
                        .ProjectTo<AccountRoleDto>(
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
        public AccountRoleDto Get(Guid key)
        {
            var result =
                    InternalActiveRecords()
                    .Where(x => x.RecordState == RecordPersistenceState.Active)
                    .ProjectTo<AccountRoleDto>(
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

        //// POST api/values 
        public void Post(AccountRoleDto value)
        {
            InternalPost(value);
        }

        //// PUT api/values/5 
        public void Put(AccountRoleDto value)
        {
            InternalPut(value);
        }
    }
}
