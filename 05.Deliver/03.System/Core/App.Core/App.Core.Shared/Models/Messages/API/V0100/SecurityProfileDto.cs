using App.Core.Shared.Factories;
using App.Core.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    public class SecurityProfileDto : IHasGuidId
    {
        public SecurityProfileDto()
        {
            GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }

        public string Key { get; set; }

        public ICollection<SecurityProfileRoleGroupDto> AccountGroups { get; set; }

        public ICollection<SecurityProfileRoleDto> Roles { get; set; }

        public ICollection<SecurityProfileSecurityProfilePermissionAssignmentDto> PermissionsAssignments { get; set; }
    }
}
