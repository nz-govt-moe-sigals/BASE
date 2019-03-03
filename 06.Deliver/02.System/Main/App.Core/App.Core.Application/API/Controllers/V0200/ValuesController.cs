//using System.Collections.Generic;
//using System.Web.Http;
//using App.Core.Infrastructure.Services;
//using App.Core.Shared.Models.Messages.API;
//using Microsoft.Web.Http;

//namespace App.Core.Application.API.Controllers.V0200
//{
//    /// <summary>
//    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
//    /// </summary>
//    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
//    [ApiVersion("2.0")]
//    public class ValuesController : ApiController
//    {
//        private static readonly List<SmokeTestItem> _inMemFakeDb = new List<SmokeTestItem>();
//        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

//        static ValuesController()
//        {
//            _inMemFakeDb.Add(new SmokeTestItem {Id = 1, SomeLabel = "Foo"});
//            _inMemFakeDb.Add(new SmokeTestItem {Id = 2, SomeLabel = "Bar"});
//        }

//        public ValuesController(IDiagnosticsTracingService diagnosticsTracingService)
//        {
//            this._diagnosticsTracingService = diagnosticsTracingService;
//        }

//        public IEnumerable<SmokeTestItem> Get()
//        {
//            IEnumerable<SmokeTestItem> item = _inMemFakeDb /*no filtering*/;
//            return item;
//        }
//    }
//}