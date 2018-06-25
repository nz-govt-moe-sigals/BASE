namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Tenant_TenantDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Tenant, TenantDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t=> t.HostName, opt => opt.MapFrom(s=> s.HostName))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties);})
                .ForMember(t => t.Claims, opt => { opt.MapFrom(s => s.Claims); opt.ExplicitExpansion(); })
                ;
        }
    }
}