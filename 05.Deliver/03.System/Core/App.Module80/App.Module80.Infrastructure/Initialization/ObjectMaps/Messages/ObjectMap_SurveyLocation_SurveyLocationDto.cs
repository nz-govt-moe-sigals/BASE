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
    public class ObjectMap_SurveyLocation_SurveyLocationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_SurveyLocationDto_SurveyLocation(config);
            Map_SurveyLocation_SurveyLocationDto(config);
        }

        private void Map_SurveyLocationDto_SurveyLocation(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLocationDto, SurveyLocation>()
                    .ForMember(dest => dest.SurveyLocationId, opt => opt.MapFrom(src => src.SurveyLocationId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Access, opt => opt.MapFrom(src => src.Access))
                    
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                    .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                    .ForMember(dest => dest.PipesOrDrainsInput, opt => opt.MapFrom(src => src.PipesOrDrainsInput))
                    .ForMember(dest => dest.RiverInputName, opt => opt.MapFrom(src => src.RiverInputName))
                    .ForMember(dest => dest.Region, opt => opt.Ignore())
                    .ForMember(dest => dest.RegionFK, opt => opt.Ignore())
                    .ForMember(dest => dest.Surveys, opt => opt.Ignore())
                ;
            MapTenanacy(mappingExpression);
            MapNearest(mappingExpression);
            MapBeach(mappingExpression);
        }

        private void Map_SurveyLocation_SurveyLocationDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SurveyLocation, SurveyLocationDto>()
                    .ForMember(dest => dest.SurveyLocationId, opt => opt.MapFrom(src => src.SurveyLocationId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Access, opt => opt.MapFrom(src => src.Access))
                    .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
                    .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                    .ForMember(dest => dest.PipesOrDrainsInput, opt => opt.MapFrom(src => src.PipesOrDrainsInput))
                    .ForMember(dest => dest.RiverInputName, opt => opt.MapFrom(src => src.RiverInputName))
                    .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region))
                    .ForMember(dest => dest.Surveys, opt => opt.MapFrom(src => src.Surveys))
                    
                ;
            MapNearest(mappingExpression);
            MapBeach(mappingExpression);
        }

        private void MapBeach(IMappingExpression<SurveyLocationDto, SurveyLocation> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.BackOfBeach, opt => opt.MapFrom(src => src.BackOfBeach))
                .ForMember(dest => dest.TidalDistance, opt => opt.MapFrom(src => src.TidalDistance))
                .ForMember(dest => dest.TidalRange, opt => opt.MapFrom(src => src.TidalRange))
                .ForMember(dest => dest.SubstrateUniformity, opt => opt.MapFrom(src => src.SubstrateUniformity))
                .ForMember(dest => dest.SubstratumType, opt => opt.MapFrom(src => src.SubstratumType))
                ;
        }

        private void MapBeach(IMappingExpression<SurveyLocation, SurveyLocationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.BackOfBeach, opt => opt.MapFrom(src => src.BackOfBeach))
                .ForMember(dest => dest.TidalDistance, opt => opt.MapFrom(src => src.TidalDistance))
                .ForMember(dest => dest.TidalRange, opt => opt.MapFrom(src => src.TidalRange))
                .ForMember(dest => dest.SubstrateUniformity, opt => opt.MapFrom(src => src.SubstrateUniformity))
                .ForMember(dest => dest.SubstratumType, opt => opt.MapFrom(src => src.SubstratumType))
                ;
        }

        private void MapNearest(IMappingExpression<SurveyLocationDto, SurveyLocation> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.NearestRiverDirection, opt => opt.MapFrom(src => src.NearestRiverDirection))
                .ForMember(dest => dest.NearestRiverName, opt => opt.MapFrom(src => src.NearestRiverName))
                .ForMember(dest => dest.NearestRiverDistance, opt => opt.MapFrom(src => src.NearestRiverDistance))
                .ForMember(dest => dest.NearestTown, opt => opt.MapFrom(src => src.NearestTown))
                .ForMember(dest => dest.NearestTownDirection, opt => opt.MapFrom(src => src.NearestTownDirection))
                .ForMember(dest => dest.NearestTownDistance, opt => opt.MapFrom(src => src.NearestTownDistance))
                ;
        }

        private void MapNearest(IMappingExpression<SurveyLocation, SurveyLocationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.NearestRiverDirection, opt => opt.MapFrom(src => src.NearestRiverDirection))
                .ForMember(dest => dest.NearestRiverName, opt => opt.MapFrom(src => src.NearestRiverName))
                .ForMember(dest => dest.NearestRiverDistance, opt => opt.MapFrom(src => src.NearestRiverDistance))
                .ForMember(dest => dest.NearestTown, opt => opt.MapFrom(src => src.NearestTown))
                .ForMember(dest => dest.NearestTownDirection, opt => opt.MapFrom(src => src.NearestTownDirection))
                .ForMember(dest => dest.NearestTownDistance, opt => opt.MapFrom(src => src.NearestTownDistance))
                ;
        }

        private void MapTenanacy(IMappingExpression<SurveyLocationDto, SurveyLocation> mappingExpression)
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
