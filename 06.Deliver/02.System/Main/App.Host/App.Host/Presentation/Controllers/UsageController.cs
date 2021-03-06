﻿using System;
using System.Web;
using System.Web.Mvc;
using App.Core.Infrastructure.Services;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages;
using App.Host.Models;


namespace App.Host.Presentation.Controllers
{
    /// <summary>
    /// Controller for the Views that explain how to use this framework.
    /// </summary>
    [AllowAnonymous]
    public partial class UsageController : Controller
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
        public ActionResult Metadata()
        {
            return View();
        }

        public ActionResult MiscExamples()
        {
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

        // FIX: Cannot call this view 'Session', as underlying 'Controller' has a 'Session' Property. 
        public ActionResult PrincipalSession()
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

                        this._mediaUploadService.Process(uploadedMedia, mediaUpload.DataClassification);
                        ViewBag.Message = "File Uploaded Successfully!!";

                        if (StringComparer.InvariantCultureIgnoreCase.Compare(mediaUpload.SomeCustomData,
                                "Directory") == 0)
                        {
                            long check = file.InputStream.Position;
                            //Rewind:
                            file.InputStream.Position = 0;
                            //_studentRawImportService.Do(file.InputStream);
                        }
                        //Place Using outside of Do, as it will close the underlying Stream (not good)
                    }
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