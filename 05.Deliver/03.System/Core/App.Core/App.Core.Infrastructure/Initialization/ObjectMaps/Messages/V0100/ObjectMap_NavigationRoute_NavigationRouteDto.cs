using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
using App.Core.Shared.Models.Entities.TenancySpecific;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_NavigationRoute_NavigationRouteDto
        : MapUntenantedAuditedRecordStateBase<NavigationRouteDto, NavigationRoute>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_NavigationRoute_NavigationRouteDto(config);
            Map_NavigationRouteDto_NavigationRoute(config);
        }

        public void Map_NavigationRoute_NavigationRouteDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<NavigationRoute, NavigationRouteDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                .ForMember(t => t.Chilldren, opt => opt.MapFrom(s => s.Chilldren))
                ;
        }

        public void Map_NavigationRouteDto_NavigationRoute(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<NavigationRouteDto, NavigationRoute>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                .ForMember(t => t.Chilldren, opt => opt.MapFrom(s => s.Chilldren))
                ;
            MapBase(mappingExpression);
        }
    }
}