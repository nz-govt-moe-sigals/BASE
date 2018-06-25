using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Messages
{
    public class ObjectMap_SchoolDto_EducationSchoolProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_EducationSchoolProfile_SchoolDto(config);
            Map_SchoolDto_EducationSchoolProfile(config);
        }

        private void Map_SchoolDto_EducationSchoolProfile(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<SchoolDto, EducationSchoolProfile>()
                    .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.SourceModifiedDate, opt => opt.Ignore())
                ;
            MapTenanacy(mappingExpression);
        }


        private void Map_EducationSchoolProfile_SchoolDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationSchoolProfile, SchoolDto>()
                    .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                ;
        }

        private void MapTenanacy(IMappingExpression<SchoolDto, EducationSchoolProfile> mappingExpression)
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
