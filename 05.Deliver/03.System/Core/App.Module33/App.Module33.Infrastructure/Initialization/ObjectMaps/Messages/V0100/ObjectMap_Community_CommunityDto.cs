using App.Module33.Shared.Models.Messages.API.V0100;

namespace App.Module33.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module33.Shared.Models.Entities;
    using AutoMapper;

    public class ObjectMap_Community_CommunityDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Community, CommunityDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.PublicText, opt => opt.MapFrom(s => s.PublicText))
                .ForMember(t => t.SensitiveText, opt => opt.MapFrom(s => s.SensitiveText))
                //Note how PrivateText and Owner Id never leave the app via an API...
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.ColourScheme, opt => opt.MapFrom(s => s.ColourScheme))
                .ForMember(t => t.Strategy, opt => opt.MapFrom(s => s.Strategy))
                ;
        }
    }
}