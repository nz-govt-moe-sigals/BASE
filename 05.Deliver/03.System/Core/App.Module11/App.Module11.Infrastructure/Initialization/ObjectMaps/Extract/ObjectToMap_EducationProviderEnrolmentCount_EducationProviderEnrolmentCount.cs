using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module11.Shared.Models.Entities;
using AutoMapper;

namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectToMap_EducationProviderEnrolmentCount_EducationProviderEnrolmentCount : IHasAutomapperInitializer
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderEnrolmentCount, EducationProviderEnrolmentCount>()
                .ForMember(dest => dest.Asian, opt => opt.MapFrom(s => s.Asian))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(s => s.Date))
                .ForMember(dest => dest.European, opt => opt.MapFrom(s => s.European))
                .ForMember(dest => dest.International, opt => opt.MapFrom(s => s.International))
                .ForMember(dest => dest.Maori, opt => opt.MapFrom(s => s.Maori))
                .ForMember(dest => dest.MELAA, opt => opt.MapFrom(s => s.MELAA))
                .ForMember(dest => dest.Other, opt => opt.MapFrom(s => s.Other))
                .ForMember(dest => dest.Pasifika, opt => opt.MapFrom(s => s.Pasifika))
                .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.EducationProviderFK)) //.ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.TotalRoll, opt => opt.MapFrom(s => s.TotalRoll))


                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.SourceSystemKey))
                .ForMember(dest => dest.SourceSystemName, opt => opt.MapFrom(s => s.SourceSystemName))

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
