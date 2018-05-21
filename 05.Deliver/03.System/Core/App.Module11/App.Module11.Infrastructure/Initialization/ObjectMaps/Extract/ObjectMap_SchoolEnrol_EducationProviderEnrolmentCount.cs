
﻿using System;
using AutoMapper;
using App.Module11.Shared.Models.Entities;
using App.Module11.Shared.Models.Messages.Extract;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Extract
{
    public class ObjectMap_SchoolEnrol_EducationProviderEnrolmentCount : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SchoolEnrol, EducationProviderEnrolmentCount>()
                .ForMember(dest => dest.Asian, opt => opt.MapFrom(s => s.Asian))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(s => s.EffectiveDate))
                .ForMember(dest => dest.European, opt => opt.MapFrom(s => s.European))
                .ForMember(dest => dest.International, opt => opt.MapFrom(s => s.International))
                .ForMember(dest => dest.Maori, opt => opt.MapFrom(s => s.Maori))
                .ForMember(dest => dest.MELAA, opt => opt.MapFrom(s => s.Melaa))
                .ForMember(dest => dest.Other, opt => opt.MapFrom(s => s.Other))
                .ForMember(dest => dest.Pasifika, opt => opt.MapFrom(s => s.Pasifika))
                .ForMember(dest => dest.EducationProviderFK, opt => opt.Ignore()) //.ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.TotalRoll, opt => opt.MapFrom(s => s.TotalRoll))
                .ForMember(dest => dest.SourceSystemKey, opt => opt.MapFrom(s => s.EnrolId))
                .ForMember(dest => dest.SourceSystemName, opt => opt.Ignore())
                ;
        }
    }
}

