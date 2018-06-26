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
    public class ObjectMap_SurveyLargeItem_SurveyLargeItemDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_SurveyLargeItemDto_SurveyLargeItem(config);
            Map_SurveyLargeItem_SurveyLargeItemDto(config);
        }

        private void Map_SurveyLargeItemDto_SurveyLargeItem(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLargeItemDto, SurveyLargeItem>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.LargeItem, opt => opt.Ignore())
                .ForMember(dest => dest.LargeItemFK, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyFK, opt => opt.MapFrom(src => src.SurveyId))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.DetailedDescription, opt => opt.MapFrom(src => src.DetailedDescription))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_SurveyLargeItem_SurveyLargeItemDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLargeItem, SurveyLargeItemDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.SurveyFK))
                .ForMember(dest => dest.DetailedDescription, opt => opt.MapFrom(src => src.DetailedDescription))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.LargeItem.Code))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.LargeItem.Category))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LargeItem.Description))
                ;
        }

        private void MapTenanacy(IMappingExpression<SurveyLargeItemDto, SurveyLargeItem> mappingExpression)
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
