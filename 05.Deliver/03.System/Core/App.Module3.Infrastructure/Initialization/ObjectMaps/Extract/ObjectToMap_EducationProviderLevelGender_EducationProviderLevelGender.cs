﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module3.Shared.Models.Entities;
using AutoMapper;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectToMap_EducationProviderLevelGender_EducationProviderLevelGender : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderLevelGender, EducationProviderLevelGender>()
                .ForMember(dest => dest.YearFK, opt => opt.MapFrom(s => s.YearFK)) //.ForMember(dest => dest.YearFK, opt => opt.MapFrom(s => s.YearValueId))          
                .ForMember(dest => dest.Year, opt => opt.MapFrom(s => s.Year))
                .ForMember(dest => dest.GenderFK, opt => opt.MapFrom(s => s.GenderFK)) //.ForMember(dest => dest.GenderFK, opt => opt.MapFrom(s => s.GenderValueId))    
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(s => s.Gender)) //  
                .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.EducationProviderFK)) //.ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.SchoolId))


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