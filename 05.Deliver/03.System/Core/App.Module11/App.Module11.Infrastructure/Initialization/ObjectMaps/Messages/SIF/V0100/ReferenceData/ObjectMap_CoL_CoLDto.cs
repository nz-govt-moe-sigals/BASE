namespace App.Module11.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.ReferenceData
{
    using App.Module11.Infrastructure.Initialization.ObjectMaps.Messages.SIF.V0100.Base;
    using App.Module11.Shared.Models.Entities;
    using App.Module11.Shared.Models.Messages.APIs.SIF.V0100;

    public class ObjectMap_CoL_CoLDto
        : ObjectMap_SIFSourceSystemKeyedTenantedGuidIdReferenceDataBase_TenantedSIFReferenceTypeDto
            <CoL, CoLDto>
    {
    }
}