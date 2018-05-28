namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_ConfigurationStepRecord_ConfigurationStepRecordDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ConfigurationStepRecord, ConfigurationStepRecordDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                ;
        }
    }
}