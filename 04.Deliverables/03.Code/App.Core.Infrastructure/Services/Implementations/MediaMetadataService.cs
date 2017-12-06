namespace App.Core.Infrastructure.Services.Implementations
{
    using System.Security.Cryptography;
    using System.Text;
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;

    public class MediaMetadataService : IMediaMetadataService
    {
        private readonly IHostSettingsService _hostSettingsService;
        private readonly IUniversalDateTimeService _universalDateTimeService;
        MediaManagementConfiguration _configuration;
        
        public MediaMetadataService(IHostSettingsService hostSettingsService, IUniversalDateTimeService universalDateTimeService)
        {
            this._hostSettingsService = hostSettingsService;
            this._universalDateTimeService = universalDateTimeService;
            _configuration = this._hostSettingsService.GetObject<MediaManagementConfiguration>();

        }

        //Service to create a metadata object that describes the uploaded Media file.
        public MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            var result = new MediaMetadata();

            result.ContentSize = uploadedMedia.Length;
            result.SourceFileName = uploadedMedia.FileName;
            result.DataClassificationFK = dataClassification;
            result.ContentHash = uploadedMedia.Stream.GetHashAsString(this._configuration.HashType);
            result.MimeType = uploadedMedia.ContentType;

            result.UploadedDateTimeUtc = this._universalDateTimeService.NowUtc().UtcDateTime;

            return result;
        }
    }
}