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
            config.CreateMap<Principal, PrincipalDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Category, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Category); })
                .ForMember(t => t.Tags, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Tags); })
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties);})
                .ForMember(t => t.Claims, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Claims);})
                ;
        }
    }
}