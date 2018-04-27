using System.Diagnostics;

namespace App.Module3.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Infrastructure.Services;
    using App.Module3.Infrastructure.Db.Context;
    using App.Module3.Infrastructure.Services;
    using App.Module3.Infrastructure.Services.Implementations.Extract;
    using App.Module3.Shared.Models.Messages.Extract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;


    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    [AllowAnonymous]
    public class ExtractController : ApiController
    {
        private readonly IExtractServiceController _extractServiceController;

        public ExtractController(IExtractServiceController extractServiceController)
        {
            _extractServiceController = extractServiceController;
        }

        public string Get()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            _extractServiceController.ProcessAllTables();
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return $"success - elapsedTime : {elapsedTime}";
        }

    }
}