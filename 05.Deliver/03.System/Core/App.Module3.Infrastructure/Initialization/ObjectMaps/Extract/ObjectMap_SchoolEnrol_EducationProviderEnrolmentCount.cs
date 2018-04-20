using System;
using AutoMapper;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.Extract;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Extract
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
                .ForMember(dest => dest.SchoolFK, opt => opt.Ignore()) //.ForMember(dest => dest.SchoolFK, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.TotalRoll, opt => opt.MapFrom(s => s.TotalRoll))
                .ForMember(dest => dest.SourceReferenceId, opt => opt.MapFrom(s => s.EnrolId))
                ;
        }
    }
}
