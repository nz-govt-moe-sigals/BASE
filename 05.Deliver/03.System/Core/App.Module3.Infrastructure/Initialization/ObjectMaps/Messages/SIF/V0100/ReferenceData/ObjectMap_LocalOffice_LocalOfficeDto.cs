namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.ReferenceData
{
    using App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.APIs.SIF.V0100;

    public class ObjectMap_LocalOffice_LocalOfficeDto
        : ObjectMap_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <LocalOffice, LocalOfficeDto>
    {
    }
}