using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module3.Shared.Models.Entities;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Formated;
using AutoMapper;

namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Formatted
{
    public class ObjectMap_EducationProvider_SifProviderDto
      : IHasAutomapperInitializer

    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderProfile, SifProviderDto>()
                .ForMember(x => x.RefId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.LocalId, opt => opt.MapFrom(src => src.SchoolId))
                .ForMember(x => x.Authority, opt => opt.Ignore())
                .ForMember(x => x.Organisation, opt => opt.Ignore())
                .ForMember(x => x.SchoolService, opt => opt.Ignore())
                ;


        }
    }
}
