using System.Security.Cryptography.X509Certificates;
using App.Module33.Shared.Models.Messages.API.V0100;

namespace App.Module33.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization;
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Shared.Models.Messages.API.V0100;
    using App.Module33.Shared.Models.Entities;
    using AutoMapper;

    public class ObjectMap_CommunityDto_Community : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mappingExpression =  config.CreateMap<CommunityDto, Community>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.PublicText, opt => opt.MapFrom(s => s.PublicText))
                .ForMember(t => t.SensitiveText, opt => opt.MapFrom(s => s.SensitiveText))
                .ForMember(t => t.Owner, opt => opt.Ignore())
                .ForMember(t => t.AppPrivateText, opt => opt.Ignore())
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.ColourSchemeFK, opt => opt.Ignore())
                .ForMember(t => t.ColourScheme, opt => opt.MapFrom(s => s.ColourScheme))
                .ForMember(t => t.Strategy, opt => opt.MapFrom(s => s.Strategy))
                .ForMember(t => t.CoherentPathways, opt => opt.MapFrom(x => x.CoherentPathways))
                ;
            MapBaseTenancy(mappingExpression);
        }

        private void MapBaseTenancy(IMappingExpression<CommunityDto, Community> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Timestamp, opt => opt.Ignore())
                .ForMember(t => t.RecordState, opt => opt.Ignore())
                .ForMember(t => t.CreatedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.CreatedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.LastModifiedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.LastModifiedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.DeletedByPrincipalId, opt => opt.Ignore())
                .ForMember(t => t.DeletedOnUtc, opt => opt.Ignore())
                .ForMember(t => t.TenantFK, opt => opt.Ignore());
        }
    }
}