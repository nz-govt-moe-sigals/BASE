using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_PrincipalProperty_PrincipalPropertyDto
        : MapUntenantedAuditedRecordStateBase<PrincipalPropertyDto, PrincipalProperty>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_PrincipalProperty_PrincipalPropertyDto(config);
            Map_PrincipalPropertyDto_PrincipalProperty(config);
        }

        public void Map_PrincipalProperty_PrincipalPropertyDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<PrincipalProperty, PrincipalPropertyDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
        }

        public void Map_PrincipalPropertyDto_PrincipalProperty(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<PrincipalPropertyDto, PrincipalProperty>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                    .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
            MapBase(mappingExpression);
        }
    }
}