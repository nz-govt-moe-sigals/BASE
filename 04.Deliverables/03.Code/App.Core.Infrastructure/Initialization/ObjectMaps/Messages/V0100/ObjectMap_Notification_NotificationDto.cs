namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    public class ObjectMap_Notification_NotificationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<Notification, NotificationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.DateTimeReadUtc, opt => opt.MapFrom(s => s.DateTimeReadUtc))
                .ForMember(t => t.From, opt => opt.MapFrom(s => s.From))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                // If not provided IsRead,Class,ImageUrl can be PostProcessed 
                // and inferred from Type and DateTimeReadUtc
                .ForMember(x=>x.IsRead, opt=>opt.Ignore())
                .ForMember(t => t.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(t => t.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                ;
        }
    }
}