namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;
    using AutoMapper;

    public class ObjectMap_BodyLocation_BodyLocationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BodyLocation, BodyLocationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Latitude, opt => opt.MapFrom(s => s.Latitude))
                .ForMember(t => t.Longitude, opt => opt.MapFrom(s => s.Longitude))
                ;
        }
    }
}