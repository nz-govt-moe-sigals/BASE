using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Notification_NotificationDto
        : MapUntenantedAuditedRecordStateBase<NotificationDto, Notification>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_NotificationDto_Notification(config);
            Map_Notification_NotificationDto(config);
        }

        public void Map_Notification_NotificationDto(IMapperConfigurationExpression config)
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
                .ForMember(x => x.IsRead, opt => opt.Ignore())
                .ForMember(t => t.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(t => t.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                ;
        }

        public void Map_NotificationDto_Notification(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<NotificationDto, Notification>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(x => x.IsRead, opt => opt.MapFrom(s => s.IsRead))
                .ForMember(t => t.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(t => t.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(t => t.PrincipalFK, opt => opt.Ignore())
                ;
            MapAttributes(mappingExpression);
            MapBase(mappingExpression);
        }

        private void MapAttributes(IMappingExpression<NotificationDto, Notification> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.DateTimeReadUtc, opt => opt.MapFrom(s => s.DateTimeReadUtc))
                .ForMember(t => t.From, opt => opt.MapFrom(s => s.From))
                ;
        }
    }
}