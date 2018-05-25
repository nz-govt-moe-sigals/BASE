namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module02.Shared.Models.Entities;
    using AutoMapper;

    public class ObjectMap_ExampleDto_Example : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            //config.CreateMap<ExampleDto, Example>()
            //    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
            //    .ForMember(t => t.Timestamp, opt => opt.Ignore())
            //    .ForMember(t => t.RecordState, opt => opt.Ignore())
            //    .ForMember(t => t.CreatedOnUtc, opt => opt.Ignore())
            //    .ForMember(t => t.CreatedByPrincipalId, opt => opt.Ignore())
            //    .ForMember(t => t.LastModifiedByPrincipalId, opt => opt.Ignore())
            //    .ForMember(t => t.LastModifiedOnUtc, opt => opt.Ignore())
            //    .ForMember(t => t.DeletedByPrincipalId, opt => opt.Ignore())
            //    .ForMember(t => t.DeletedOnUtc, opt => opt.Ignore())
            //    .ForMember(t => t.TenantFK, opt => opt.Ignore())
            //    .ForMember(t => t.PublicText, opt => opt.MapFrom(s => s.PublicText))
            //    .ForMember(t => t.SensitiveText, opt => opt.MapFrom(s => s.SensitiveText))
            //    .ForMember(t => t.Owner, opt => opt.Ignore())
            //    .ForMember(t => t.AppPrivateText, opt => opt.Ignore())
            //    ;
        }
    }
}