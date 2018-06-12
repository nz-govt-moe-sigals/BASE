using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.Extract;
using AutoMapper;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectMap_EducationStudentProfile_EducationStudentProfile : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationStudentProfile, EducationStudentProfile>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.SourceModifiedDate, opt => opt.MapFrom(src => src.SourceModifiedDate))
                    .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.NSN, opt => opt.MapFrom(src => src.NSN))
                ;
            MapSchool(mappingExpression);
            MapTenancy(mappingExpression);
        }

        private void MapSchool(IMappingExpression<EducationStudentProfile, EducationStudentProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.EducationSchoolProfileFK, opt =>
                {
                    opt.Condition((src, dest) => dest.EducationSchoolProfileFK != src.EducationSchoolProfileFK);// suppose dest is not null.
                    opt.MapFrom(src => src.EducationSchoolProfileFK);
                })
                .ForMember(dest => dest.EducationSchoolProfile, opt =>
                {
                    opt.Condition((src, dest) => dest.EducationSchoolProfileFK != src.EducationSchoolProfileFK);// suppose dest is not null.
                    opt.MapFrom(src => src.EducationSchoolProfile);
                })
                ;
        }

        private void MapTenancy(IMappingExpression<EducationStudentProfile, EducationStudentProfile> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())

                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}
