namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    public class ObjectMap_ExceptionRecord_ExceptionRecordDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ExceptionRecord, ExceptionRecordDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(t => t.Title, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Stack, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Stack); })
                ;
        }
    }
}