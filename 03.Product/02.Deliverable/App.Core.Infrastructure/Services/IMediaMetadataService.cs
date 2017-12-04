namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;
    using App.Core.Shared.Services;

    public interface IMediaMetadataService : IHasAppCoreService
    {
        MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification);
    }
}