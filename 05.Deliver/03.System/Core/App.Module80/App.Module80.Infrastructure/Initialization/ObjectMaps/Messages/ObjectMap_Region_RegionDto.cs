using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module80.Shared.Models.Entities;
using App.Module80.Shared.Models.Messages.API;
using AutoMapper;

namespace App.Module80.Infrastructure.Initialization.ObjectMaps.Messages
{
    public class ObjectMap_Region_RegionDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_RegionDto_Region(config);
            Map_Region_RegionDto(config);
        }

        private void Map_RegionDto_Region(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<RegionDto, Region>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Beaches, opt => opt.Ignore())
                .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_Region_RegionDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<Region, RegionDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Beaches, opt => opt.MapFrom(src => src.Beaches))
                    .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
                ;
        }

        private void MapTenanacy(IMappingExpression<RegionDto, Region> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
