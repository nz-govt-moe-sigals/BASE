namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.V0100;

    /// <summary>
    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    /// <seealso cref="GeneralElectorateDto" />
    public class ObjectMap_SchoolGeneralElectorate_SchoolGeneralElectorateDto
        : ObjectMap_TenantedFIRSTSIFKeyedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <GeneralElectorate, GeneralElectorateDto>
    {
    }
}