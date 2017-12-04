using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Core.Application.Presentation.Controllers
{
    using System.IO;
    using App.Core.Application.Models;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Messages;

    public class MediaUploadController : Controller
    {
        private readonly IMediaUploadService _mediaUploadService;

        public MediaUploadController(IMediaUploadService mediaUploadService)
        {
            this._mediaUploadService = mediaUploadService;
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Upload(MediaUpload mediaUpload, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var uploadedMedia = new UploadedMedia();
                    uploadedMedia.FileName = file.FileName;
                    uploadedMedia.Length = file.ContentLength;
                    uploadedMedia.ContentType = file.ContentType;

                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        uploadedMedia.Stream = reader.ReadBytes(file.ContentLength);
                    }
                    this._mediaUploadService.Process(uploadedMedia, mediaUpload.DataClassification);
                    ViewBag.Message = "File Uploaded Successfully!!";
                }
                else
                {
                    ViewBag.Message = "No file uploaded.";
                }

                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
 }
