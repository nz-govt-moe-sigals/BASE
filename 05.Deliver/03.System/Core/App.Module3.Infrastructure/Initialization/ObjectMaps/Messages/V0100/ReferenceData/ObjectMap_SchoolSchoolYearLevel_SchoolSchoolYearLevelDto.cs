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
    /// <seealso cref="App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base.ObjectMap_TenantedFIRSTSIFKeyedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto{App.Module3.Shared.Models.Entities.EducationProviderYearLevel, App.Module3.Shared.Models.Messages.V0100.EducationProviderYearLevelDto}" />
    public class ObjectMap_SchoolSchoolYearLevel_SchoolSchoolYearLevelDto
        : ObjectMap_TenantedFIRSTSIFKeyedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <EducationProviderYearLevel, EducationProviderYearLevelDto>
    {
    }
}