namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_MediaMetadata_MediaMetadataDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<MediaMetadata, MediaMetadataDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification);})
                .ForMember(t => t.ContentSize, opt => opt.MapFrom(s => s.ContentSize))
                .ForMember(t => t.ContentHash, opt => opt.MapFrom(s => s.ContentHash))
                .ForMember(t => t.LocalName, opt => opt.MapFrom(s => s.LocalName))
                .ForMember(t => t.LatestScanDateTimeUtc, opt => opt.MapFrom(s => s.LatestScanDateTimeUtc))
                .ForMember(t => t.LatestScanMalwareDetetected, opt => opt.MapFrom(s => s.LatestScanMalwareDetetected))
                .ForMember(t => t.LatestScanResults, opt => opt.MapFrom(s => s.LatestScanResults))
                .ForMember(t => t.MimeType, opt => opt.MapFrom(s => s.MimeType))
                .ForMember(t => t.SourceFileName, opt => opt.MapFrom(s => s.SourceFileName))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.UploadedDateTimeUtc, opt => opt.MapFrom(s => s.UploadedDateTimeUtc));



            // Use an Enum as DataClassification is shared across Bounded DbContexts
            // Results of scanning, whenever done:

        }
    }
}