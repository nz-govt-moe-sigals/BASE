using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Core.Shared.Models.Configuration;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Configuration;
    using App.Core.Shared.Models.Configuration.AppHost;
    using App.Core.Shared.Models.ConfigurationSettings;
    using App.Core.Shared.Models.Messages;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_ApplicationDescription_ApplicationDescriptionDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ApplicationDescriptionConfigurationSettings, ApplicationDescriptionDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))

                // TODO: Find a way to map these across
                .ForMember(t=>t.Creator, opt => opt.Ignore())
                .ForMember(t => t.Description, opt => opt.Ignore())
                .ForMember(t=> t.Distributor, opt=>opt.Ignore())


                ;
        }

    }
}