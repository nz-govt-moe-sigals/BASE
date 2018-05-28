using App.Module02.Shared.Models.Entities;

namespace App.Module02.Shared.Models.Messages.API.V0100
{
    public class AccountAccountPermissionAssignmentDto
    {
        public AccountPermissionDto Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}
