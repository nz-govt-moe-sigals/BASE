namespace App.Core.Application.ServiceFacade.Controllers.API.V0100
{
    using System.Collections.Generic;
    using System.Web.Http;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages.APIs;

    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    public class Values2Controller : ApiController
    {
        private static readonly List<SmokeTestItem> _inMemFakeDb = new List<SmokeTestItem>();
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        static Values2Controller()
        {
            _inMemFakeDb.Add(new SmokeTestItem {Id = 1, SomeLabel = "Foo"});
            _inMemFakeDb.Add(new SmokeTestItem {Id = 2, SomeLabel = "Bar"});
        }

        public Values2Controller(IDiagnosticsTracingService diagnosticsTracingService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
        }

        public IEnumerable<SmokeTestItem> Get()
        {
            IEnumerable<SmokeTestItem> item = _inMemFakeDb /*no filtering*/;
            return item;
        }
    }
}