using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_SystemRole_RoleDto
        : MapUntenantedAuditedRecordStateBase<RoleDto, SystemRole>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_SystemRole_RoleDto(config);
            Map_RoleDto_SystemRole(config);
        }

        public void Map_SystemRole_RoleDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<SystemRole, RoleDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.ModuleKey,  opt => opt.MapFrom(s => s.ModuleKey))
                ;
        }

        public void Map_RoleDto_SystemRole(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<RoleDto, SystemRole>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.DataClassification, opt => { opt.MapFrom(s => s.DataClassification); })
                    .ForMember(t => t.ModuleKey, opt => opt.MapFrom(s => s.ModuleKey))
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            MapBase(mappingExpression);
        }
    }
}