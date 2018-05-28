namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_NavigationRoute_NavigationRouteDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<NavigationRoute, NavigationRouteDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                .ForMember(t => t.Chilldren, opt => opt.MapFrom(s => s.Chilldren))
                ;
        }
    }
}