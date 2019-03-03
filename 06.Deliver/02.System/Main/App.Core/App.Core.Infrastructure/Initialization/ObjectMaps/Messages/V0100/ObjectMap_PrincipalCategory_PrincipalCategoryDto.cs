using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_PrincipalCategory_PrincipalCategoryDto
        : MapUntenantedAuditedRecordStateBase<PrincipalCategoryDto, PrincipalCategory>,
            IHasAutomapperInitializer
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_PrincipalCategory_PrincipalCategoryDto(config);
            Map_PrincipalCategoryDto_PrincipalCategory(config);
        }

        public void Map_PrincipalCategory_PrincipalCategoryDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<PrincipalCategory, PrincipalCategoryDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
        }

        public void Map_PrincipalCategoryDto_PrincipalCategory(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<PrincipalCategoryDto, PrincipalCategory>()
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