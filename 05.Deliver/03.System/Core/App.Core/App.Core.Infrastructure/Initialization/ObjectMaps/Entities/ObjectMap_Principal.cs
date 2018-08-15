using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Entities
{
    public class ObjectMap_Principal : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mapping = config.CreateMap<Principal, Principal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryFK, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.DataClassificationFK, opt => opt.Ignore())
                .ForMember(dest => dest.DataClassification, opt => opt.Ignore());
            MapCollections(mapping);
            mapping
                .ForAllOtherMembers(opt => opt.Condition((src, dest, srcVal, destVal, c) => srcVal != null));
        }

        private void MapCollections(IMappingExpression<Principal, Principal> mappingExpression)
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
