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
    public class ObjectMap_SchoolWGS_EducationProviderLocation : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SchoolWGS, EducationProviderLocation>()
                .ForMember(dest => dest.Altitude, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.UseValue(Shared.Models.Enums.LocationType.WGS))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(s => s.WgsX))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(s => s.WgsY))
                .ForMember(dest => dest.EducationProviderFK, opt => opt.Ignore()) // .ForMember(dest => dest.EducationProviderFK, opt => opt.MapFrom(s => s.InstitutionNumber))
                .ForMember(dest => dest.SourceReferenceId, opt => opt.MapFrom(s => s.WgsId))
                ;
        }
    }
}
