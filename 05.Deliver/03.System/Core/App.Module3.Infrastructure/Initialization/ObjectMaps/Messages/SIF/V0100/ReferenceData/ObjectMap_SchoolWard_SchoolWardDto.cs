namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.ReferenceData
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    /// <summary>
    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    public class ObjectMap_SchoolWard_SchoolWardDto
        : ObjectMap_TenantedFIRSTKeyedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <Ward, WardDto>
    {
    }
}