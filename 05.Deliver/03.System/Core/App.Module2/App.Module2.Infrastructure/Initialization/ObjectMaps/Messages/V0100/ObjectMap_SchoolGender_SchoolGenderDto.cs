namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;

    public class ObjectMap_SchoolGender_SchoolGenderDto
        : ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto
            <SchoolGender, SchoolGenderDto>
    {
    }
}