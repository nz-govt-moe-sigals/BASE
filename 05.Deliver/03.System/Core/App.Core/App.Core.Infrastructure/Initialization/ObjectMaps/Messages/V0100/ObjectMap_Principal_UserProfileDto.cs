using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
using App.Core.Shared.Models.Entities;
using App.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    public class ObjectMap_Principal_UserProfileDto
        : MapUntenantedAuditedRecordStateBase<UserProfileDto, Principal>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_Principal_UserProfileDto(config);
            Map_UserProfileDto_Principal(config);
        }

        public void Map_Principal_UserProfileDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<Principal, UserProfileDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                ;
        }

        public void Map_UserProfileDto_Principal(IMapperConfigurationExpression config)
        {
            var x = config.CreateMap<UserProfileDto, Principal>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.Ignore())
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                    .ForMember(t => t.EnabledBeginningUtc, opt => opt.Ignore())
                    .ForMember(t => t.EnabledEndingUtc, opt => opt.Ignore())
                    .ForMember(t => t.DataClassification, opt => opt.Ignore())
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                    .ForMember(t => t.Category, opt => opt.Ignore())
                    .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                ;
            MapBase(x);
            MapCollections(x);
        }

        private void MapCollections(IMappingExpression<UserProfileDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Logins, opt => opt.Ignore())
                .ForMember(t => t.Roles, opt => opt.Ignore())
                .ForMember(t => t.Tags, opt => opt.Ignore())
                .ForMember(t => t.Properties, opt => opt.Ignore())
                .ForMember(t => t.Claims, opt => opt.Ignore());
        }
    }
}
