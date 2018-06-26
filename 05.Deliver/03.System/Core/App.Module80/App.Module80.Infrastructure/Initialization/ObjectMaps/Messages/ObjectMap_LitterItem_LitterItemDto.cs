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
    public class ObjectMap_LitterItem_LitterItemDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_LitterItemDto_LitterItem(config);
            Map_LitterItem_LitterItemDto(config);
        }

        private void Map_LitterItemDto_LitterItem(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<LitterItemDto, LitterItem>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_LitterItem_LitterItemDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<LitterItem, LitterItemDto>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                ;
        }

        private void MapTenanacy(IMappingExpression<LitterItemDto, LitterItem> mappingExpression)
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
