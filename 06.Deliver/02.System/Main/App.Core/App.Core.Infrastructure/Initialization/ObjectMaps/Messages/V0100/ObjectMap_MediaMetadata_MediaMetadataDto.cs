using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Entities.TenancySpecific;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_MediaMetadata_MediaMetadataDto
        : MapUntenantedAuditedRecordStateBase<MediaMetadataDto, MediaMetadata>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_MediaMetadata_MediaMetadataDto(config);
            Map_MediaMetadataDto_MediaMetadata(config);
        }

        public void Map_MediaMetadata_MediaMetadataDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<MediaMetadata, MediaMetadataDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
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

        public void Map_MediaMetadataDto_MediaMetadata(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<MediaMetadataDto, MediaMetadata>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.ContentSize, opt => opt.MapFrom(s => s.ContentSize))
                .ForMember(t => t.ContentHash, opt => opt.MapFrom(s => s.ContentHash))
                .ForMember(t => t.LocalName, opt => opt.MapFrom(s => s.LocalName))
                .ForMember(t => t.MimeType, opt => opt.MapFrom(s => s.MimeType))
                .ForMember(t => t.SourceFileName, opt => opt.MapFrom(s => s.SourceFileName))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.UploadedDateTimeUtc, opt => opt.MapFrom(s => s.UploadedDateTimeUtc))
                .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            MapLatest(mappingExpression);
            MapBase(mappingExpression);
            // Use an Enum as DataClassification is shared across Bounded DbContexts
            // Results of scanning, whenever done:
        }

        private void MapLatest(IMappingExpression<MediaMetadataDto, MediaMetadata> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.LatestScanDateTimeUtc, opt => opt.MapFrom(s => s.LatestScanDateTimeUtc))
                .ForMember(t => t.LatestScanMalwareDetetected, opt => opt.MapFrom(s => s.LatestScanMalwareDetetected))
                .ForMember(t => t.LatestScanResults, opt => opt.MapFrom(s => s.LatestScanResults))
                ;
        }
    }
}