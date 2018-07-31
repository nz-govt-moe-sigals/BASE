namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Principal_PrincipalDto : IHasAutomapperInitializer
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
            //TODO:
            var x = config.CreateMap<PrincipalDto, Principal>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.DataClassification, opt => opt.Ignore())
                    .ForMember(t => t.Category, opt => opt.Ignore())
                    .ForMember(t => t.Tags, opt => opt.Ignore())
                    .ForMember(t => t.Properties, opt => opt.Ignore())
                    .ForMember(t => t.Claims, opt => opt.Ignore())
                    .ForMember(t => t.EnabledBeginningUtc, opt => opt.Ignore())
                    .ForMember(t => t.EnabledEndingUtc, opt => opt.Ignore())
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                    .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                    .ForMember(t => t.Logins, opt => opt.Ignore())
                    .ForMember(t => t.Roles, opt => opt.Ignore())
                ;
            Mapbase(x);
        }

        private void Mapbase(IMappingExpression<PrincipalDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }
}