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
    public class ObjectMap_Organisation_OrganisationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_OrganisationDto_Organisation(config);
            Map_Organisation_OrganisationDto(config);
        }

        private void Map_OrganisationDto_Organisation(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<OrganisationDto, Organisation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surveys, opt => opt.Ignore())
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_Organisation_OrganisationDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<Organisation, OrganisationDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surveys, opt => opt.MapFrom(src => src.Surveys))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                ;
        }

        private void MapTenanacy(IMappingExpression<OrganisationDto, Organisation> mappingExpression)
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
