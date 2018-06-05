using App.Core.Infrastructure.Initialization.ObjectMaps;
using App.Module32.Shared.Models.Entities;
using App.Module32.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Module32.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    public class ObjectMap_Example_ExampleDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Example, ExampleDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.PublicText, opt => opt.MapFrom(s => s.PublicText))
                .ForMember(t => t.SensitiveText, opt => opt.MapFrom(s => s.SensitiveText))
                //Note how PrivateText and Owner Id never leave the app via an API...
                ;
        }
    }
}