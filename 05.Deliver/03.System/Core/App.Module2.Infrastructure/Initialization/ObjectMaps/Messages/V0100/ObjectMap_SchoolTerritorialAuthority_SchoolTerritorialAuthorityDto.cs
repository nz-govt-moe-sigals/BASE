﻿namespace App.Module2.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
    using App.Module2.Shared.Models.Entities;
    using App.Module2.Shared.Models.Messages.V0100;

    public class ObjectMap_SchoolTerritorialAuthority_SchoolTerritorialAuthorityDto
        : ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto
            <SchoolTerritorialAuthorityWithAucklandLocalBoard, SchoolTerritorialAuthorityWithAucklandLocalBoardDto>
    {
    }
}