namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Session_SessionDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Session, SessionDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.StartDateTimeUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                .ForMember(t => t.Operations, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Operations);})
                ;
        }
    }
}