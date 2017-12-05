using App.Core.Application.Services;
using App.Core.Infrastructure.Db.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models;

namespace App.Core.Application.Presentation.Controllers
{
    using App.Core.Application.Models;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;
    using App.Module2.Shared.Models.Entities;

    /// <summary>
    /// Controller for the Views that explain how to use this framework.
    /// </summary>
    public class UsageController : Controller
    {
        private readonly IMediaUploadService _mediaUploadService;

        public UsageController(IDiagnosticsTracingService diagnosticsTracingService, IMediaUploadService mediaUploadService)
        {
            this._mediaUploadService = mediaUploadService;
            // Tip: Being a template, it is preferable that the HomeController/Default Route does not get injected with a
            // DbContext, as that implies a correct Connection string and/or Authentication, that may fail the first
            // time deployed to Azure.
            diagnosticsTracingService.Trace(TraceLevel.Verbose, "Hi");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Setup";
            return View();
        }
        public ActionResult ConfigurationStepRecord()
        {
            return View();
        }
        public ActionResult Exception()
        {
            return View();
        }
        public ActionResult DataClassification()
        {
            return View();
        }
        public ActionResult Principal()
        {
            return View();
        }
        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Tenant()
        {
            return View();
        }

        public ActionResult Session()
        {
            return View();
        }
        public ActionResult SessionOperation()
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }



        public ActionResult EducationOrganisation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MediaMetadata()
        {
            return View();
        }


        [HttpPost]
        public ActionResult MediaMetadata(MediaUpload mediaUpload, HttpPostedFileBase file)
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