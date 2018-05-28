using App.Core.Shared.Factories;
using App.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module02.Shared.Models.Messages.API.V0100
{
    public class AccountDto : IHasGuidId
    {
        public AccountDto()
        {
            GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }

        public string Key { get; set; }

        public ICollection<AccountRoleGroupDto> AccountGroups { get; set; }

        public ICollection<AccountRoleDto> Roles { get; set; }

        public ICollection<AccountAccountPermissionAssignmentDto> PermissionsAssignments { get; set; }
    }
}
