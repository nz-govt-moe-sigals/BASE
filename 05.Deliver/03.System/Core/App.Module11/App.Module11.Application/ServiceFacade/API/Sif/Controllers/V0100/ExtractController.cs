using System.Diagnostics;

namespace App.Module11.Application.ServiceFacade.API.Controllers.V0100
{
    using App.Core.Infrastructure.Services;
    using App.Module11.Infrastructure.Db.Context;
    using App.Module11.Infrastructure.Services;
    using App.Module11.Infrastructure.Services.Implementations.Extract;
    using App.Module11.Shared.Models.Messages.Extract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Core.Application.ServiceFacade.API.Controllers.Base.Base;


    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    public class ExtractController : ApiControllerCommonBase
    {
        private readonly IExtractServiceController _extractServiceController;

        public ExtractController(IPrincipalService principalService, IExtractServiceController extractServiceController):base(principalService)
        {
            _extractServiceController = extractServiceController;
        }

        [AllowAnonymous]
        public string Get()
        {
            using (var elapsedTime = new ElapsedTime())
            {
                _extractServiceController.ProcessAllTables();

                return $"success - elapsedTime : {elapsedTime.ElapsedText}";
            }

        }

    }
}