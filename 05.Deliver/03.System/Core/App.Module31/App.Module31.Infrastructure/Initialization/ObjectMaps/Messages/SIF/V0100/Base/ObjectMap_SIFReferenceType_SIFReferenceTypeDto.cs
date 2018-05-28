namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module31.Shared.Models.Entities;
    using App.Module31.Shared.Models.Messages.API.SIF.V0100.Base;
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
    public abstract class ObjectMap_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto<T,TDto> 
        : IHasAutomapperInitializer
        where T : SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase
        where TDto: SIFReferenceDtoBase
    {

        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<T, TDto>()
                // IMPORTANT: Note that we are mapping from SIF to Id.
                // Hopefully Automapper's Project method can handle this magic...
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.SIFKey))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                ;
        }

    }
}




