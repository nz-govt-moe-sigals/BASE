

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;
    public class ObjectMap_SessionOperation_SessionOperationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<SessionOperation, SessionOperationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.BeginDateTimeUtc, opt => opt.MapFrom(s => s.BeginDateTimeUtc))
                .ForMember(t => t.EndDateTimeUtc, opt => opt.MapFrom(s => s.EndDateTimeUtc))
                .ForMember(t => t.Duration, opt => opt.MapFrom(s => s.Duration))
                .ForMember(t => t.ClientIp, opt => opt.MapFrom(s => s.ClientIp))
                .ForMember(t => t.Url, opt => opt.MapFrom(s => s.Url))
                .ForMember(t => t.ActionName, opt => opt.MapFrom(s => s.ActionName))
                .ForMember(t => t.ActionArguments, opt => opt.MapFrom(s => s.ActionArguments))
                .ForMember(t => t.ControllerName, opt => opt.MapFrom(s => s.ControllerName))
                .ForMember(t => t.ResponseCode, opt => opt.MapFrom(s => s.ResponseCode))
                //Relationships
                ;
        }
    }
}


