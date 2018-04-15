namespace App.Module3.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;
    using App.Module3.Shared.Models.Entities;
    using App.Module3.Shared.Models.Messages.V0100;

    public class ObjectMap_SchoolCommunityBoard_SchoolCommunityBoardDto
        : ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto
            <CommunityBoard, CommunityBoardDto>
    {
    }
}