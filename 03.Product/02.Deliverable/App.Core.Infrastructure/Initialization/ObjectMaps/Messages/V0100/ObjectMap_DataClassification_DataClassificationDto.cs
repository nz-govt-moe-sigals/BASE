namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    public class ObjectMap_DataClassification_DataClassificationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<DataClassification, DataClassificationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                ;
        }
    }
}