namespace App.Module3.Application.ServiceFacade.API.Controllers.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Module3.Shared.Models.Entities;

    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    public class Example1Controller : ApiController
    {
        private static readonly List<Example> _inMemFakeDb = new List<Example>();

        static Example1Controller()
        {
            _inMemFakeDb.Add(new Example
            {
                Id = 1.ToGuid(),
                PublicText =
                    "Example1 is a simple API controller, with just a static inmem (fake) db, and no Dependency Injection going on",
                AppPrivateText = "Description:PrivateText",
                SensitiveText = "Description:SensitiveText"
            });
            _inMemFakeDb.Add(new Example
            {
                Id = 2.ToGuid(),
                PublicText = "Foo",
                AppPrivateText = "Foo:PrivateText",
                SensitiveText = "Foo:SensitiveText"
            });
            _inMemFakeDb.Add(new Example
            {
                Id = 3.ToGuid(),
                PublicText = "Bar",
                AppPrivateText = "Bar:PrivateText",
                SensitiveText = "Bar:SensitiveText"
            });
        }


        public IEnumerable<Example> Get()
        {
            IEnumerable<Example> item = _inMemFakeDb /*no filtering*/;
            return item;
        }

        public void Post(Example example)
        {
            // Validate payload:
            if (string.IsNullOrEmpty(example.PublicText))
            {
                throw new WebException("Please provide a example description");
            }
            _inMemFakeDb.Add(example);
        }

        public void Delete(Guid id)
        {
            var example = _inMemFakeDb.FirstOrDefault(x => x.Id.Equals(id));
            _inMemFakeDb.Remove(example);
        }
    }
}