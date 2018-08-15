using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Entities
{
    public class ObjectMap_Principal : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Principal, Principal>()
            .ForMember(dest => dest.Id, opt => opt.UseDestinationValue())
            .ForAllOtherMembers(opt => opt.Condition((src, dest, srcVal, destVal, c) => srcVal != null));
        }

    }
}
