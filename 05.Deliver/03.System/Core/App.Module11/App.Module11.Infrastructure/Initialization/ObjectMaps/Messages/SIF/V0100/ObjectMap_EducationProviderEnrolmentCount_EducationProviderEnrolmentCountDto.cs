namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module11.Shared.Models.Entities;
    using App.Module11.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    public class ObjectMap_EducationProviderEnrolmentCount_EducationProviderEnrolmentCountDto
        : IHasAutomapperInitializer

    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationProviderEnrolmentCount, EducationProviderEnrolmentCountDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Date, opt => opt.MapFrom(s => s.Date))
                .ForMember(t => t.TotalRoll, opt => opt.MapFrom(s => s.TotalRoll))
                .ForMember(t => t.Asian, opt => opt.MapFrom(s => s.Asian))
                .ForMember(t => t.European, opt => opt.MapFrom(s => s.European))
                .ForMember(t => t.International, opt => opt.MapFrom(s => s.International))
                .ForMember(t => t.MELAA, opt => opt.MapFrom(s => s.MELAA))
                .ForMember(t => t.Maori, opt => opt.MapFrom(s => s.Maori))
                .ForMember(t => t.Other, opt => opt.MapFrom(s => s.Other))
                .ForMember(t => t.Pasifika, opt => opt.MapFrom(s => s.Pasifika))
                ;

        }
    }
}