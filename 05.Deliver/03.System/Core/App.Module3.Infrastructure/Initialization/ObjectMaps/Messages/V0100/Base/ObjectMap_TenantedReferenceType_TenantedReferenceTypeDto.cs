﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base
{
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.V0100;
    using AutoMapper;

    /// <summary>
    /// A Base class for 
    /// an outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="App.Core.Infrastructure.Initialization.ObjectMaps.IHasAutomapperInitializer" />
    public abstract class ObjectMap_TenantedFIRSTSIFKeyedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto<T,TDto> 
        : IHasAutomapperInitializer
        where T : TenantedFIRSTSIFKeyedGuidIdReferenceDataBase
        where TDto: TenantedSIFReferenceDtoBase
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<T, TDto>()
                // IMPORTANT: Note that we are mapping from SIF to Id.
                // Hopefully Automapper's Project method can handle this magic...
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.SIFKey))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                ;
        }

    }
}