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
    public class ObjectMap_PrincipalLogin_PrincipalLoginDto
        : MapUntenantedAuditedRecordStateBase<PrincipalLoginDto, PrincipalLogin>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_PrincipalLoginDto_PrincipalLogin(config);
            Map_PrincipalLogin_PrincipalLoginDto(config);
        }

        public void Map_PrincipalLogin_PrincipalLoginDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<PrincipalLogin, PrincipalLoginDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled , opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.IdPLogin, opt => opt.MapFrom(s => s.IdPLogin))
                .ForMember(t => t.SubLogin, opt => opt.MapFrom(s => s.SubLogin))
                .ForMember(t => t.LastLoggedInUtc, opt => opt.MapFrom(s => s.LastLoggedInUtc))
                ;
        }

        public void Map_PrincipalLoginDto_PrincipalLogin(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<PrincipalLoginDto, PrincipalLogin>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                    .ForMember(t => t.IdPLogin, opt => opt.MapFrom(s => s.IdPLogin))
                    .ForMember(t => t.SubLogin, opt => opt.MapFrom(s => s.SubLogin))
                    .ForMember(t => t.LastLoggedInUtc, opt => opt.MapFrom(s => s.LastLoggedInUtc))
                ;
            MapBase(mappingExpression);
        }

    }
}
