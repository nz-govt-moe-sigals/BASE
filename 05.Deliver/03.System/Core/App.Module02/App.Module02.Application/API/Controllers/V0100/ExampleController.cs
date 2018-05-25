//using App.Core.Infrastructure.Services;
//using App.Core.Shared.Models.Entities;
//using App.Core.Shared.Models.Messages.API.V0100;
//using App.Module01.Application.API.Controllers;
//using App.Module01.Shared.Models.Entities;
//using AutoMapper.QueryableExtensions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.OData;

//namespace App.Module02.Application.API.Controllers.V0100
//{
//    public class ExampleController : GuidIdActiveRecordStateODataControllerBase<Example, ExampleDto>
//    {
//        public ExampleController(
//            IDiagnosticsTracingService diagnosticsTracingService,
//            IPrincipalService principalService,
//            IRepositoryService repositoryService,
//            IObjectMappingService objectMappingService,
//            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base
//            (diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
//        {
//        }


//        // GET api/values 
//        //[ApplyDataContractResolver]
//        //[ApplyProxyDataContractResolverAttribute]
//        //[ODataRoute()]
//        [EnableQuery(PageSize = 100)]
//        public IQueryable<ExampleDto> Get()
//        {
//            IQueryable<ExampleDto> results;

//            try
//            {
//                results =
//                    InternalActiveRecords()
//                        .ProjectTo<ExampleDto>(
//                            //Always either define null
//                            (object)null
//                            // or include related tables:
//                            //x => x.Category,
//                            //x => x.Properties
//                        )
//                    ;
//            }
//#pragma warning disable CS0168 // Variable is declared but never used
//            catch (System.Exception e)
//#pragma warning restore CS0168 // Variable is declared but never used
//            {
//                throw;
//            }

//            // TODO: IMPORTANT: Verify this is not causing double iteration:
//            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
//            results.ForEach(x => this._secureApiMessageAttribute.Process(x));
//            return results;

//        }

//        //[ODataRoute("({key})")]
//        public ExampleDto Get(Guid key)
//        {
//            var result =
//                    InternalActiveRecords()
//                    .Where(x => x.RecordState == RecordPersistenceState.Active)
//                    .ProjectTo<ExampleDto>(
//                            //Always either define null
//                            (object)null
//                    // or include related tables:
//                    //x => x.Category,
//                    //x => x.Properties
//                    )
//                    .SingleOrDefault(x => x.Id == key);

//            // IMPORTANT: Make sure SecureAPI Post-Processor was invoked:
//            this._secureApiMessageAttribute.Process(result);
//            return result;
//        }

//        //// POST api/values 
//        public void Post(ExampleDto value)
//        {
//            InternalPost(value);
//        }

//        //// PUT api/values/5 
//        public void Put(ExampleDto value)
//        {
//            InternalPut(value);
//        }
//    }
//}
