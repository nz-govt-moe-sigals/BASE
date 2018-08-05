using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_TenantedNavigationRoute_TenantedNavigationRouteDto
        : MapUntenantedAuditedRecordStateBase<TenantedNavigationRouteDto, TenantedNavigationRoute>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_TenantedNavigationRoute_TenantedNavigationRouteDto(config);
            Map_TenantedNavigationRouteDto_TenantedNavigationRoute(config);
        }

        public void Map_TenantedNavigationRoute_TenantedNavigationRouteDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<TenantedNavigationRoute, TenantedNavigationRouteDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                .ForMember(t => t.Chilldren, opt => opt.MapFrom(s => s.Chilldren))
                ;
        }

        public void Map_TenantedNavigationRouteDto_TenantedNavigationRoute(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<TenantedNavigationRouteDto, TenantedNavigationRoute>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Text))
                    .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                    .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                    .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                    .ForMember(t => t.Chilldren, opt => opt.MapFrom(s => s.Chilldren))
                    .ForMember(t => t.OwnerFK, opt => opt.Ignore())
                    .ForMember(t => t.TenantFK, opt => opt.Ignore())
                ;
            MapBase(mappingExpression);
        }
    }
}