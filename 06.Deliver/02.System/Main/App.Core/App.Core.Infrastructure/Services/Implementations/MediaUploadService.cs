﻿namespace App.Core.Infrastructure.Services.Implementations
{
    using System;
    using App.Core.Infrastructure.Db.Context;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;
    using App.Core.Shared.Models.Messages;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IMediaUploadService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IMediaUploadService" />
    public class MediaUploadService : AppCoreServiceBase, IMediaUploadService
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IMediaMalwareDetectionService _mediaMalwareVerificationService;
        private readonly IMediaMetadataService _mediaMetadataService;
        private readonly IRepositoryService _repositoryService;
        private readonly IUniversalDateTimeService _universalDateTimeService;
        private readonly IStorageService _storageService;

        public MediaUploadService(IDiagnosticsTracingService diagnosticsTracingService, IUniversalDateTimeService universalDateTimeService,
            IStorageService storageService,
            IMediaMalwareDetectionService mediaMalwareVerificationService,
            IMediaMetadataService mediaMetadataService, IRepositoryService repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._mediaMalwareVerificationService = mediaMalwareVerificationService;
            this._mediaMetadataService = mediaMetadataService;
            this._repositoryService = repositoryService;
            this._universalDateTimeService = universalDateTimeService;
            this._storageService = storageService;
        }

        public void Process(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            //First, build a summary of the uploaded file:
            MediaMetadata mediaMetadata =
                this._mediaMetadataService.Create(uploadedMedia, dataClassification);


            ScanFile(ref uploadedMedia, ref mediaMetadata);
            if (mediaMetadata.LatestScanResults == "content.en.language.nsfw")
            {
                mediaMetadata.LatestScanMalwareDetetected = false;
            }

            if (mediaMetadata.LatestScanMalwareDetetected.HasValue && mediaMetadata.LatestScanMalwareDetetected.Value == false)
            {
                //TODO: TO BE REVISITED
                mediaMetadata.LocalName = Guid.NewGuid().ToString();

                this._storageService.Persist(uploadedMedia.Stream, mediaMetadata.LocalName);
            }

            this._repositoryService.AddOnCommit(Constants.Db.AppCoreDbContextNames.Core, mediaMetadata);
        }

        private void ScanFile(ref UploadedMedia uploadedMedia, ref MediaMetadata mediaMetadata)
        {
            var scanResults = this._mediaMalwareVerificationService.Validate(uploadedMedia.Stream, uploadedMedia.FileName,
                uploadedMedia.ContentType);

            mediaMetadata.LatestScanDateTimeUtc = this._universalDateTimeService.NowUtc().UtcDateTime;
            mediaMetadata.LatestScanResults = scanResults.LatestScanResults;
            mediaMetadata.LatestScanMalwareDetetected = scanResults.LatestScanMalwareDetected;


        }
    }
}