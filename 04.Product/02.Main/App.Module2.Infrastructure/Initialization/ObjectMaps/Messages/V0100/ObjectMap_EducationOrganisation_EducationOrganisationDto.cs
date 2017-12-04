namespace App.Module2.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module2.Shared.Models.Entities;
    using AutoMapper;

    public class ObjectMap_EducationOrganisation_EducationOrganisationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<EducationOrganisation, EducationOrganisationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Principal, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Principal);})
                .ForMember(t => t.Organisation, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Organisation);})
                .ForMember(t => t.Note, opt => opt.MapFrom(s => s.Note))
                ;
        }
    }
}