namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;
    using AutoMapper;

    /// <summary>
    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Core.Infrastructure.Initialization.ObjectMaps.IHasAutomapperInitializer" />
    public class ObjectMap_EducationProviderLocation_EducationProviderLocationDto
        : IHasAutomapperInitializer
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