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
    public class ObjectMap_SchoolLevelGender_EducationProviderLevelGender : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SchoolLevelGender, EducationProviderLevelGender>()
                
                .ForMember(dest => dest.YearFK, opt => opt.Ignore()) //.ForMember(dest => dest.YearFK, opt => opt.MapFrom(s => s.YearValueId))          
                .ForMember(dest => dest.Year, opt => opt.Ignore()) 
                .ForMember(dest => dest.GenderFK, opt => opt.Ignore()) //.ForMember(dest => dest.GenderFK, opt => opt.MapFrom(s => s.GenderValueId))    
                .ForMember(dest => dest.Gender, opt => opt.Ignore()) //.ForMember(dest => dest.GenderFK, opt => opt.MapFrom(s => s.GenderValueId))    
                .ForMember(dest => dest.EducationProviderFK, opt => opt.Ignore()) //.ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.SchoolId))
                .ForMember(dest => dest.SourceReferenceId, opt => opt.MapFrom(s => s.LevelGenderId))

                //
                ;
        }
    }
}
