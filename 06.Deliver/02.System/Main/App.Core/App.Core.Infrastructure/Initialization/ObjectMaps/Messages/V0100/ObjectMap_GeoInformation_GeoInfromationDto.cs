using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.ConfigurationSettings;
using App.Core.Shared.Models.Messages;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    public class ObjectMap_GeoInformation_GeoInfromationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<GeoInformationCountryRegion, GeoInformationCountryRegionDto>()
                .ForMember(t => t.IsoCode, opt => opt.MapFrom(s => s.IsoCode))
                ;

            config.CreateMap<GeoInformation, GeoInformationDto>()
                .ForMember(t => t.CountryRegion, opt => opt.MapFrom(s => s.CountryRegion))
                .ForMember(t => t.IPAddress, opt => opt.MapFrom(s => s.IPAddress))
                ;
        }
    }
}
