namespace App.Core.Application.ServiceFacade.Controllers.API.V0100
{
    using System.Collections.Generic;
    using System.Web.Http;
    using App.Core.Shared.Models.Messages.APIs;

    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    public class Values1Controller : ApiController
    {
        private static readonly List<SmokeTestItem> _inMemFakeDb = new List<SmokeTestItem>();

        static Values1Controller()
        {
            _inMemFakeDb.Add(new SmokeTestItem {Id = 1, SomeLabel = "Foo"});
            _inMemFakeDb.Add(new SmokeTestItem {Id = 2, SomeLabel = "Bar"});
        }

        public IEnumerable<SmokeTestItem> Get()
        {
            IEnumerable<SmokeTestItem> item = _inMemFakeDb /*no filtering*/;
            return item;
        }
    }
}