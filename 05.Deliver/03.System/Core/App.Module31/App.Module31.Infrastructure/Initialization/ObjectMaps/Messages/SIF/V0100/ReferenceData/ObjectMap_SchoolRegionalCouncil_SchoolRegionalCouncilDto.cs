namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.ReferenceData
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base;
    using App.Module31.Shared.Models.Entities;
    using App.Module31.Shared.Models.Messages.APIs.SIF.V0100;

    /// <summary>
    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    /// <seealso cref="RegionalCouncilDto" />
    public class ObjectMap_SchoolRegionalCouncil_SchoolRegionalCouncilDto
        : ObjectMap_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <RegionalCouncil, RegionalCouncilDto>
    {
    }
}




