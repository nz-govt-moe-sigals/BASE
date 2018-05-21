namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;
    using AutoMapper;

    public class ObjectMap_BodyAlias_BodyAliasDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BodyAlias, BodyAliasDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.BodyFK, opt => opt.MapFrom(s => s.OwnerFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Prefix, opt => opt.MapFrom(s => s.Prefix))
                .ForMember(t => t.FirstName, opt => opt.MapFrom(s => s.GivenName))
                .ForMember(t => t.MiddleName, opt => opt.MapFrom(s => s.MiddleNames))
                .ForMember(t => t.LastName, opt => opt.MapFrom(s => s.SurName))
                .ForMember(t => t.Suffix, opt => opt.MapFrom(s => s.Suffix))
                ;
        }
    }
}