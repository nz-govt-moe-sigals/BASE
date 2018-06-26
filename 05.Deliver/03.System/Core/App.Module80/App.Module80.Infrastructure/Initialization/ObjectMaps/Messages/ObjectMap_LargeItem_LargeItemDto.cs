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
    public class ObjectMap_LargeItem_LargeItemDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_LargeItemDto_LargeItem(config);
            Map_LargeItem_LargeItemDto(config);
        }

        private void Map_LargeItemDto_LargeItem(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<LargeItemDto, LargeItem>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_LargeItem_LargeItemDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<LargeItem, LargeItemDto>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                ;
        }

        private void MapTenanacy(IMappingExpression<LargeItemDto, LargeItem> mappingExpression)
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