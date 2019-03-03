using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using App.Core.Application.Filters.WebApi;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Constants;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages;

namespace App.Core.Application.API.Controllers.V0100
{
    public class MediaUploadController : ApiController
    {
        private readonly IMediaUploadService _mediaUploadService;

        public MediaUploadController(IMediaUploadService mediaUploadService)
        {
            this._mediaUploadService = mediaUploadService;
        }



        [HttpPost]
        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        public IHttpActionResult Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    if(postedFile == null) return BadRequest();
                    var uploadedMedia = new UploadedMedia();
                    uploadedMedia.FileName = postedFile.FileName;
                    uploadedMedia.Length = postedFile.ContentLength;
                    uploadedMedia.ContentType = postedFile.ContentType;
                    using (var reader = new System.IO.BinaryReader(postedFile.InputStream))
                    {
                        uploadedMedia.Stream = reader.ReadBytes(postedFile.ContentLength);
                    }
                    this._mediaUploadService.Process(uploadedMedia, NZDataClassification.Unspecified);
                }
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
