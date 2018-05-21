namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;
    using AutoMapper;

    public class ObjectMap_BodyClaim_BodyClaimDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BodyClaim, BodyClaimDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.BodyFK, opt => opt.MapFrom(s => s.OwnerFK))
                .ForMember(t => t.AuthorityKey, opt => opt.MapFrom(s => s.Authority))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(t => t.Signature, opt => opt.MapFrom(s => s.AuthoritySignature))
                ;
        }
    }
}