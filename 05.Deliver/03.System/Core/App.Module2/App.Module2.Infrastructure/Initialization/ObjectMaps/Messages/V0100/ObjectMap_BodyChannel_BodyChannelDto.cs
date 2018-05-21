namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;
    using AutoMapper;

    public class ObjectMap_BodyChannel_BodyChannelDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<BodyChannel, BodyChannelDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.BodyFK, opt => opt.Ignore())
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.Protocol, opt => opt.MapFrom(s => s.Protocol))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(t => t.AddressStreetAndNumber, opt => opt.MapFrom(s => s.AddressStreetAndNumber))
                .ForMember(t => t.AddressSuburb, opt => opt.MapFrom(s => s.AddressSuburb))
                .ForMember(t => t.AddressCity, opt => opt.MapFrom(s => s.AddressCity))
                .ForMember(t => t.AddressRegion, opt => opt.MapFrom(s => s.AddressRegion))
                .ForMember(t => t.AddressState, opt => opt.MapFrom(s => s.AddressState))
                .ForMember(t => t.AddressCountry, opt => opt.MapFrom(s => s.AddressCountry))
                .ForMember(t => t.AddressPostalCode, opt => opt.MapFrom(s => s.AddressPostalCode))
                .ForMember(t => t.AddressInstructions, opt => opt.MapFrom(s => s.AddressInstructions))
                ;
        }
    }
}