namespace App.Core.Infrastructure.Services
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;
    using App.Core.Shared.Services;


    public interface IMediaUploadService : IHasAppCoreService
    {
        void Process(UploadedMedia mediaStream, NZDataClassification dataClassification);

    }
}