using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_TenantProperty_TenantPropertyDto
        : MapUntenantedAuditedRecordStateBase<TenantPropertyDto, TenantProperty>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_TenantProperty_TenantPropertyDto(config);
            Map_TenantPropertyDto_TenantProperty(config);
        }

        public void Map_TenantProperty_TenantPropertyDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<TenantProperty, TenantPropertyDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
        }

        public void Map_TenantPropertyDto_TenantProperty(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<TenantPropertyDto, TenantProperty>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
            MapBase(mappingExpression);
        }
    }
}