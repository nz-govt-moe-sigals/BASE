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
    public class ObjectMap_SurveyLitterItem_SurveyLitterItemDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_SurveyLitterItemDto_SurveyLitterItem(config);
            Map_SurveyLitterItem_SurveyLitterItemDto(config);
        }

        private void Map_SurveyLitterItemDto_SurveyLitterItem(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLitterItemDto, SurveyLitterItem>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.LitterItem, opt => opt.Ignore())
                .ForMember(dest => dest.LitterItemFK, opt => opt.Ignore())
                .ForMember(dest => dest.SurveyFK, opt => opt.MapFrom(src => src.SurveyId))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_SurveyLitterItem_SurveyLitterItemDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLitterItem, SurveyLitterItemDto>()
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.SurveyId, opt => opt.MapFrom(src => src.SurveyFK))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.LitterItem.Code))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.LitterItem.Category))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LitterItem.Description))
                ;
        }

        private void MapTenanacy(IMappingExpression<SurveyLitterItemDto, SurveyLitterItem> mappingExpression)
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
