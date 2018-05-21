namespace App.Module02.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
    using App.Module02.Shared.Models.Entities;
    using App.Module02.Shared.Models.Messages.V0100;

    public class ObjectMap_SchoolDefinition_SchoolDefinitionDto

        : ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto
            <SchoolDefinition, SchoolDefinitionDto>
    {
    }
}