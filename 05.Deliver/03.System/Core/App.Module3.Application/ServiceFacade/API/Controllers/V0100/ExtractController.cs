namespace App.Module3.Application.ServiceFacade.API.Controllers.V0100
{
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
        private AppModule3DbContext _dbContext;
        private IExtractAzureDocumentDbService _documentDBService;
        public ExtractController(
            AppModule3DbContext dbContext, 
            IExtractAzureDocumentDbService documentDBService)
        {
            _dbContext = dbContext;
            _documentDBService = documentDBService;
        }

        public void Get()
        {
            IBaseExtractService baseExtractService = new BaseExtractService<ReferenceAreaUnits>(_dbContext, _documentDBService);
            baseExtractService.Process();
        }

    }
}