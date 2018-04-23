﻿namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100.Base;
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
        where T : TenantedSourceKeySIFKeyedGuidIdReferenceDataBase
        where TDto: TenantedSIFReferenceDtoBase
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<T, TDto>()
                // IMPORTANT: Note that we are mapping from SIF to Id.
                // Hopefully Automapper's Project method can handle this magic...
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.SIFKey))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                ;
        }

    }
}