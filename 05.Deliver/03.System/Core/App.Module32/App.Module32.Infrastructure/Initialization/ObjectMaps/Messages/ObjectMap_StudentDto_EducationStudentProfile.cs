using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Messages
{
    public class ObjectMap_StudentDto_EducationStudentProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_EducationStudentProfile_StudentDto(config);
            Map_StudentDto_EducationStudentProfile(config);
        }

        private void Map_StudentDto_EducationStudentProfile(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<StudentDto, EducationStudentProfile>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.NSN, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.EducationSchoolProfileFK, opt => opt.Ignore())
                .ForMember(dest => dest.EducationSchoolProfile, opt => opt.Ignore())
                .ForMember(dest => dest.SourceModifiedDate, opt => opt.Ignore())
                ;
            MapTenanacy(mappingExpression);
        }

        private void Map_EducationStudentProfile_StudentDto(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationStudentProfile, StudentDto>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.EducationSchoolProfile.SchoolId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.NSN))
                ;
        }

        private void MapTenanacy(IMappingExpression<StudentDto, EducationStudentProfile> mappingExpression)
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
