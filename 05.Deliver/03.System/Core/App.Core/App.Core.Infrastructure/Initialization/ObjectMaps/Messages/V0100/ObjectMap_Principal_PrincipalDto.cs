using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Principal_PrincipalDto 
        : MapUntenantedAuditedRecordStateBase<PrincipalDto, Principal>,
        IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_Principal_PrincipalDto(config);
            Map_PrincipalDto_Principal(config);
        }

        public void Map_Principal_PrincipalDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<Principal, PrincipalDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Category, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Category); })
                .ForMember(t => t.Tags, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Tags); })
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties); })
                .ForMember(t => t.Claims, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Claims); })
                ;
        }

        public void Map_PrincipalDto_Principal(IMapperConfigurationExpression config)
        {
            var x = config.CreateMap<PrincipalDto, Principal>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                    .ForMember(t => t.EnabledBeginningUtc, opt => opt.Ignore())
                    .ForMember(t => t.EnabledEndingUtc, opt => opt.Ignore())
                    .ForMember(t => t.DataClassification, opt => opt.Ignore())
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                    .ForMember(t => t.Category, opt => opt.Ignore())
                    .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                ;
            MapBase(x);
            MapCollections(x);
        }

        private void MapCollections(IMappingExpression<PrincipalDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Logins, opt => opt.MapFrom(s => s.Logins))
                .ForMember(t => t.Roles, opt => opt.MapFrom(s => s.Roles))
                .ForMember(t => t.Tags, opt => opt.MapFrom(s => s.Tags))
                .ForMember(t => t.Properties, opt => opt.MapFrom(s => s.Properties))
                .ForMember(t => t.Claims, opt => opt.MapFrom(s => s.Claims));
        }

    }
}