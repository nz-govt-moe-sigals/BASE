namespace App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.ReferenceData
{
    using App.Core.Infrastructure.Initialization.ObjectMaps;
    using App.Module31.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base;
    using App.Module31.Shared.Models.Entities;
    using App.Module31.Shared.Models.Messages.API.MOE.V0100;
    using App.Module31.Shared.Models.Messages.API.SIF.V0100;

    /// <summary>
    /// An outward (Entity -> DTO) map.
    /// <para>
    /// Note that the ObjectMap implements <see cref="IHasAutomapperInitializer"/>
    /// in order to be auto discoverable/registerable at startup.
    /// </para>
    /// </summary>
    /// <seealso cref="EducationProviderSchoolingGenderTypeDto" />
    public class ObjectMap_EdProviderSchoolingGender_EdProviderSchoolingGenderDto
        : ObjectMap_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <EducationProviderGender, EducationProviderSchoolingGenderDto>
    {
    }
}




