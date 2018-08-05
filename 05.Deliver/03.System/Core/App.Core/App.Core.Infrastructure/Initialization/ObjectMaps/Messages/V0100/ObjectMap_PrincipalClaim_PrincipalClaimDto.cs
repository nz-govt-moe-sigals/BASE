using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_PrincipalClaim_PrincipalClaimDto
        : MapUntenantedAuditedRecordStateBase<PrincipalClaimDto, PrincipalClaim>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_PrincipalClaim_PrincipalClaimDto(config);
            Map_PrincipalClaimDto_PrincipalClaim(config);
        }

        public void Map_PrincipalClaim_PrincipalClaimDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<PrincipalClaim, PrincipalClaimDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.AuthorityKey, opt => opt.MapFrom(s => s.Authority))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(t => t.Signature, opt => opt.MapFrom(s => s.AuthoritySignature))
                ;
        }

        public void Map_PrincipalClaimDto_PrincipalClaim(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<PrincipalClaimDto, PrincipalClaim>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.Authority, opt => opt.MapFrom(s => s.AuthorityKey))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(t => t.AuthoritySignature, opt => opt.MapFrom(s => s.Signature))
                ;
            MapBase(mappingExpression);
        }
    }
}