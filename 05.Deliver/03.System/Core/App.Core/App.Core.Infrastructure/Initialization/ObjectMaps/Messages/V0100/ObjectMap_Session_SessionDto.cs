using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Session_SessionDto
        : MapUntenantedAuditedRecordStateBase<SessionDto, Session>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_Session_SessionDto(config);
            Map_SessionDto_Session(config);
        }

        public void Map_Session_SessionDto(IMapperConfigurationExpression config)
        {
            var x = config.CreateMap<Session, SessionDto>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.StartDateTimeUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Operations); })
                    
                ;
        }

        public void Map_SessionDto_Session(IMapperConfigurationExpression config)
        {
            var x = config.CreateMap<SessionDto, Session>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.CreatedOnUtc, opt => opt.MapFrom(s => s.StartDateTimeUtc))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => opt.Ignore())
                    .ForMember(t => t.PrincipalFK, opt => opt.Ignore())
                    .ForMember(t => t.UniqueIdentifier, opt => opt.Ignore())
                ;
            MapBase(x);
        }

    }
}