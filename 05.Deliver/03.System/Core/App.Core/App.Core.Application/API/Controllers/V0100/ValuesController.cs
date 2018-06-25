using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using App.Core.Infrastructure.Constants.Storage;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Messages.API;
using Microsoft.Web.Http;

namespace App.Core.Application.API.Controllers.V0100
{

    public class TermsController : ApiController {
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        private readonly IDictionaryBasedMimeTypeService _dictionaryBasedMimeTypeService;

        public TermsController(IAzureBlobStorageService azureBlobStorageService, IDictionaryBasedMimeTypeService dictionaryBasedMimeTypeService)
        {
            this._azureBlobStorageService = azureBlobStorageService;
            this._dictionaryBasedMimeTypeService = dictionaryBasedMimeTypeService;
        }

        public void init()
        {
            try
            {
                
                this._azureBlobStorageService.DownloadAText(null, BlobStorageContainers.Public, Infrastructure.Constants.Resources.DefaultDocuments.RelativePaths.TermsAndConditions);
            }catch
            {
                //HttpContext.Current.Server.MapPath
                string imagePath = VirtualPathUtility.ToAppRelative("~/" + Infrastructure.Constants.Resources.DefaultDocuments.RelativePaths.TermsAndConditions);

                //Does not exist.
                //So copy the local file.
            }


        }


        [HttpGet]
        public HttpResponseMessage Generate()
        {
            using (var stream = new MemoryStream())
            {
                // processing the stream.

                var result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(stream.ToArray())
                };
                result.Content.Headers.ContentDisposition =
                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "CertificationCard.pdf"
                        };
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                return result;
            }
        }
    }

    /// <summary>
    ///     Example1 is a straight WebAPI Controller, with DI, but no backing Db (it's just an in-mem list 'db').
    /// </summary>
    //See how to do this *globally*: [ExampleWebApiActionFilter] [AppCoreDbContextWebApiFilter]
    [ApiVersion("1.0")]
    public class ValuesController : ApiController
    {
        private static readonly List<SmokeTestItem> _inMemFakeDb = new List<SmokeTestItem>();

        static ValuesController()
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