namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    public abstract class ObjectMap_EducationProviderLocation_EducationProviderLocationDto
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderLocation, EducationProviderLocationDto>()
                .ForMember(t => t.Id, opt=>opt.MapFrom(s=>s.Id))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Longitude, opt => opt.MapFrom(s => s.Longitude))
                .ForMember(t => t.Latitude, opt => opt.MapFrom(s => s.Latitude))
                .ForMember(t => t.Altitude, opt => opt.MapFrom(s => s.Altitude))
                ;

        }
    }
}