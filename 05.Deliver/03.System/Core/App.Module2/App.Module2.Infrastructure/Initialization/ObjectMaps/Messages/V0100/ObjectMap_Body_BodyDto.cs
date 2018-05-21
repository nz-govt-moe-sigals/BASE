namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;
    using AutoMapper;

    public class ObjectMap_Body_BodyDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Body, BodyDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                //.ForMember(t => t.BodyFK, opt => opt.MapFrom(s => s.))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Category, opt => opt.MapFrom(s => s.Category))
                .ForMember(t => t.Location, opt => opt.MapFrom(s => s.Location))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Prefix, opt => opt.MapFrom(s => s.Prefix))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.GivenName, opt => opt.MapFrom(s => s.GivenName))
                .ForMember(t => t.MiddleNames, opt => opt.MapFrom(s => s.MiddleNames))
                .ForMember(t => t.SurName, opt => opt.MapFrom(s => s.SurName))
                .ForMember(t => t.Suffix, opt => opt.MapFrom(s => s.Suffix))
                //Map Children
                .ForMember(t => t.Names, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Aliases); })
                .ForMember(t => t.Channels, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Channels);})
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties);})
                .ForMember(t => t.Claims, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Claims);})
                ;
        }
    }
}