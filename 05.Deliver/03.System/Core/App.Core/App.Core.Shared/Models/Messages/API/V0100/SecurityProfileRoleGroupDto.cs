using App.Core.Shared.Factories;
using App.Core.Shared.Models;
using System;
using System.Collections.Generic;

namespace App.Core.Shared.Models.Messages.API.V0100
{
    public class SecurityProfileRoleGroupDto : IHasGuidId
    {
        public SecurityProfileRoleGroupDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<SecurityProfileRoleGroupDto> Groups { get; set; }

        public ICollection<SecurityProfileRoleDto> Roles { get; set; }


    }
}
