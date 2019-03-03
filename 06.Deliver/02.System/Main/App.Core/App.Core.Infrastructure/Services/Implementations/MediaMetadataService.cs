namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Security.Cryptography;
    using System.Text;
    using App.Core.Infrastructure.Services.Configuration.Implementations;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;
    using App.Core.Shared.Models.Messages;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IMediaMetadataService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Services.IMediaMetadataService" />
    public class MediaMetadataService : AppCoreServiceBase, IMediaMetadataService
    {
        //private readonly IHostSettingsService _hostSettingsService;
        private readonly MediaMetadataServiceConfiguration _metadataServiceConfiguration;

        private readonly IUniversalDateTimeService _universalDateTimeService;
        
        public MediaMetadataService(MediaMetadataServiceConfiguration metadataServiceConfiguration, IHostSettingsService hostSettingsService, IUniversalDateTimeService universalDateTimeService)
        {
            this._metadataServiceConfiguration = metadataServiceConfiguration;
            this._universalDateTimeService = universalDateTimeService;

        }

        //Service to create a metadata object that describes the uploaded Media file.
        public MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            var result = new MediaMetadata();

            result.ContentSize = uploadedMedia.Length;
            result.SourceFileName = uploadedMedia.FileName;
            result.DataClassificationFK = dataClassification;
            result.ContentHash = uploadedMedia.Stream.GetHashAsString(this._metadataServiceConfiguration.MediaManagementConfiguration.HashType);
            result.MimeType = uploadedMedia.ContentType ?? "Unknown";

            result.UploadedDateTimeUtc = this._universalDateTimeService.NowUtc().UtcDateTime;

            return result;
        }
    }
}