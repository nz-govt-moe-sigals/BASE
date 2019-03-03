using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_PrincipalTag_PrincipalTagDto
        : MapUntenantedAuditedRecordStateBase<PrincipalTagDto, PrincipalTag>,
            IHasAutomapperInitializer
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_PrincipalTag_PrincipalTagDto(config);
            Map_PrincipalTagDto_PrincipalTag(config);
        }

        public void Map_PrincipalTag_PrincipalTagDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<PrincipalTag, PrincipalTagDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
        }

        public void Map_PrincipalTagDto_PrincipalTag(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<PrincipalTagDto, PrincipalTag>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Title, opt => { opt.MapFrom(s => s.Text); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
            MapBase(mappingExpression);
        }
    }
}