using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module31.Shared.Models.Entities;
using AutoMapper;

namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectToMap_EducationProviderLevelGender_EducationProviderLevelGender : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<EducationProviderLevelGender, EducationProviderLevelGender>()
                .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.EducationProviderFK)) //.ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.SchoolId))
                ;
            MapSystem(mappingExpression);
            MapTenancy(mappingExpression);
            MapGenderAndYear(mappingExpression);
        }

        private void MapSystem(IMappingExpression<EducationProviderLevelGender, EducationProviderLevelGender> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                ;
        }

        private void MapTenancy(IMappingExpression<EducationProviderLevelGender, EducationProviderLevelGender> mappingExpression)
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

        private void MapGenderAndYear(IMappingExpression<EducationProviderLevelGender, EducationProviderLevelGender> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.YearFK, opt =>
                {
                    opt.Condition((src, dest) => dest.YearFK != src.YearFK);// suppose dest is not null.
                    opt.MapFrom(src => src.YearFK);
                })
                .ForMember(dest => dest.Level, opt =>
                {
                    opt.Condition((src, dest) => dest.YearFK != src.YearFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Level);
                })
                .ForMember(dest => dest.GenderFK, opt =>
                {
                    opt.Condition((src, dest) => dest.GenderFK != src.GenderFK);// suppose dest is not null.
                    opt.MapFrom(src => src.GenderFK);
                })
                .ForMember(dest => dest.Gender, opt =>
                {
                    opt.Condition((src, dest) => dest.GenderFK != src.GenderFK);// suppose dest is not null.
                    opt.MapFrom(src => src.Gender);
                })
                ;
        }
    }
}





