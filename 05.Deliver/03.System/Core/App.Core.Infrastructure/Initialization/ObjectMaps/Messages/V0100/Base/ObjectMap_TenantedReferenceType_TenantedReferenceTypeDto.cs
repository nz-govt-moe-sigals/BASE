using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base
{
    using App.Core.Shared.Models.Entities.Base;
    using App.Core.Shared.Models.Messages.BaseClasses;
    using AutoMapper;

    public abstract class ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto<T,TDto> 
        : IHasAutomapperInitializer
        where T : TenantedGuidIdReferenceDataBase
        where TDto: TenantedReferenceDtoBase
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<T, TDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                ;
        }

    }
}