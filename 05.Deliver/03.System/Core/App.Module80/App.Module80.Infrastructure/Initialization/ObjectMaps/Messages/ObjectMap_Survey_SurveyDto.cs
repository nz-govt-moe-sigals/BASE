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
    public class ObjectMap_Survey_SurveyDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_SurveyDto_Survey(config);
            Map_Survey_SurveyDto(config);
        }

        private void Map_SurveyDto_Survey(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyDto, Survey>()
                .ForMember(dest => dest.Id, opt => {
                        opt.Condition(src => src.Id != null); // condition here
                        opt.MapFrom(s => s.Id);
                    })
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SurveyLocation, opt => opt.Ignore())
                .ForMember(dest => dest.BeachFK, opt => opt.Ignore())
                .ForMember(dest => dest.Organisation, opt => opt.Ignore())
                .ForMember(dest => dest.OrganisationFK, opt => opt.Ignore())
                .ForMember(dest => dest.StartLatitude, opt => opt.MapFrom(src => src.StartLatitude))
                .ForMember(dest => dest.StartLongitude, opt => opt.MapFrom(src => src.StartLongitude))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndLatitude, opt => opt.MapFrom(src => src.EndLatitude))
                .ForMember(dest => dest.EndLongitude, opt => opt.MapFrom(src => src.EndLongitude))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.NumberOfPersonsInvolved, opt => opt.MapFrom(src => src.NumberOfPersonsInvolved))
                .ForMember(dest => dest.LargeItems, opt => opt.Ignore())
                .ForMember(dest => dest.LitterItems, opt => opt.Ignore())
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_Survey_SurveyDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<Survey, SurveyDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SurveyLocation, opt => opt.MapFrom(src => src.SurveyLocation))
                .ForMember(dest => dest.Organisation, opt => opt.MapFrom(src => src.Organisation))
                .ForMember(dest => dest.StartLatitude, opt => opt.MapFrom(src => src.StartLatitude))
                .ForMember(dest => dest.StartLongitude, opt => opt.MapFrom(src => src.StartLongitude))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndLatitude, opt => opt.MapFrom(src => src.EndLatitude))
                .ForMember(dest => dest.EndLongitude, opt => opt.MapFrom(src => src.EndLongitude))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.NumberOfPersonsInvolved, opt => opt.MapFrom(src => src.NumberOfPersonsInvolved))
                .ForMember(dest => dest.LargeItems, opt => opt.MapFrom(src => src.LargeItems))
                .ForMember(dest => dest.LitterItems, opt => opt.MapFrom(src => src.LitterItems))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedOnUtc))
                ;
        }

        private void MapTenanacy(IMappingExpression<SurveyDto, Survey> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
